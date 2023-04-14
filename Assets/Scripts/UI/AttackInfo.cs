using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttackInfo : MonoBehaviour
{
    public CombatManager cm;
    public TextMeshProUGUI info;

    private int selectedAttack;

    public void UpdateInfo(int a)
    {
        Attack attack = cm.GetTurnCombatant().GetAttack(a);
        info.text = "Dmg mod: " + attack.dmgMod;
        if(attack.dmgInput == 0)
        {
            info.text += "\nused stat: Physical Attack"; 
        }
        else
        {
            info.text += "\nused stat: Magical Attack";
        }
        if(attack.dmgOutput == 0)
        {
            info.text += "\ndamage type: Physical";
        }
        else if(attack.dmgOutput == 1)
        {
            info.text += "\ndamage type: Magical";
        }
        else
        {
            info.text += "\ndamage type: n/a";
        }
        info.text += "\ntargets: ";
        foreach(int t in attack.Targets)
        {
            info.text += t + ", ";
        }
        if(attack.aoe)
        {
            info.text += "\naoe: yes";
        }
        else
        {
            info.text += "\naoe: no";
        }
        if(attack.GetStatusEffect() != null)
        {
            info.text += "\nhas secondary effect: yes, " + attack.GetStatusEffect().statusName;
        }
        else
        {
            info.text += "\nhas secondary effect: no";
        }
    }

}
