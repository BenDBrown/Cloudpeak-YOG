using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombatLog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public ScrollRect scrollRect;

    private string log;

    public void AddAttackersStory(Combatant attacker, Attack usedAttack, Combatant defender)
    {

        if (usedAttack.aoe)
        {
            log = attacker.combatantName + " used " + usedAttack.attackName;
            PublishLog();
        }
        else
        {
            log = attacker.combatantName + " used " + usedAttack.attackName + " on " + defender.combatantName;
            PublishLog();
        }

    }

    public void AddDefendersStory(Combatant defender, int damageTaken, StatusEffect status, bool stunned)
    {
        if(damageTaken == 0 && status != null)
        {
            log = defender.combatantName + " became " + status.statusName;  
        }
        else if(damageTaken > 0 && status != null)
        {
            log = defender.combatantName + " took " + damageTaken + " damage and became " + status.statusName;
        }
        else if(damageTaken < 0 && status != null)
        {
            log = defender.combatantName + " was healed for " + damageTaken + " hp and became " + status.statusName;
        }
        else if(damageTaken < 0 && status == null)
        {
            log = defender.combatantName + " was healed for " + damageTaken + " hp";
        }
        else if(damageTaken > 0 && status == null)
        {
            log = defender.combatantName + " took " + damageTaken + " damage";
        }
        else
        {
            log = defender.combatantName + " was unaffected";
        }
        PublishLog();
        if(stunned)
        {
            log = defender.combatantName + " was stunned";
            PublishLog();
        }
        if(defender.IsDead() && defender.isAlly)
        {
            log = defender.combatantName + " was teleported back to town";
            PublishLog();
        }
        else if (defender.IsDead() && defender.isAlly == false)
        {
            log = defender.combatantName + " died";
            PublishLog();
        }
    }


    void PublishLog()
    {
        text.text += "\n" + log;
        scrollRect.verticalScrollbar.value = 0;
        Debug.Log(scrollRect.verticalScrollbar.value);
    }

}
