using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Combatant combatant;
    public bool weapon = false;

    public void equipItem()
    {
        Item item = GetComponentInParent<StatsScreen>().selectedItem;
        if(combatant != null && item.weapon == weapon)
        {
            combatant.EquipItem(item);
        }
    }
}
