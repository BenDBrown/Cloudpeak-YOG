using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // for checking if combat is enabled
    private bool isFighting = false;

    // The UI used for combat
    public CombatUI combatUI;

    // chance of a combat encounter
    public int percentEncounterChance = 100;

    // lists for determining turn order
    private List<Combatant> toMoveList = new List<Combatant>();
    private Combatant turnCombatant;
    private Attack selectedAttack;

    void Awake()
    {
        int r = Random.Range(1, 101);

        if(r <= percentEncounterChance)
        {
            SpawnEnemies();
            foreach (Combatant c in FindObjectsOfType<Combatant>(false))
            {
                Debug.Log(c.combatantName + " added to list with position: " + c.position);
                toMoveList.Add(c);
            }
            isFighting = true;
        }
        else
        {
            Debug.Log(r);
        }
    }

    private void Start()
    {
        GiveTurn();
    }

    void GiveTurn()
    {
        if (CombatResolved() == false)
        {
            bool resetRound = true;
            float highestSpeed = 0;
            foreach (Combatant c in toMoveList)
            {
                if (c.speed > highestSpeed && c.DidYouMove() == false && c.IsDead() == false)
                {
                    highestSpeed = c.speed;
                    turnCombatant = c;
                    resetRound = false;
                }

            }
            if (resetRound)
            {
                Debug.Log("resetting round");
                RoundReset();
            }
            else
            {
                combatUI.UpdateUI();
                Debug.Log(turnCombatant.combatantName + " is attacking");
                selectedAttack = null;
                if (turnCombatant.isAlly == false)
                {
                    Attack attack;
                    int enemyAttackSelect = Random.Range(1, 5);
                    attack = turnCombatant.GetAttack(enemyAttackSelect);
                    int enemyTargetSelect = 8;
                    while (attack.Targets.Contains(enemyTargetSelect) == false)
                    {
                        enemyTargetSelect = Random.Range(0, 8);
                    }
                    turnCombatant.Attack(turnCombatant.GetAttack(enemyAttackSelect), GetCombatant(enemyTargetSelect));
                    GiveTurn();

                }
            }
        }
    }

    void RoundReset()
    {
        foreach(Combatant c in toMoveList)
        {
            if (c.IsDead() == false)
            {
                c.GiveMove();
            }
        }
        GiveTurn();
    }

    bool CombatResolved()
    {
        bool defeat = true;
        bool victory = true;
        foreach (Combatant c in toMoveList)
        {
            if (c.IsDead() == false && c.isAlly)
            {
                defeat = false;
            }
            if (c.IsDead() == false && c.isAlly == false)
            {
                victory = false;
            }
        }
        if(victory && defeat)
        {
            // put result of a draw here
            Debug.Log("draw");
            return true;
        }
        else if(victory)
        {
            // put result of victory here
            Debug.Log("W");
            return true;
        }
        else if(defeat)
        {
            // put result of a defeat here
            Debug.Log("L");
            return true;
        }
        else
        {
            return false;
        }
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
            turnCombatant.Attack(selectedAttack, GetCombatant(target));           
        }

        GiveTurn();
    }
    

    void SpawnEnemies()
    {
        foreach(ContainerManager cm in FindObjectsOfType<ContainerManager>(true))
        {
            cm.gameObject.SetActive(true);
        }
        
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

    public Combatant GetCombatant(int position)
    {
        foreach (Combatant combatant in toMoveList)
        {
            if (combatant.position == position)
            {
                return combatant;
            }
        }
        Debug.Log("combatant with postion: " + position + ", could not be found");
        return null;
    }

    public List<Combatant> GetCombatants()
    {
        return toMoveList;
    }

}
