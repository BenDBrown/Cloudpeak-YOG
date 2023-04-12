using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold = 9000;
    private List<Item> items = new List<Item>();
    public int level = 1;

    public void addItem(Item item, int price)
    {
        if(gold >= price)
        {
            gold -= price;
            Item newItem = gameObject.AddComponent(typeof(Item)) as Item;
            newItem.vitality = item.vitality;
            newItem.physicalAttack = item.physicalAttack;
            newItem.magicalAttack = item.magicalAttack;
            newItem.physicalDefense = item.physicalDefense;
            newItem.magicalDefense = item.magicalDefense;
            newItem.speed = item.speed;
            newItem.itemName = item.itemName;
            newItem.weapon = item.weapon;
            items.Add(newItem);
        }
    }


}
