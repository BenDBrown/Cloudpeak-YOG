using UnityEngine;

public class WallsShowOnPlayerEnter : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag=="Player")
    //    {
    //        Debug.Log("Player in room");
    //        foreach (SpriteRenderer SR in GetComponentsInChildren<SpriteRenderer>())
    //        {
    //            SR.enabled = true;
    //        }
    //    }
    //    if (collision.gameObject.tag=="Spawnpoint")
    //    {
    //        Debug.Log("Spawnpoint being hit");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player in room");
            foreach (SpriteRenderer SR in GetComponentsInChildren<SpriteRenderer>())
            {
                SR.enabled = true;
            }
        }
        if (collision.CompareTag("Spawnpoint"))
        {

        }

    }
}
