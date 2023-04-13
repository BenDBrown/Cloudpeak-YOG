using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int gold = 10;
    private List<Item> items = new List<Item>();
    public int level = 1;
    public InventorySO inventorySO;

    public Item sample;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    //private void Start()
    //{
    //    IntoInventory();
    //}
    public void addItem(Item item, int price)
    {
        if(gold >= price)
        {
            gold -= price;
            //inventorySO.gold = gold;
            Item newItem = gameObject.AddComponent(typeof(Item)) as Item;
            newItem.vitality = item.vitality;
            newItem.physicalAttack = item.physicalAttack;
            newItem.magicalAttack = item.magicalAttack;
            newItem.physicalDefense = item.physicalDefense;
            newItem.magicalDefense = item.magicalDefense;
            newItem.speed = item.speed;
            newItem.itemName = item.itemName;
            newItem.weapon = item.weapon;
            newItem.SetSprite(item.GetSprite());
            items.Add(newItem);
        }
    }

    //public void LevelIntoSo()
    //{

    //    inventorySO.level = level;

    //}

    //public void IntoInventory()
    //{
    //    this.gold = inventorySO.gold;
    //    this.level = inventorySO.level;
    //    foreach(Item I in inventorySO.items)
    //    {
    //        addItem(I, 0);
    //    }
    //    Debug.Log("Into Inventory");
    //}

    //public void GoldIntoSo()
    //{
    //    inventorySO.gold = gold;
    //}

    public void Saveitems(List<string> itemType, List<int> vitality, List<int> physicalAttack, List<int> magicalAttack, List<int> physicalDefense, List<int> magicalDefense, List<int> speed, List<bool> weapon, List<string> itemName, List<int> spritePosition)
    {
        for(int I = 0; I < itemType.Count; I++)
        {
            Item newItem = gameObject.AddComponent(typeof(Item)) as Item;
            newItem.vitality = vitality[I];
            newItem.physicalAttack = physicalAttack[I];
            newItem.magicalAttack = magicalAttack[I];
            newItem.physicalDefense = physicalDefense[I];
            newItem.magicalDefense = magicalDefense[I];
            newItem.speed = speed[I];
            newItem.itemName = itemName[I];
            newItem.weapon = weapon[I];
            newItem.spritePosition = spritePosition[I];
            newItem.SetSprite(sample.GetSpriteList(itemType[I])[spritePosition[I]]);
            items.Add(newItem);
        }
    }

}
