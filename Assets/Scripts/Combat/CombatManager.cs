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
    private Combatant turnCombatant;
    private Attack selectedAttack;



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
    }

    // functions called when a player selects an attack
    public void PlayerAttack(int targetnr)
    {
        Debug.Log("the button works");
        if (targetnr == 0)
        {
            turnCombatant.Attack(selectedAttack, playerParty.Icarus);
        }
        else if (targetnr == 1)
        {
            turnCombatant.Attack(selectedAttack, playerParty.Magnus);
        }
        else if (targetnr == 2)
        {
            turnCombatant.Attack(selectedAttack, playerParty.Kena);
        }
        else if (targetnr == 3)
        {
            turnCombatant.Attack(selectedAttack, playerParty.Lysithea);
        }
        else if (targetnr == 4)
        {
            turnCombatant.Attack(selectedAttack, enemy1.GetEnemy());
        }
        else if (targetnr == 5)
        {
            turnCombatant.Attack(selectedAttack, enemy2.GetEnemy());
        }
        else if (targetnr == 6)
        {
            turnCombatant.Attack(selectedAttack, enemy3.GetEnemy());
        }
        else if (targetnr == 7)
        {
            turnCombatant.Attack(selectedAttack, enemy4.GetEnemy());
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

}
