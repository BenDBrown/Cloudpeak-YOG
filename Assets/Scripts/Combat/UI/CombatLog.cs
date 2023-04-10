using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CombatLog : MonoBehaviour
{
    public ScrollRect scrollView;

    private string log;

    public void AddAttackersStory(Combatant attacker, Attack usedAttack, List<Combatant> defenders)
    {
        DefaultControls.Resources TempResource = new DefaultControls.Resources();
        GameObject NewText = DefaultControls.CreateText(TempResource);
        NewText.AddComponent<LayoutElement>();

    }



    void PublishLog(Combatant attacker, List<Combatant> defenders)
    {

    }

}
