using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    //set this equal to how many enemies are in the container
    // EDIT THIS IN THE UNITY INSPECTOR NOT HERE
    public int SizeOfSpawnPool = 1;

    // enemies
    // You have to add the corresponding script for a new enemy here and
    // then drag the corresponding enemy onto the new value in the unity inspector
    public Combatant enemy1;
    public Combatant enemy2;

    // Start is called before the first frame update
    void Awake()
    {
        int r = Random.Range(0, SizeOfSpawnPool);
        if (r == 0)
        {
            enemy1.gameObject.SetActive(true);
        }
        else if (r == 1)
        {
            enemy2.gameObject.SetActive(true);
        }


    }


    public Combatant GetEnemy()
    {
        if (enemy1.gameObject.activeSelf == true)
        {
            return enemy1;
        }
        else if (enemy2.gameObject.activeSelf == true)
        {
            return enemy2;
        }
        else
        {
            Debug.Log("Could not find enemy in container");
            return null;
        }

    }
}
