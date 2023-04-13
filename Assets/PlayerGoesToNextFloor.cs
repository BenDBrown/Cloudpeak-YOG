using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoesToNextFloor : MonoBehaviour
{
    private GoingToTheNextFloor GTTNF;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ReloadLevel");
            GTTNF = GameObject.Find("FloorCounter").GetComponent<GoingToTheNextFloor>();
            GTTNF.GoingToNextFloor();
        }
    }
}
