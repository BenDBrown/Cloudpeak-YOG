using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMapMovement : MonoBehaviour
{
    public GameObject Player;
    public static RaycastHit2D hit; //this is the raycast
    private float startLocationY;
    private float startLocationX;
    private float startLocationMY;
    private float startLocationMX;

    private Vector3 v3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startLocationY = Player.transform.position.y + 1;
        startLocationX = Player.transform.position.x + 1;
        startLocationMY = Player.transform.position.y - 1;
        startLocationMX = Player.transform.position.x - 1;


        Debug.DrawRay(Player.transform.position, Vector2.up * 11f, Color.red);
        if (Input.GetKeyDown(KeyCode.W))
        {

            v3.Set(Player.transform.position.x, startLocationY, 0);
            Debug.Log("W is down");
            hit = Physics2D.Raycast(v3, Vector2.up, 10f, LayerMask.GetMask("Default"));

            if ( hit.collider!=null)
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Wall")
                {

                }
                else
                {
                    //hit something, print what you hit.
                    Debug.Log("Hitting: " + hit.collider.name);
                    Debug.Log(hit.transform.position.y + "  Y positon");
                    Player.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y);
                }

            }
          
        }

        if (Input.GetKeyDown(KeyCode.A))
        {

            v3.Set(startLocationMX, Player.transform.position.y, 0);
            Debug.Log("A is down");
            hit = Physics2D.Raycast(v3, Vector2.left, 10f, LayerMask.GetMask("Default"));

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Wall")
                {

                }
                else
                {

                    //hit something, print what you hit.
                    Debug.Log("Hitting: " + hit.collider.name);
                    Debug.Log(hit.transform.position.y + "  Y positon");
                    Player.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y);

                }
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            v3.Set(Player.transform.position.x, startLocationMY, 0);
            Debug.Log("S is down");
            hit = Physics2D.Raycast(v3, Vector2.down, 10f, LayerMask.GetMask("Default"));

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Wall")
                {

                }
                else
                {
                    //hit something, print what you hit.
                    Debug.Log("Hitting: " + hit.collider.name);
                    Debug.Log(hit.transform.position.y + "  Y positon");
                    Player.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            v3.Set(startLocationX, Player.transform.position.y, 0);
            Debug.Log("D is down");
            hit = Physics2D.Raycast(v3, Vector2.right, 10f, LayerMask.GetMask("Default"));

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Wall")
                {

                }
                else
                {
                    //hit something, print what you hit.
                    Debug.Log("Hitting: " + hit.collider.name);
                    Debug.Log(hit.transform.position.y + "  Y positon");
                    Player.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y);
                }

            }

        }
    }
}
