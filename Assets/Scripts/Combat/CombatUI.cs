using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    public CombatManager combatManager;

    public GameObject AttackPanel;
    public GameObject EnemyHealthDisplay;
    public GameObject DialogBox;

    //// name spaces for player characters
    //public Text PC1Name;
    //public Text PC2Name;
    //public Text PC3Name;
    //public Text PC4Name;

    //// health for player characters
    //public Text PC1Health;
    //public Text PC2Health;
    //public Text PC3Health;
    //public Text PC4Health;

    //// name spaces for enemies
    //public Text enemy1Name;
    //public Text enemy2Name;
    //public Text enemy3Name;
    //public Text enemy4Name;

    //// health for enemy characters
    //public Text enemy1Health;
    //public Text enemy2Health;
    //public Text enemy3Health;
    //public Text enemy4Health;


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
