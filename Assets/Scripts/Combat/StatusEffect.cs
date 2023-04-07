using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    public string statusName;

    // amount of turns that a status lasts
    public int turnDuration;

    // modifiers that multiply a combatant stats ie: 2 would double attack and 0.5 would halve attack
    public float physicalAttackDelta;
    public float magicalAttackDelta;
    public float physicalDefenseDelta;
    public float magicalDefenseDelta;
    public float speedDelta;

    public void TickStatus()
    {
        turnDuration -= 1;
    }


}
