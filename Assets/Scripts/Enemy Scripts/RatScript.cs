using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatScript : MonoBehaviour
{
    // the base stats before floor modifiers
    public float vitalityBase = 16;
    public float physicalAttackBase = 7;
    public float magicalAttackBase = 0;
    public float physicalDefenseBase = 8;
    public float magicalDefenseBase = 6;
    public float speedBase = 13;

    // the per floor stat increase for each stat
    public float vitalityGrowth = 1f;
    public float physicalAttackGrowth = 1.5f;
    public float magicalAttackGrowth = 0f;
    public float physicalDefenseGrowth = 1f;
    public float magicalDefenseGrowth = 0.8f;
    public float speedGrowth = 2f;

    // the in combat stats calculated using the above
    public float vitality;
    public float physicalAttack;
    public float magicalAttack;
    public float physicalDefense;
    public float magicalDefense;
    public float speed;
    public float hp;

    // Attack 1: Rat Bite
    public string attackOneName = "Rat Bite";
    public float attackOneDmgMod = 1f;
    public List<int> attackOnetarget = null;

    // Attack 2: Rat Scratch
    public string attackTwoName = "Rat Scratch";
    public float attackTwoDmgMod = 0.5f;
    public List<int> attackTwotarget = null;

    // Start is called before the first frame update
    void Awake()
    {
        int floorNr = GetComponentInParent<CombatManager>().GetFloor();
        vitality = vitalityBase + vitalityGrowth * floorNr;
        physicalAttack = physicalAttackBase + physicalAttackGrowth * floorNr;
        magicalAttack = magicalAttackBase + magicalAttackGrowth * floorNr;
        physicalDefense = physicalDefenseBase + physicalDefenseGrowth * floorNr;
        magicalDefense = magicalDefenseBase + magicalDefenseGrowth * floorNr;
        speed = speedBase + speedGrowth * floorNr;
        hp = vitality;
    }



    
}
