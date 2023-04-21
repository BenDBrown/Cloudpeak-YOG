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
        if(combatant == null && containerManager.GetEnemy() != null)
        {
            Debug.Log("this should mean it works");
            gameObject.SetActive(true);
            nameSpace.text = containerManager.GetEnemy().combatantName;
            if(Mathf.RoundToInt(containerManager.GetEnemy().hp) != 0)
            {
                hp.text = Mathf.RoundToInt(containerManager.GetEnemy().hp).ToString();
            }
            else
            {
                hp.text = "0";
                gameObject.SetActive(false);
            }
        }
        else if (combatant == null && containerManager.GetEnemy() == null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            nameSpace.text = combatant.combatantName;
            if (Mathf.RoundToInt(combatant.hp) != 0)
            {
                hp.text = Mathf.RoundToInt(combatant.hp).ToString();
            }
            else
            {
                hp.text = "0";
                gameObject.SetActive(false);
            }  
        } 
    }

}
