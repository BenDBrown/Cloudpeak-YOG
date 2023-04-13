using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour
{
    public Item shopSlot1;
    public Item shopSlot2;
    public Item shopSlot3;
    public Item shopSlot4;
    public Item shopSlot5;
    public Item shopSlot6;
    public Inventory inventory;

    private bool welcomeBack = false;

    public void SetupShop()
    {
        if (welcomeBack == false)
        {
            welcomeBack = true;
            RandomizeShopSlot(shopSlot1);
            RandomizeShopSlot(shopSlot2);
            RandomizeShopSlot(shopSlot3);
            RandomizeShopSlot(shopSlot4);
            RandomizeShopSlot(shopSlot5);
            RandomizeShopSlot(shopSlot6);
        }
    }

    void RandomizeShopSlot(Item shopSlot)
    {
        shopSlot.gameObject.SetActive(true);
        shopSlot.Randomize(inventory.level);
        shopSlot.gameObject.GetComponent<Image>().sprite = shopSlot.GetSprite();
    }

    public void BuyItem(int itemSlotOneToSix)
    {
        if(itemSlotOneToSix == 1)
        {
            int price = shopSlot1.GetQuality() * inventory.level;
            inventory.addItem(shopSlot1, price);
            RandomizeShopSlot(shopSlot1);
        }
        else if (itemSlotOneToSix == 2)
        {
            int price = shopSlot2.GetQuality() * inventory.level;
            inventory.addItem(shopSlot2, price);
            RandomizeShopSlot(shopSlot2);
        }
        else if (itemSlotOneToSix == 3)
        {
            int price = shopSlot3.GetQuality() * inventory.level;
            inventory.addItem(shopSlot3, price);
            RandomizeShopSlot(shopSlot3);
        }
        else if (itemSlotOneToSix == 4)
        {
            int price = shopSlot4.GetQuality() * inventory.level;
            inventory.addItem(shopSlot4, price);
            RandomizeShopSlot(shopSlot4);
        }
        else if (itemSlotOneToSix == 5)
        {
            int price = shopSlot5.GetQuality() * inventory.level;
            inventory.addItem(shopSlot5, price);
            RandomizeShopSlot(shopSlot5);
        }
        else if (itemSlotOneToSix == 6)
        {
            int price = shopSlot6.GetQuality() * inventory.level;
            inventory.addItem(shopSlot6, price);
            RandomizeShopSlot(shopSlot6);
        }
    }

}
