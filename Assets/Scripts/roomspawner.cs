using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomspawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> need bottom door
    //2 --> need top door
    //3 --> need left door
    //4 --> need right door

    private RoomTemplate templates;
    private int rand;
    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
 
        Invoke("Spawn", 0.1f);
        //this is to prevent rooms spawning in eachother by not having collition yet due to spawning to fast
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                //Need to spawn room with bottom door
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                //Need to spawn room with top door
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                // Need to spawn room with Left door
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                // Need to spawn room with right door
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 0)
            {
                spawned = true;
            }
            spawned = true;
        }

    }

    public void StartSpawn()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();

        Invoke("Spawn", 0.1f);
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        //this is to prevent rooms spawning in eachother
        if (collision.CompareTag("Spawnpoint"))
        {
            if(collision.GetComponent<roomspawner>().spawned == false && spawned == false && collision.GetComponent<roomspawner>().openingDirection !=0)
            {
                Instantiate(templates.closedRooms, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
                //spawn a wall 
            }
            spawned = true;
        }
        else if (collision.CompareTag("Interior") || collision.CompareTag("Spawn"))
        {
            spawned = true;
        }
        
    }
}
