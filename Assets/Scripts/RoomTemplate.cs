using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    //These will be the arrays for a of the rooms we make

    public GameObject closedRooms;

    public List<GameObject> rooms;
    public float WaitTime;
    public GameObject Stairs;
    public bool spawnedStairs;
   

    private void Update()
    {
        if (WaitTime <= 0 && spawnedStairs == false)
        {
            
                Instantiate(Stairs, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                spawnedStairs = true;
            
        }
        else if (spawnedStairs == false)
        {
            WaitTime -= Time.deltaTime;
        }
    }
}
