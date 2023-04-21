using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    // for checking if combat is enabled
    private bool isFighting = false;

    // The UI used for combat
    public CombatUI combatUI;

    // chance of a combat encounter
    public int percentEncounterChance = 100;
    public CheckingAndUpdatingTheFloorNumbers floorNr;
    public NextFloor nextFloor;

    // lists for determining turn order
    private List<Combatant> toMoveList = new List<Combatant>();
    private Combatant turnCombatant;
    private Attack selectedAttack;
    private Inventory inventory;

    private float xp;

    private void Awake()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }

    void OnEnable()
    {
        int r = Random.Range(1, 101);
        xp = 0;
        if (GetFloor() == 5)
        {
            foreach (ContainerManager cm in FindObjectsOfType<ContainerManager>(true))
            {
                if (cm.gameObject.name.Contains("Bosswrapper 1"))
                {
                    cm.gameObject.SetActive(true);
                }

            }
            Debug.Log("Spawn boss 1");
          
            foreach (Combatant c in FindObjectsOfType<Combatant>(false))
            {
                Debug.Log(c.combatantName + " added to list with position: " + c.position);
                c.FightPrep();
                if (c.isAlly == false)
                {
                    xp += c.hp;
                }
                toMoveList.Add(c);
            }
            isFighting = true;
            GiveTurnAsync();
        }
        else if(GetFloor() == 10)
        {
            foreach (ContainerManager cm in FindObjectsOfType<ContainerManager>(true))
            {
                if (cm.gameObject.name == "Bosswrapper")
                {
                    cm.gameObject.SetActive(true);
                }

            }
            Debug.Log("Spawn boss 2");

            foreach (Combatant c in FindObjectsOfType<Combatant>(false))
            {
                Debug.Log(c.combatantName + " added to list with position: " + c.position);
                c.FightPrep();
                if (c.isAlly == false)
                {
                    xp += c.hp;
                }
                toMoveList.Add(c);
            }
            isFighting = true;
            GiveTurnAsync();
        }

       else if(r <= percentEncounterChance)
        {
            SpawnEnemies(true);
            foreach (Combatant c in FindObjectsOfType<Combatant>(false))
            {
                Debug.Log(c.combatantName + " added to list with position: " + c.position);
                c.FightPrep();
                if(c.isAlly == false)
                {
                    xp += c.hp;
                }
                toMoveList.Add(c);
            }
            isFighting = true;
            GiveTurnAsync();
        }
        else
        {
            Debug.Log(r);
        }
    }

    async Task GiveTurnAsync()
    {
        selectedAttack = null;
        combatUI.UpdateCursors();
        await Task.Delay(2000);
        combatUI.Setup();
        combatUI.ToggleWait(false);
        if (CombatResolved() == false)
        {
            bool resetRound = true;
            float highestSpeed = 0;
            selectedAttack = null;
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
                await RoundResetAsync();
            }
            else
            {
                combatUI.UpdateUI();
                Debug.Log(turnCombatant.combatantName + " is attacking");
                if (turnCombatant.isAlly == false)
                {
                    await AIAttackAsync();
                }
            }
        }
    }

    async Task RoundResetAsync()
    {
        foreach(Combatant c in toMoveList)
        {
            if (c.IsDead() == false)
            {
                c.GiveMove();
            }
        }
        await GiveTurnAsync();
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
            combatUI.VictoryScreen();
            Debug.Log("draw");
            isFighting = false;
            return true;
        }
        else if(victory)
        {
            Debug.Log("W");
            combatUI.VictoryScreen();
            foreach (Combatant c in toMoveList)
            {
                if(c.isAlly)
                {
                    c.levelUp(xp);
                }
            }
            SpawnEnemies(false);
            toMoveList.Clear();
            isFighting = false;
            return true;
        }
        else if(defeat)
        {
            Debug.Log("L");
            isFighting = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task PlayerAttackAsync(Combatant target)
    {
        await turnCombatant.AttackAsync(selectedAttack, target);
        await GiveTurnAsync();
    }

    // functions called when a player selects an attack
    public async Task AoeAttackAsync()
    {
        foreach (int target in selectedAttack.Targets)
        {
            if(GetCombatant(target) != null)
            {
                await turnCombatant.AttackAsync(selectedAttack, GetCombatant(target));
            }                 
        }

        await GiveTurnAsync();
    }

    async Task AIAttackAsync()
    {
        bool valid = false;
        int enemyAttackSelect;
        while (valid == false)
        {
            enemyAttackSelect = Random.Range(1, 5);
            selectedAttack = turnCombatant.GetAttack(enemyAttackSelect);
            valid = ValidateTargets();
        }

        if (selectedAttack.aoe == false)
        {
            int enemyTargetSelect = 8;
            int breakCounter = 0;
            while (selectedAttack.Targets.Contains(enemyTargetSelect) == false || GetCombatant(enemyTargetSelect).IsDead())
            {
                enemyTargetSelect = Random.Range(0, 8);
                breakCounter++;
                if(breakCounter > 10000000)
                {
                    Debug.Log("either the Attack: '" + selectedAttack.attackName + "' did not contain a valid target or you won the lottery but got nothing");
                    break;
                }
            }
            await turnCombatant.AttackAsync(selectedAttack, GetCombatant(enemyTargetSelect));
            await GiveTurnAsync();
        }
        else
        {
            await AoeAttackAsync();
        }
    }

    bool ValidateTargets()
    {
        foreach (int target in selectedAttack.Targets)
        {
            if (GetCombatant(target).IsDead() == false)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnEnemies(bool spawn)
    {
        if (spawn)
        {
            foreach (ContainerManager cm in FindObjectsOfType<ContainerManager>(true))
            {
                if (cm.gameObject.name.Contains("Enemy"))
                {
                    cm.gameObject.SetActive(spawn);
                }

            }
        }
        else
        {
            foreach (ContainerManager cm in FindObjectsOfType<ContainerManager>(false))
            {
               
                    cm.gameObject.SetActive(spawn);
                

            }
        }
        
    }


    public bool AreWeFighting()
    {
        return isFighting;
    }

    // will return the current floor number, right now returns a placeholder
    public int GetFloor()
    {
        return floorNr.CurrentFloor();
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
