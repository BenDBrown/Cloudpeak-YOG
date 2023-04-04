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
    public CombatUI combatUI;


    // chance of a combat encounter
    public int percentEncounterChance = 100;

    // lists for determining turn order
    public List<Combatant> toMoveList = new List<Combatant>();
    public List<Combatant> hasMovedList = new List<Combatant>();
    private Combatant turnCombatant;



    // Start is called before the first frame update
    void Awake()
    {
        int r = Random.Range(1, 101);

        if(r <= percentEncounterChance)
        {
            SpawnEnemies();
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

    //public void EndTurn()
    //{
        
    //     foreach(Combatant c in toMoveList)
    //     {
    //         if(c.DidYouMove())
    //         {
    //             toMoveList.Remove(c);
    //             hasMovedList.Add(c);
    //         }
    //         else if(c.IsDead())
    //         {
    //             toMoveList.Remove(c);
    //         }
    //     }
        
        
    //}

    void GiveTurn()
    {
        combatUI.UpdateUI();
        float highestSpeed = 0;
        foreach(Combatant c in toMoveList)
        {

            if (c.speed > highestSpeed && c.DidYouMove() == false && c.IsDead() == false)
            {
                highestSpeed = c.speed;
                turnCombatant = c;
            }
        }
        Debug.Log(turnCombatant.combatantName + " is attacking");
        if(turnCombatant.isAlly)
        {
            combatUI.UpdateAttackPanel(turnCombatant);
        }
        else
        {
            combatUI.UpdateAttackPanel(turnCombatant);
            int enemyAttackSelect = Random.Range(1, 5);
            int enemyTargetSelect = Random.Range(1, 5);
            if(enemyTargetSelect == 1)
            {
                turnCombatant.Attack(turnCombatant.AIAttackSelect(enemyAttackSelect), playerParty.Icarus);
                GiveTurn();
            }
            else if (enemyTargetSelect == 2)
            {
                turnCombatant.Attack(turnCombatant.AIAttackSelect(enemyAttackSelect), playerParty.Magnus);
                GiveTurn();
            }
            else if (enemyTargetSelect == 3)
            {
                turnCombatant.Attack(turnCombatant.AIAttackSelect(enemyAttackSelect), playerParty.Kena);
                GiveTurn();
            }
            else
            {
                turnCombatant.Attack(turnCombatant.AIAttackSelect(enemyAttackSelect), playerParty.Lysithea);
                GiveTurn();
            }

        }
    }

    void CombatSetup()
    {
        toMoveList.Add(playerParty.Icarus);
        toMoveList.Add(playerParty.Magnus);
        toMoveList.Add(playerParty.Kena);
        toMoveList.Add(playerParty.Lysithea);
        toMoveList.Add(enemy1.GetEnemy());
        toMoveList.Add(enemy2.GetEnemy());
        toMoveList.Add(enemy3.GetEnemy());
        toMoveList.Add(enemy4.GetEnemy());

        GiveTurn();
        //Debug.Log(turnCombatant.combatantName);
        
        //Debug.Log(toMoveList[0]);
        //Debug.Log(toMoveList[1]);
        //Debug.Log(toMoveList[2]);
        //Debug.Log(toMoveList[3]);
        //Debug.Log(toMoveList[4]);
        //Debug.Log(toMoveList[5]);
        //Debug.Log(toMoveList[6]);
        //Debug.Log(toMoveList[7]);
        
    }

    // functions called when a player selects an attack
    // need to add targeting functionality still
    public void PlayerAttack1()
    {
        turnCombatant.Attack(turnCombatant.attack1, enemy1.GetEnemy());
        GiveTurn();
    }
    public void PlayerAttack2()
    {
        turnCombatant.Attack(turnCombatant.attack2, enemy1.GetEnemy());
        GiveTurn();
    }
    public void PlayerAttack3()
    {
        turnCombatant.Attack(turnCombatant.attack3, enemy1.GetEnemy());
        GiveTurn();
    }
    public void PlayerAttack4()
    {
        turnCombatant.Attack(turnCombatant.attack4, enemy1.GetEnemy());
        GiveTurn();
    }

    void SpawnEnemies()
    {
        enemyParty.gameObject.SetActive(true);
        
    }

    public bool AreWeFighting()
    {
        return isFighting;
    }

    // will return the current floor number, right now returns a placeholder
    public int GetFloor()
    {
        return 10;
    }

}
