using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spawnroom;
    public float waitTime;
    public GameObject player;
    public bool Playerspawned;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0 && Playerspawned == false)
        {
            Instantiate(player, Spawnroom.transform.position, Quaternion.identity);
            Playerspawned = true;
        }
        else if (Playerspawned == false)
        {
            waitTime -= Time.deltaTime;
        }
    }
    
    
}
