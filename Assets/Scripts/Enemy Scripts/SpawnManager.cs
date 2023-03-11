using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //set this equal to how many enemies are in the container
    // EDIT THIS IN THE UNITY INSPECTOR NOT HERE
    public int SizeOfSpawnPool = 1;

    // enemies
    // You have to add the corresponding script for a new enemy here and
    // then drag the corresponding enemy onto the new value in the unity inspector
    public SpiderScript spider;
    public RatScript rat;

    // Start is called before the first frame update
    void Start()
    {
        int r = Random.Range(0, SizeOfSpawnPool);
        if(r == 0)
        {
            spider.gameObject.SetActive(true);
        }
        else if (r == 1)
        {
            rat.gameObject.SetActive(true);
        }
       
        
    }

}
