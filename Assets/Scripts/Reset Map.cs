using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMap : MonoBehaviour
{
    private List<GameObject> rooms;
    private RoomTemplate templates;
    private GameObject stairs;
    private GameObject player;
    private bool spawnbool = true;
    public GameObject spawn;
    public GameObject SpawnRoom;
    private GameObject SpawnedRoom;
    private PlayerMapSpawner PS;
    private RoomTemplate TS;
    private GameObject[] closedwalls;
    public GameObject PSpawnerRoom;
    private SpriteRenderer SR;
    private roomspawner rs;
    // Start is called before the first frame update
    void Start()
    {
       
        PS = GameObject.Find("PlayerSpawner").GetComponent<PlayerMapSpawner>();
        TS = GameObject.Find("RoomTemplate").GetComponent<RoomTemplate>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void RemoveRooms()
    {
        closedwalls = GameObject.FindGameObjectsWithTag("ClosedWall");
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        rooms = templates.rooms;
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        stairs = GameObject.Find("Stair(Clone)").gameObject;
        foreach (GameObject room in rooms)
        {
            
                Destroy(room);
        }
        if (closedwalls != null)
        {
            foreach (GameObject CW in closedwalls)
            {
                Destroy(CW);
            }
        }
       
        Debug.Log("PLAYER DIE");
        Destroy(player);
        Destroy(stairs);
        rooms.Clear();
        spawnbool = false;
        
    }

    public void SpawnSpawnroom()
    {
        if (spawnbool == false)
        {

            foreach (roomspawner roomspawner in PSpawnerRoom.GetComponentsInChildren<roomspawner>())
            {
                if (roomspawner.openingDirection != 0)
                {
                    roomspawner.spawned = false;
                    roomspawner.StartSpawn();
                }
            }
           
            
            templates.spawnedStairs = false;
            PS.waitTime = 1f;
            PS.Playerspawned = false;
            TS.WaitTime = 5f;
            TS.spawnedStairs = false;
           

        }
    }
}
