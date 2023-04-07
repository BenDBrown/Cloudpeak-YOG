using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // for checking if combat is enabled
    private bool isFighting = false;

    // Assignables

    public ContainerManager enemy1;
    public ContainerManager enemy2;
    public ContainerManager enemy3;
    public ContainerManager enemy4;


    private CombatUI combatUI;
    private PlayerPartyManager playerParty;
    private EnemyPartyManager enemyParty;


    // chance of a combat encounter
    public int percentEncounterChance = 100;

    // lists for determining turn order
    private List<Combatant> toMoveList = new List<Combatant>();
    private Combatant turnCombatant;
    private Attack selectedAttack;



    void Awake()
    {
        int r = Random.Range(1, 101);
        combatUI = FindFirstObjectByType<CombatUI>();
        playerParty = FindFirstObjectByType<PlayerPartyManager>();
        enemyParty = FindFirstObjectByType<EnemyPartyManager>();

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

    void GiveTurn()
    {
        float highestSpeed = 0;
        foreach(Combatant c in toMoveList)
        {

            if (c.speed > highestSpeed && c.DidYouMove() == false && c.IsDead() == false)
            {
                highestSpeed = c.speed;
                turnCombatant = c;
            }
        }
        combatUI.UpdateUI();
        Debug.Log(turnCombatant.combatantName + " is attacking");
        selectedAttack = null;
        if (turnCombatant.isAlly == false)
        {
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
    }

    public void PlayerAttack(Combatant target)
    {
        turnCombatant.Attack(selectedAttack, target);
        GiveTurn();
    }

    // functions called when a player selects an attack
    public void PlayerAoeAttack()
    {
        foreach (int target in selectedAttack.Targets)
        {
            if (target == 0)
            {
                turnCombatant.Attack(selectedAttack, playerParty.Icarus);
            }
            else if (target == 1)
            {
                turnCombatant.Attack(selectedAttack, playerParty.Magnus);
            }
            else if (target == 2)
            {
                turnCombatant.Attack(selectedAttack, playerParty.Kena);
            }
            else if (target == 3)
            {
                turnCombatant.Attack(selectedAttack, playerParty.Lysithea);
            }
            else if (target == 4)
            {
                turnCombatant.Attack(selectedAttack, enemy1.GetEnemy());
            }
            else if (target == 5)
            {
                turnCombatant.Attack(selectedAttack, enemy2.GetEnemy());
            }
            else if (target == 6)
            {
                turnCombatant.Attack(selectedAttack, enemy3.GetEnemy());
            }
            else if (target == 7)
            {
                turnCombatant.Attack(selectedAttack, enemy4.GetEnemy());
            }
        }

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

    public Combatant GetTurnCombatant()
    {
        return turnCombatant;
    }

    public void SetSelectedAttack(Attack attack)
    {
        selectedAttack = attack;
    }

    public void SetSelectedAttack(int attack)
    {
        if (attack == 1)
        {
            selectedAttack = GetTurnCombatant().attack1;
        }
        else if (attack == 2)
        {
            selectedAttack = GetTurnCombatant().attack2;
        }
        else if (attack == 3)
        {
            selectedAttack = GetTurnCombatant().attack3;
        }
        else if (attack == 4)
        {
            selectedAttack = GetTurnCombatant().attack4;
        }
    }

    public Attack GetSelectedAttack()
    {
        return selectedAttack;
    }

    public PlayerPartyManager GetPlayerParty()
    {
        return playerParty;
    }

}
