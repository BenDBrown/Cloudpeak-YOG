using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShopButton : MonoBehaviour
{
    public GameObject button;
    public CombatManager combatManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!combatManager.AreWeFighting())
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }
}
