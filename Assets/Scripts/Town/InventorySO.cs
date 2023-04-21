using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class InventorySO : ScriptableObject
{

    public List<string> itemType;
    public List<int> vitality;
    public List<int> physicalAttack;
    public List<int> magicalAttack;
    public List<int> physicalDefense;
    public List<int> magicalDefense;
    public List<int> speed;
    public List<bool> weapon;
    public List<string> itemName;
    public List<int> spritePositon;

    public void AddItemsToSO(List<Item> items)
    {
        itemType.Clear();
        vitality.Clear();
        physicalAttack.Clear();
        magicalAttack.Clear();
        physicalDefense.Clear();
        magicalDefense.Clear();
        speed.Clear();
        weapon.Clear();
        itemName.Clear();
        spritePositon.Clear();

        foreach (Item i in items)
        {
            vitality.Add(i.vitality);
            physicalAttack.Add(i.physicalAttack);
            magicalAttack.Add(i.magicalAttack);
            physicalDefense.Add(i.physicalDefense);
            magicalDefense.Add(i.magicalDefense);
            speed.Add(i.speed);
            itemType.Add(i.itemType);
            weapon.Add(i.weapon);
            itemName.Add(i.itemName);
            spritePositon.Add(i.spritePosition);
        }
    }
}
