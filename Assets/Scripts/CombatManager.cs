using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // Assignables
    public PlayerPartyManager playerParty;
    public EnemyPartyManager enemyParty;

    // chance of a combat encounter
    public int percentEncounterChance = 100;



    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(1, 101);

        if(r <= percentEncounterChance)
        {
            InitiateCombat();
            Debug.Log("LEEEEEEROY JEEENKINS");
        }
        else
        {
            Debug.Log("common gacha L");
            Debug.Log(r);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitiateCombat()
    {
        enemyParty.gameObject.SetActive(true);

    }

}
