using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetClick : MonoBehaviour
{
    private CombatManager combatManager;
    private CombatUI combatUI;
    private Combatant combatant;
    private bool isActive = false;

    void Awake()
    {
        combatManager = FindFirstObjectByType<CombatManager>();
        combatUI = FindFirstObjectByType<CombatUI>();
        combatant = GetComponent<Combatant>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            combatManager.PlayerAttack(combatant);
            combatUI.UpdateCursors();
        }
        
    }

    public void SetActivity(bool Active)
    {
        if(combatant.IsDead() == false)
        {
            isActive = Active;
        }
 
    }

}
