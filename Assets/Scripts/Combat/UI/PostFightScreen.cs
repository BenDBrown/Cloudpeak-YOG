using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PostFightScreen : MonoBehaviour
{
    public Inventory inventory;
    public int gold = 0;
    public TextMeshProUGUI textBox;

    private Item item;
    private void Awake()
    {
        item = GetComponentInChildren<Item>(true);
    }

    private void OnEnable()
    {
        item.Randomize(inventory.level);
        gold = Random.Range(5, inventory.level * 10);
        textBox.text = "you found a " + item.itemName + " and " + gold + "! \nclick on you item to collect it and continue";
    }

    public void buttonPress()
    {
        inventory.addItem(item, 0);
        inventory.gold += gold;
        gameObject.SetActive(false);
    }

}
