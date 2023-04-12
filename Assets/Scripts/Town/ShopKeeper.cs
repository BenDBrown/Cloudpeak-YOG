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
        int level = inventory.level;
        if (welcomeBack == false)
        {
            welcomeBack = true;
            shopSlot1.gameObject.SetActive(true);
            shopSlot2.gameObject.SetActive(true);
            shopSlot3.gameObject.SetActive(true);
            shopSlot4.gameObject.SetActive(true);
            shopSlot5.gameObject.SetActive(true);
            shopSlot6.gameObject.SetActive(true);
            shopSlot1.Randomize(level);
            shopSlot2.Randomize(level);
            shopSlot3.Randomize(level);
            shopSlot4.Randomize(level);
            shopSlot5.Randomize(level);
            shopSlot6.Randomize(level);

            shopSlot1.gameObject.GetComponent<Image>().sprite = shopSlot1.GetSprite();
            shopSlot2.gameObject.GetComponent<Image>().sprite = shopSlot2.GetSprite();
            shopSlot3.gameObject.GetComponent<Image>().sprite = shopSlot3.GetSprite();
            shopSlot4.gameObject.GetComponent<Image>().sprite = shopSlot4.GetSprite();
            shopSlot5.gameObject.GetComponent<Image>().sprite = shopSlot5.GetSprite();
            shopSlot6.gameObject.GetComponent<Image>().sprite = shopSlot6.GetSprite();
        }
    }

    public void BuyItem(int itemSlotOneToSix)
    {
        if(itemSlotOneToSix == 1)
        {
            int price = shopSlot1.GetQuality() * inventory.level;
            inventory.addItem(shopSlot1, price);
        }
        else if (itemSlotOneToSix == 2)
        {
            int price = shopSlot2.GetQuality() * inventory.level;
            inventory.addItem(shopSlot2, price);
        }
        else if (itemSlotOneToSix == 3)
        {
            int price = shopSlot3.GetQuality() * inventory.level;
            inventory.addItem(shopSlot3, price);
        }
        else if (itemSlotOneToSix == 4)
        {
            int price = shopSlot4.GetQuality() * inventory.level;
            inventory.addItem(shopSlot4, price);
        }
        else if (itemSlotOneToSix == 5)
        {
            int price = shopSlot5.GetQuality() * inventory.level;
            inventory.addItem(shopSlot5, price);
        }
        else if (itemSlotOneToSix == 6)
        {
            int price = shopSlot6.GetQuality() * inventory.level;
            inventory.addItem(shopSlot6, price);
        }
    }

}
