using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public string statusName;

    // amount of turns that a status lasts
    public int turnDuration;

    // modifiers that multiply a combatant stats ie: 2 would double attack and 0.5 would halve attack
    public float physicalAttackDelta = 1;
    public float magicalAttackDelta = 1;
    public float physicalDefenseDelta = 1;
    public float magicalDefenseDelta = 1;
    public float speedDelta = 1;
    public float hpDelta = 0;
    public int stunChance = 0;

    public void Clone(StatusEffect statusEffect)
    {
        statusName = statusEffect.statusName;
        turnDuration = statusEffect.turnDuration;
        physicalAttackDelta = statusEffect.physicalAttackDelta;
        magicalAttackDelta = statusEffect.magicalAttackDelta;
        physicalDefenseDelta = statusEffect.physicalDefenseDelta;
        magicalDefenseDelta = statusEffect.magicalDefenseDelta;
        speedDelta = statusEffect.speedDelta;
        hpDelta = statusEffect.hpDelta;
        stunChance = statusEffect.stunChance;
    }

    public bool RollForStun()
    {
        int r = Random.Range(1, 101);
        if(stunChance >= r)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void TickStatus()
    {
        turnDuration -= 1;
    }


}
