using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    // the base stats before floor modifiers
    public float vitalityBase = 10;
    public float physicalAttackBase = 10;
    public float magicalAttackBase = 10;
    public float physicalDefenseBase = 10;
    public float magicalDefenseBase = 10;
    public float speedBase = 10;

    // the per floor stat increase for each stat
    public float vitalityGrowth = 1f;
    public float physicalAttackGrowth = 1f;
    public float magicalAttackGrowth = 1f;
    public float physicalDefenseGrowth = 1f;
    public float magicalDefenseGrowth = 1f;
    public float speedGrowth = 1f;

    // the in combat stats calculated using the above
    public int level = 10;
    public float vitality;
    public float physicalAttack;
    public float magicalAttack;
    public float physicalDefense;
    public float magicalDefense;
    public float speed;
    public float hp;

    // in combat clones of stats used to revert stat changes
    private float physicalAttackClone;
    private float magicalAttackClone;
    private float physicalDefenseClone;
    private float magicalDefenseClone;
    private float speedClone;

    // character/enemy name
    public string combatantName;
    // specifies weather combatant is an enemy or player character (ai or player controlled)
    public bool isAlly;

    // Attacks
    public Attack attack1;
    public Attack attack2;
    public Attack attack3;
    public Attack attack4;

    private bool didIMove = false;
    private bool dead = false;

    private List<StatusEffect> statusEffects;

    void Awake()
    {
        vitality = vitalityBase + vitalityGrowth * level;
        physicalAttack = physicalAttackBase + physicalAttackGrowth * level;
        magicalAttack = magicalAttackBase + magicalAttackGrowth * level;
        physicalDefense = physicalDefenseBase + physicalDefenseGrowth * level;
        magicalDefense = magicalDefenseBase + magicalDefenseGrowth * level;
        speed = speedBase + speedGrowth * level;
        hp = vitality;

        physicalAttackClone = physicalAttack;
        magicalAttackClone = magicalAttack;
        physicalDefenseClone = physicalDefense;
        magicalDefenseClone = magicalDefense;
        speedClone = speed;

        statusEffects = new List<StatusEffect>();
    }

    public void Attack(Attack attack, Combatant target)
    {
        float damage;
        didIMove = true;
        if (target.IsDead() == false)
        {
            if (attack.dmgInput == 0)
            {
                damage = physicalAttack * attack.dmgMod;
                damage += Random.Range(-damage * 0.1f, damage * 0.1f);
                Debug.Log(combatantName + " used " + attack.attackName + ", pre-mitigation damage: " + damage);
            }
            else
            {
                damage = magicalAttack * attack.dmgMod;
                damage += Random.Range(-damage * 0.1f, damage * 0.1f);
                Debug.Log(combatantName + " used " + attack.attackName + ", pre-mitigation damage: " + damage);
            }
            target.GetAttacked(damage, attack.dmgOutput, attack.statusEffect);
        }
        FullStatUpdate();
    }

    public void GetAttacked(float damage, int dmgType, StatusEffect statusEffect)
    {
        Debug.Log(combatantName + " had " + hp + " pre damage hp");
        if (dmgType == 0)
        {
            damage -= physicalDefense / 2;
        }
        else if (dmgType == 1)
        {
            damage -= magicalDefense / 2;
        }
        hp -= damage;
        if(hp <= 0)
        {
            Debug.Log(combatantName + " died");
            dead = true;
        }
        if(statusEffect != null)
        {
            ApplyOneStatus(statusEffect);
            GetStatused(statusEffect);
        }
        Debug.Log(combatantName + " took " + damage + " post mitigation damage");
        Debug.Log("post damage hp: " + hp);
    }

    void GetStatused(StatusEffect statusEffect)
    {
        statusEffects.Add(statusEffect);
    }

    void FullStatUpdate()
    {
        ApplyStatChanges();
        RestoreStats();
        
    }

    void ApplyOneStatus(StatusEffect statusEffect)
    {
        physicalAttack = physicalAttack * statusEffect.physicalAttackDelta;
        magicalAttack = magicalAttack * statusEffect.magicalAttackDelta;
        physicalDefense = physicalDefense * statusEffect.physicalDefenseDelta;
        magicalDefense = magicalDefense * statusEffect.magicalDefenseDelta;
        speed = speed * statusEffect.speedDelta;
    }

    void ApplyStatChanges()
    {
        bool breakcheck = false;
        for (int i = 0; i < statusEffects.Count; i++)
        {
            physicalAttack = physicalAttack * statusEffects[i].physicalAttackDelta;
            magicalAttack = magicalAttack * statusEffects[i].magicalAttackDelta;
            physicalDefense = physicalDefense * statusEffects[i].physicalDefenseDelta;
            magicalDefense = magicalDefense * statusEffects[i].magicalDefenseDelta;
            speed = speed * statusEffects[i].speedDelta;

            statusEffects[i].TickStatus();

            if (statusEffects[i].turnDuration < 0)
            {
                Debug.Log(statusEffects[i].statusName + " has successfully been removed");
                statusEffects.RemoveAt(i);
                RestoreStats();
                breakcheck = true;
                break;
            }
        }
        if(breakcheck)
        {
            FullStatUpdate();
        }

    }

    void RestoreStats()
    {
        physicalAttack = physicalAttackClone;
        magicalAttack = magicalAttackClone;
        physicalDefense = physicalDefenseClone;
        magicalDefense = magicalDefenseClone;
        speed = speedClone;
    }

    public bool DidYouMove()
    {
        return didIMove;
    }
    public bool IsDead()
    {
        return dead;
    }

    public Attack AIAttackSelect(int selectedAttack)
    {
        if(selectedAttack == 1)
        {
            return attack1;
        }
        else if(selectedAttack == 2)
        {
            return attack2;
        }
        else if (selectedAttack == 3)
        {
            return attack3;
        }
        else
        {
            return attack4;
        }
    }

}
