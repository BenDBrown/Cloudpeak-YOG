using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingAndUpdatingTheFloorNumbers : MonoBehaviour
{
    public NextFloor nextFloor;
    private int currentFloor;

    // Start is called before the first frame update
    void Start()
    {
        UpdateFloor();
        if (0 <= currentFloor && currentFloor < nextFloor.checkpointfloor1)
        {
            currentFloor = 1;
        }
        else if (nextFloor.checkpointfloor1 < currentFloor && currentFloor < nextFloor.checkpointfloor2 )
        {
            currentFloor = nextFloor.checkpointfloor1;
        }
        else if (currentFloor >= nextFloor.checkpointfloor2)
        {
            currentFloor = nextFloor.checkpointfloor2;
        }

    }

    // Update is called once per frame

    public void UpdateFloor()
    {
        currentFloor = nextFloor.FloorNumber;
        Debug.Log("Current Floor: " + currentFloor);
    }
    
    public void FloorToSetCurrent()
    {
        nextFloor.FloorNumber = currentFloor;
    }

    public void GoingUpAFloor()
    {
        currentFloor++;
        FloorToSetCurrent();
    }
    
    public int CurrentFloor()
    {
        return currentFloor;
    }
}
