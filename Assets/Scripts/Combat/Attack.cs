using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string attackName;
    public float dmgMod;
    private StatusEffect statusEffect;

    // dmgInput decides which stat is used from the attacker to calculate damage
    // might add damage based on other stats so not using boolean
    // 0 = strength
    // 1 = magic
    public int dmgInput;

    // dmgOutput decides if the damage dealt is magical or physical
    // 0 = physical
    // 1 = magical
    // 2 = n/a
    public int dmgOutput;

    // List of the slots targeted by an attack
    // 1 = slot 1
    // 2 = slot 2 etc
    public List<int> Targets;

    public bool aoe = false;
    public bool includeSelf = false;
    public bool excludeSelf = false;

    private void Start()
    {
        if(includeSelf)
        {
            Targets.Add(GetComponentInParent<Combatant>().position);
            Debug.Log("set target for: " + attackName + " to " + Targets[0]);
        }
        else if (excludeSelf)
        {
            Targets.Remove(GetComponentInParent<Combatant>().position);
            Debug.Log("Removed self from " + attackName + " target pool");
        }
        statusEffect = gameObject.GetComponent<StatusEffect>();
    }

    public StatusEffect GetStatusEffect()
    {
        return statusEffect;
    }

}
