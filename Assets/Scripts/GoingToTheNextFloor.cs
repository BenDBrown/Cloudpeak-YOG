using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToTheNextFloor : MonoBehaviour
{
    public CheckingAndUpdatingTheFloorNumbers CAUTFN;
    public ResetMap RM;
    

    public void GoingToNextFloor()
    {
        CAUTFN = GameObject.Find("FloorCounter").GetComponent<CheckingAndUpdatingTheFloorNumbers>();
        RM = GameObject.Find("FloorCounter").GetComponent<ResetMap>();
        CAUTFN.GoingUpAFloor();
        RM.RemoveRooms();
        RM.SpawnSpawnroom();
        
    }
   
}
