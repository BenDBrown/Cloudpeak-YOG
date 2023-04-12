using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool weapon = false;

    public string itemName;

    public float vitality = 0;
    public float physicalAttack = 0;
    public float magicalAttack = 0;
    public float physicalDefense = 0;
    public float magicalDefense = 0;
    public float speed = 0;

    public Item(int itemLevel)
    {
        //int itemLevelBottom = Random.Range();
        if (weapon)
        {
            int r = Random.Range(0, 2);
            if(r == 0)
            { 
                //physicalAttack = Random
            }
            else
            {

            }
        }
        else
        {

        }
    }
}
