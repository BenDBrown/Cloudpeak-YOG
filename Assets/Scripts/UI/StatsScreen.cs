using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsScreen : MonoBehaviour
{
    public Combatant icarus;
    public Combatant magnus;
    public Combatant kena;
    public Combatant lysithea;
    public Combatant selectedCombatant;
    public Inventory inventory;
    public ItemSlot weaponSlot;
    public ItemSlot armourSlot;

    public TextMeshProUGUI vitality;
    public TextMeshProUGUI physicalA;
    public TextMeshProUGUI magicalA;
    public TextMeshProUGUI physicalD;
    public TextMeshProUGUI magicalD;
    public TextMeshProUGUI speed;

    public Item selectedItem;

    private void OnEnable()
    {
        ShowStats(1);
        List<ItemSlot> slots = new List<ItemSlot>();
        int count = 0;
        foreach(Item i in inventory.GetItems())
        {
            slots[count].SetItem(i);
            count++;
        }
    }

    public void ShowStats(int i)
    {
        if (i == 1)
        {
            selectedCombatant = icarus;
            refreshStats(icarus);
        }
        else if (i == 2)
        {
            selectedCombatant = magnus;
            refreshStats(magnus);
        }
        else if (i == 3)
        {
            selectedCombatant = kena;
            refreshStats(kena);
        }
        else
        {
            selectedCombatant = lysithea;
            refreshStats(lysithea);
        }
    }

    public void refreshStats(Combatant c)
    {
        c.FightPrep();
        vitality.text = c.vitality.ToString();
        physicalA.text = c.physicalAttack.ToString();
        magicalA.text = c.magicalAttack.ToString();
        physicalD.text = c.physicalDefense.ToString();
        magicalD.text = c.magicalDefense.ToString();
        speed.text = c.speed.ToString();
    }

}
