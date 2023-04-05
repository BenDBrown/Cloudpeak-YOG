using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatUI : MonoBehaviour
{
    public CombatManager combatManager;

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

    void Start()
    {
        if (combatManager.AreWeFighting())
        {
            EnemyHealthDisplay.SetActive(true);
            DialogBox.SetActive(true);
        }
    }

    public void UpdateUI()
    {
        PC1Name.text = combatManager.playerParty.Icarus.combatantName;
        PC2Name.text = combatManager.playerParty.Magnus.combatantName;
        PC3Name.text = combatManager.playerParty.Kena.combatantName;
        PC4Name.text = combatManager.playerParty.Lysithea.combatantName;

        enemy1Name.text = combatManager.enemy1.GetEnemy().combatantName;
        enemy2Name.text = combatManager.enemy2.GetEnemy().combatantName;
        enemy3Name.text = combatManager.enemy3.GetEnemy().combatantName;
        enemy4Name.text = combatManager.enemy4.GetEnemy().combatantName;

        PC1Health.text = combatManager.playerParty.Icarus.hp.ToString();
        PC2Health.text = combatManager.playerParty.Magnus.hp.ToString();
        PC3Health.text = combatManager.playerParty.Kena.hp.ToString();
        PC4Health.text = combatManager.playerParty.Lysithea.hp.ToString();

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
    }

    public void UpdateAttackPanel(Combatant combatant)
    {
        if(combatant.isAlly)
        {
            AttackPanel.SetActive(true);
        }
        else
        {
            AttackPanel.SetActive(false);
        }
    }
}
