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
    }

    public void SelectItem(Item item)
    {
        selectedItem = item;
    }

    public void ShowStats(int i)
    {
        if (i == 1)
        {
            icarus.FightPrep();
            vitality.text = icarus.vitality.ToString();
            physicalA.text = icarus.physicalAttack.ToString();
            magicalA.text = icarus.magicalAttack.ToString();
            physicalD.text = icarus.physicalDefense.ToString();
            magicalD.text = icarus.magicalDefense.ToString();
            speed.text = icarus.speed.ToString();
            weaponSlot.combatant = icarus;
            armourSlot.combatant = icarus;
        }
        else if (i == 2)
        {
            magnus.FightPrep();
            vitality.text = magnus.vitality.ToString();
            physicalA.text = magnus.physicalAttack.ToString();
            magicalA.text = magnus.magicalAttack.ToString();
            physicalD.text = magnus.physicalDefense.ToString();
            magicalD.text = magnus.magicalDefense.ToString();
            speed.text = magnus.speed.ToString();
            weaponSlot.combatant = magnus;
            armourSlot.combatant = magnus;
        }
        else if (i == 3)
        {
            kena.FightPrep();
            vitality.text = kena.vitality.ToString();
            physicalA.text = kena.physicalAttack.ToString();
            magicalA.text = kena.magicalAttack.ToString();
            physicalD.text = kena.physicalDefense.ToString();
            magicalD.text = kena.magicalDefense.ToString();
            speed.text = kena.speed.ToString();
            weaponSlot.combatant = kena;
            armourSlot.combatant = kena;
        }
        else
        {
            lysithea.FightPrep();
            vitality.text = lysithea.vitality.ToString();
            physicalA.text = lysithea.physicalAttack.ToString();
            magicalA.text = lysithea.magicalAttack.ToString();
            physicalD.text = lysithea.physicalDefense.ToString();
            magicalD.text = lysithea.magicalDefense.ToString();
            speed.text = lysithea.speed.ToString();
            weaponSlot.combatant = lysithea;
            armourSlot.combatant = lysithea;
        }
    }

}
