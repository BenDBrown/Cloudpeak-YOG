using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    public NextFloor floor;
    public TextMeshProUGUI floortxt;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        floortxt.text = "Floor: " + floor.FloorNumber;
    }
}
