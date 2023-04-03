using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public string attackName;
    public float dmgMod;

    // dmgInput decides which stat is used from the attacker to calculate damage
    // might add damage based on other stats so not using boolean
    // 0 == strength
    // 1 == magic
    public int dmgInput;

    // dmgOutput decides if the damage dealt is magical or physical
    // 0 == physical
    // 1 == magical
    // 2 == n/a
    public int dmgOutput;

    public bool canHitSlot1;
    public bool canHitSlot2;
    public bool canHitSlot3;
    public bool canHitSlot4;


}
