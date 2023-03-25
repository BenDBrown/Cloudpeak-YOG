using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // for checking if combat is enabled
    private bool isFighting = false;

    // Assignables
    public PlayerPartyManager playerParty;
    public EnemyPartyManager enemyParty;
    public ContainerManager enemy1;
    public ContainerManager enemy2;
    public ContainerManager enemy3;
    public ContainerManager enemy4;

    // chance of a combat encounter
    public int percentEncounterChance = 100;

    // lists for determining turn order
    public List<float> toMoveList = new List<float>();
    public List<float> hasMovedList = new List<float>();



    // Start is called before the first frame update
    void Awake()
    {
        int r = Random.Range(1, 101);

        if(r <= percentEncounterChance)
        {
            InitiateCombat();
            isFighting = true;
            Debug.Log("LEEEEEEROY JEEENKINS");
        }
        else
        {
            Debug.Log("common gacha L");
            Debug.Log(r);
        }

    }

    private void Start()
    {
        if (isFighting == true)
        {
            CombatSetup();
        }
        
    }

    void CombatSetup()
    {
        toMoveList.Add(GetComponentInChildren<Icarus>(false).speed);
        toMoveList.Add(GetComponentInChildren<Magnus>(false).speed);
        toMoveList.Add(GetComponentInChildren<Kena>(false).speed);
        toMoveList.Add(GetComponentInChildren<Lysithea>(false).speed);
        toMoveList.Add(enemy1.GetSpeed());
        toMoveList.Add(enemy2.GetSpeed());
        toMoveList.Add(enemy3.GetSpeed());
        toMoveList.Add(enemy4.GetSpeed());
        toMoveList.Sort();
        /*
        Debug.Log(toMoveList[0]);
        Debug.Log(toMoveList[1]);
        Debug.Log(toMoveList[2]);
        Debug.Log(toMoveList[3]);
        Debug.Log(toMoveList[4]);
        Debug.Log(toMoveList[5]);
        Debug.Log(toMoveList[6]);
        Debug.Log(toMoveList[7]);
        */
    }

    void InitiateCombat()
    {
        enemyParty.gameObject.SetActive(true);
        
    }

    // will return the current floor number, right now returns a placeholder
    public int GetFloor()
    {
        return 10;
    }

}
