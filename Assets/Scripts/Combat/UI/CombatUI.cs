using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class CombatUI : MonoBehaviour
{
    public GameObject AttackPanel;
    public GameObject EnemyHealthDisplay;
    public CombatLog combatLog;

    public CombatManager combatManager;

    public List<HealthBarManager> HealthBarManagers;

    // the text on the attack buttons
    public TextMeshProUGUI characterSkill1;
    public TextMeshProUGUI characterSkill2;
    public TextMeshProUGUI characterSkill3;
    public TextMeshProUGUI characterSkill4;

    private bool waiting = false;

    public void Setup()
    {
        if (combatManager.AreWeFighting())
        {
            AttackPanel.SetActive(true);
            EnemyHealthDisplay.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        foreach(HealthBarManager healthBarManager in HealthBarManagers)
        {
            healthBarManager.UpdateText();
        }

        if (combatManager.GetTurnCombatant().isAlly)
        {
            characterSkill1.text = combatManager.GetTurnCombatant().attack1.attackName;
            characterSkill2.text = combatManager.GetTurnCombatant().attack2.attackName;
            characterSkill3.text = combatManager.GetTurnCombatant().attack3.attackName;
            characterSkill4.text = combatManager.GetTurnCombatant().attack4.attackName;
        }
        UpdateCursors();
    }

    public void UpdateCursors()
    {
        foreach (Combatant combatant in combatManager.GetCombatants())
        {
            combatant.SetCursorActive(false);
        }
        if (combatManager.GetSelectedAttack() != null)
        {
            AttackCursorSelect(combatManager.GetSelectedAttack());
        }       
    }

    private void AttackCursorSelect(Attack attack)
    {
        combatManager.SetSelectedAttack(attack);

        foreach (int target in attack.Targets)
        {
            combatManager.GetCombatant(target).SetButton(true);
            combatManager.GetCombatant(target).SetCursorActive(true);
        }
    }

    public void SelectAttack(int selectedAttack)
    {
        combatManager.SetSelectedAttack(selectedAttack);
        if (combatManager.GetSelectedAttack().aoe)
        {
            combatManager.AoeAttack();
            UpdateCursors();
        }
        else
        {
            UpdateCursors();
        }
    }

    public void AddAttackToLog(Combatant attacker, Attack usedAttack, Combatant defender)
    {
        combatLog.AddAttackersStory(attacker, usedAttack, defender);   
    }

    public void AddDefenseToLog(Combatant defender, float damageTaken, StatusEffect status, bool stunned)
    {
        int roundedDamage = Mathf.RoundToInt(damageTaken);
        combatLog.AddDefendersStory(defender, roundedDamage, status, stunned);
    }
    
    public bool IsWaiting()
    {
        return waiting;
    }

    public void ToggleWait(bool wait)
    {
        waiting = wait;
    }

}
