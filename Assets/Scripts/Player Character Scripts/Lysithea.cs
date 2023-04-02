using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lysithea : MonoBehaviour
{
    // the base stats before floor modifiers
    public float vitalityBase = 25;
    public float physicalAttackBase = 14;
    public float magicalAttackBase = 10;
    public float physicalDefenseBase = 12;
    public float magicalDefenseBase = 10;
    public float speedBase = 14;

    // the per level stat increase
    public float vitalityGrowth = 1.5f;
    public float physicalAttackGrowth = 1.6f;
    public float magicalAttackGrowth = 1f;
    public float physicalDefenseGrowth = 1.5f;
    public float magicalDefenseGrowth = 1f;
    public float speedGrowth = 1.5f;

    // the in combat stats calculated using the above
    public float vitality;
    public float physicalAttack;
    public float magicalAttack;
    public float physicalDefense;
    public float magicalDefense;
    public float speed;
    public float hp;

    // Attack 1: Righteous Attack
    public string attackOneName = "Sky Pierce";
    public float attackOneDmgMod = 1f;
    public List<int> attackOnetarget = null;

    // Attack 2: Beacon of Hope
    public string attackTwoName = "Hurricane Slash";
    public float attackTwoDmgMod = 0.5f;
    public List<int> attackTwotarget = null;



    // Start is called before the first frame update
    void Start()
    {
        // placeholder level until level system has been implmented
        int level = 10;
        vitality = vitalityBase + vitalityGrowth * level;
        physicalAttack = physicalAttackBase + physicalAttackGrowth * level;
        magicalAttack = magicalAttackBase + magicalAttackGrowth * level;
        physicalDefense = physicalDefenseBase + physicalDefenseGrowth * level;
        magicalDefense = magicalDefenseBase + magicalDefenseGrowth * level;
        speed = speedBase + speedGrowth * level;
        hp = vitality;
    }
}
