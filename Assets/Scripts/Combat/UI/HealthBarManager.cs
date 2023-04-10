using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBarManager : MonoBehaviour
{
    public TextMeshProUGUI nameSpace;
    public TextMeshProUGUI hp;

    public Combatant combatant;
    public ContainerManager containerManager;

    public void UpdateText()
    {
        if(combatant == null)
        {
            nameSpace.text = containerManager.GetEnemy().combatantName;
            hp.text = containerManager.GetEnemy().hp.ToString();
        }
        else
        {
            nameSpace.text = combatant.combatantName;
            hp.text = combatant.hp.ToString();
        } 
    }

}
