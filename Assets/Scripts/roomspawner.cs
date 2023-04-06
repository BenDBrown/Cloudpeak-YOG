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
    private bool spawned = false;

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
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //Need to spawn room with bottom door
                Instantiate(templates.bottomRooms[Random.Range(0, templates.bottomRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn room with top door
                Instantiate(templates.topRooms[Random.Range(0, templates.topRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn room with Left door
                Instantiate(templates.leftRooms[Random.Range(0, templates.leftRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn room with right door
                Instantiate(templates.rightRooms[Random.Range(0, templates.rightRooms.Length)], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //this is to prevent rooms spawning in eachother
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<roomspawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
