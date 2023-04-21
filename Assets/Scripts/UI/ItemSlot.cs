using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private StatsScreen statsScreen;
    private Item item;

    public void Awake()
    {
        statsScreen = GetComponentInParent<StatsScreen>(true);
    }

    public void equipItem()
    {
        if(item != null)
        {
            statsScreen.selectedCombatant.EquipItem(item);
        }       
    }

    public void SetItem(Item i)
    {
        item = i;
    }
}
