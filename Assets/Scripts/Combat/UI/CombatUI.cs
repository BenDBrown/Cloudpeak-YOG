using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    void Start()
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
        if(combatManager.GetSelectedAttack() != null)
        {
            AttackCursorSelect(combatManager.GetSelectedAttack());
        }       
        else
        {
            foreach(Combatant combatant in combatManager.GetCombatants())
            {
                combatant.SetCursorActive(false);
            }
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
    
}
