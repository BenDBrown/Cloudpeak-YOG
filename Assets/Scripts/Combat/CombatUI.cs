using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUI : MonoBehaviour
{
    private CombatManager combatManager;

    public GameObject AttackPanel;
    public GameObject EnemyHealthDisplay;
    public GameObject DialogBox;

    //// name spaces for player characters
    public TextMeshProUGUI PC1Name;
    public TextMeshProUGUI PC2Name;
    public TextMeshProUGUI PC3Name;
    public TextMeshProUGUI PC4Name;

    //// health for player characters
    public TextMeshProUGUI PC1Health;
    public TextMeshProUGUI PC2Health;
    public TextMeshProUGUI PC3Health;
    public TextMeshProUGUI PC4Health;

    //// name spaces for enemies
    public TextMeshProUGUI enemy1Name;
    public TextMeshProUGUI enemy2Name;
    public TextMeshProUGUI enemy3Name;
    public TextMeshProUGUI enemy4Name;

    //// health for enemy characters
    public TextMeshProUGUI enemy1Health;
    public TextMeshProUGUI enemy2Health;
    public TextMeshProUGUI enemy3Health;
    public TextMeshProUGUI enemy4Health;

    // the text on the attack buttons
    public TextMeshProUGUI characterSkill1;
    public TextMeshProUGUI characterSkill2;
    public TextMeshProUGUI characterSkill3;
    public TextMeshProUGUI characterSkill4;

    // the cursors that appear when targeting an enemy'
    public GameObject allyCursor1;
    public GameObject allyCursor2;
    public GameObject allyCursor3;
    public GameObject allyCursor4;
    public GameObject enemyCursor1;
    public GameObject enemyCursor2;
    public GameObject enemyCursor3;
    public GameObject enemyCursor4;

    void Awake()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        if (combatManager.AreWeFighting())
        {
            AttackPanel.SetActive(true);
            EnemyHealthDisplay.SetActive(true);
            DialogBox.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        PC1Name.text = combatManager.GetPlayerParty().Icarus.combatantName;
        PC2Name.text = combatManager.GetPlayerParty().Magnus.combatantName;
        PC3Name.text = combatManager.GetPlayerParty().Kena.combatantName;
        PC4Name.text = combatManager.GetPlayerParty().Lysithea.combatantName;

        enemy1Name.text = combatManager.enemy1.GetEnemy().combatantName;
        enemy2Name.text = combatManager.enemy2.GetEnemy().combatantName;
        enemy3Name.text = combatManager.enemy3.GetEnemy().combatantName;
        enemy4Name.text = combatManager.enemy4.GetEnemy().combatantName;

        PC1Health.text = combatManager.GetPlayerParty().Icarus.hp.ToString();
        PC2Health.text = combatManager.GetPlayerParty().Magnus.hp.ToString();
        PC3Health.text = combatManager.GetPlayerParty().Kena.hp.ToString();
        PC4Health.text = combatManager.GetPlayerParty().Lysithea.hp.ToString();

        enemy1Health.text = combatManager.enemy1.GetEnemy().hp.ToString();
        enemy2Health.text = combatManager.enemy2.GetEnemy().hp.ToString();
        enemy3Health.text = combatManager.enemy3.GetEnemy().hp.ToString();
        enemy4Health.text = combatManager.enemy4.GetEnemy().hp.ToString();

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
            allyCursor1.SetActive(false);
            allyCursor2.SetActive(false);
            allyCursor3.SetActive(false);
            allyCursor4.SetActive(false);
            enemyCursor1.SetActive(false);
            enemyCursor2.SetActive(false);
            enemyCursor3.SetActive(false);
            enemyCursor4.SetActive(false);
            combatManager.GetPlayerParty().Icarus.SetButton(false);
            combatManager.GetPlayerParty().Magnus.SetButton(false);
            combatManager.GetPlayerParty().Kena.SetButton(false);
            combatManager.GetPlayerParty().Lysithea.SetButton(false);
        }
    }

    private void AttackCursorSelect(Attack attack)
    {
        combatManager.SetSelectedAttack(attack);
        foreach (int target in attack.Targets)
        {
            if (target == 0)
            {
                allyCursor1.SetActive(true);
                combatManager.GetPlayerParty().Icarus.SetButton(true);
            }
            if (target == 1)
            {
                allyCursor2.SetActive(true);
                combatManager.GetPlayerParty().Magnus.SetButton(true);
            }
            if (target == 2)
            {
                allyCursor3.SetActive(true);
                combatManager.GetPlayerParty().Kena.SetButton(true);
            }
            if (target == 3)
            {
                allyCursor4.SetActive(true);
                combatManager.GetPlayerParty().Lysithea.SetButton(true);
            }
            if (target == 4)
            {
                enemyCursor1.SetActive(true);
                combatManager.enemy1.GetEnemy().SetButton(true);
            }
            if (target == 5)
            {
                enemyCursor2.SetActive(true);
                combatManager.enemy2.GetEnemy().SetButton(true);
            }
            if (target == 6)
            {
                enemyCursor3.SetActive(true);
                combatManager.enemy3.GetEnemy().SetButton(true);
            }
            if (target == 7)
            {
                enemyCursor4.SetActive(true);
                combatManager.enemy4.GetEnemy().SetButton(true);
            }

        }
    }

    public void SelectAttack(int selectedAttack)
    {
        combatManager.SetSelectedAttack(selectedAttack);
        if (combatManager.GetSelectedAttack().aoe)
        {
            combatManager.PlayerAoeAttack();
            UpdateCursors();
        }
        else
        {
            UpdateCursors();
        }
    }
    
}
