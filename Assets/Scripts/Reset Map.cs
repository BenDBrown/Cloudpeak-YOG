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
    private PlayerMapSpawner PS;
    private RoomTemplate TS;
    private GameObject[] closedwalls;
    public GameObject PSpawnerRoom;
    public NextFloor nextFloor;
    public GameObject bossroomPre;
    private GameObject Bossroom;
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
        if (nextFloor.boss1floor == nextFloor.FloorNumber || nextFloor.boss2floor == nextFloor.FloorNumber) 
        {
            Bossroom = GameObject.Find("Bossroom(Clone)");
            Destroy(Bossroom);

        }
        if (nextFloor.boss1floor != nextFloor.FloorNumber || nextFloor.boss2floor != nextFloor.FloorNumber)
        {
            closedwalls = GameObject.FindGameObjectsWithTag("ClosedWall");
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
            rooms = templates.rooms;
            player = GameObject.FindGameObjectWithTag("Player").gameObject;
            if (GameObject.Find("Stair(Clone)") != null)
            {
                stairs = GameObject.Find("Stair(Clone)").gameObject;
            }
            if (rooms != null)
            {
                foreach (GameObject room in rooms)
                {

                    Destroy(room);
                }
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
            
        }
        spawnbool = false;
    }

    public void SpawnSpawnroom()
    {
        Debug.Log("CurrentFloor: " + nextFloor.FloorNumber + "\nBossFloor: " + nextFloor.boss1floor);
        if (spawnbool == false && nextFloor.boss1floor != nextFloor.FloorNumber && nextFloor.boss2floor != nextFloor.FloorNumber)
        {
            if (PSpawnerRoom.active == false)
            {
                PSpawnerRoom.SetActive(true);
            }
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

        if (nextFloor.boss1floor == nextFloor.FloorNumber || nextFloor.boss2floor == nextFloor.FloorNumber)
        {
            PSpawnerRoom.SetActive(false);
            Instantiate(bossroomPre, PSpawnerRoom.transform.position, Quaternion.identity);
            
        }
    }
}
