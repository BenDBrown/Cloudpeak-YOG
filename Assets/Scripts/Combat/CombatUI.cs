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


    // Start is called before the first frame update
    void Start()
    {
        if (combatManager.AreWeFighting())
        {
            EnemyHealthDisplay.SetActive(true);
            DialogBox.SetActive(true);
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
