using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClick : MonoBehaviour
{
    private CombatManager combatManager;
    private CombatUI combatUI;
    public int targetnr;

    void Awake()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        combatUI = FindFirstObjectByType<CombatUI>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("u have ifed");
            combatManager.PlayerAttack(targetnr);
        }
        
    }
}
