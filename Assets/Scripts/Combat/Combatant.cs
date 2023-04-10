using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combatant : MonoBehaviour
{
    // the position of the combatant from 0-7
    public int position;

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

    // state checks for moving
    private bool didIMove = false;
    private bool dead = false;
    private bool stunned = false;

    // List of status effects on the character
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
            AddAttackToLog(this, attack, target);
            target.GetAttacked(damage, attack.dmgOutput, attack.statusEffect);
        }
        ApplyStatChanges(true);
    }

    public void GetAttacked(float damage, int dmgType, StatusEffect statusEffect)
    {
        Debug.Log(combatantName + " had " + hp + " pre damage hp");
        bool logStun = false;
        if (dmgType == 0)
        {
            damage = damage * (physicalDefense / (physicalDefense + damage));
            if(damage <= 0)
            {
                damage = 0;
            }
        }
        else if (dmgType == 1)
        {
            damage = damage * (magicalDefense / (magicalDefense + damage));
            if (damage <= 0)
            {
                damage = 0;
            }
        }
        hp -= damage;
        if(hp <= 0)
        {
            hp = 0;
            Debug.Log(combatantName + " died");
            dead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<TargetClick>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else if(hp > vitality)
        {
            hp = vitality;
        }
        if (statusEffect != null)
        {
            if (statusEffect.RollForStun() == true && didIMove == false)
            {
                didIMove = true;
                logStun = true;
            }
            else if (statusEffect.RollForStun() == true && didIMove == true)
            {
                stunned = true;
                logStun = true;
            }
            StatusEffect statusClone = gameObject.AddComponent<StatusEffect>();
            statusClone.Clone(statusEffect);
            GetStatused(statusClone);
        }
        AddDefenseToLog(this, damage, statusEffect, logStun);
    }

    void GetStatused(StatusEffect statusEffect)
    {
        statusEffects.Add(statusEffect);
        ApplyStatChanges(false);
    }

    void ApplyStatChanges(bool tick)
    {
        RestoreStats();
        bool breakcheck = false;
        for (int i = 0; i < statusEffects.Count; i++)
        {
            physicalAttack = physicalAttack * statusEffects[i].physicalAttackDelta;
            magicalAttack = magicalAttack * statusEffects[i].magicalAttackDelta;
            physicalDefense = physicalDefense * statusEffects[i].physicalDefenseDelta;
            magicalDefense = magicalDefense * statusEffects[i].magicalDefenseDelta;
            speed = speed * statusEffects[i].speedDelta;

            if(tick)
            {
                hp += statusEffects[i].hpDelta * hp / 100;
                statusEffects[i].TickStatus();
            }    

            if (statusEffects[i].turnDuration < 1)
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
            ApplyStatChanges(false);
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

    public void GiveMove()
    {
        if(stunned)
        {
            stunned = false;
        }
        else
        {
            didIMove = false;
        }
        
    }
    public bool IsDead()
    {
        return this.dead;
    }

    public void SetButton(bool buttonOn)
    {
        TargetClick button = GetComponent<TargetClick>();
        button.SetActivity(buttonOn);
    }

    public Attack GetAttack(int attack)
    {
        if (attack == 1)
        {
            return attack1;
        }
        else if (attack == 2)
        {
            return attack2;
        }
        else if (attack == 3)
        {
            return attack3;
        }
        else
        {
            return attack4;
        }
    }

    public void SetCursorActive(bool active)
    {
        if(dead)
        {
            GetComponentInChildren<Cursor>(true).gameObject.SetActive(false);
        }
        else
        {
            GetComponentInChildren<Cursor>(true).gameObject.SetActive(active);
        }
        
    }    

    void AddDefenseToLog(Combatant defender, float damageTaken, StatusEffect status, bool stunned)
    {
        GetComponentInParent<CombatManager>().combatUI.AddDefenseToLog(defender, damageTaken, status, stunned);
    }

    void AddAttackToLog(Combatant attacker, Attack usedAttack, Combatant defender)
    {
        GetComponentInParent<CombatManager>().combatUI.AddAttackToLog(attacker, usedAttack, defender);
    }

}
