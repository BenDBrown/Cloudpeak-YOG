using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplate template;
    // Start is called before the first frame update
    void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        template.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
