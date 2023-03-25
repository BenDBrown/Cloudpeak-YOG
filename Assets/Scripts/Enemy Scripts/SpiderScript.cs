using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    // the base stats before floor modifiers
    public float vitalityBase = 15;
    public float physicalAttackBase = 5;
    public float magicalAttackBase = 5;
    public float physicalDefenseBase = 11;
    public float magicalDefenseBase = 5;
    public float speedBase = 11;

    // the per floor stat increase for each stat
    public float vitalityGrowth = 1f;
    public float physicalAttackGrowth = 0.5f;
    public float magicalAttackGrowth = 0.5f;
    public float physicalDefenseGrowth = 1.1f;
    public float magicalDefenseGrowth = 0.8f;
    public float speedGrowth = 1.7f;

    // the in combat stats calculated using the above
    public float vitality;
    public float physicalAttack;
    public float magicalAttack;
    public float physicalDefense;
    public float magicalDefense;
    public float speed;
    public float hp;

    // Attack 1: spider Bite
    public string attackOneName = "Spider Bite";
    public float attackOneDmgMod = 1f;
    public List<int> attackOnetarget = null;

    // Attack 2: spider Scratch
    public string attackTwoName = "Web Shot";
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
