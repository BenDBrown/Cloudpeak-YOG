using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanomizeBackground : MonoBehaviour
{
    public List<Sprite> sprites;
    private bool spawnbool = false;
    private SpriteRenderer SR;
    private Sprite BG1;
    private Sprite BG2;
    private Sprite BG3;
    private int BGnum1;
    private int BGnum2;
    private int BGnum3;
    private float setX0 = 1.5f;
    private float setX123 = 2f;
    private float SetX4 = 3f;
    private float SetY = 1.5f;
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spawnbool == false)
        {
            if (BG1 == null)
            {
                BGnum1 = Random.Range(0, sprites.Count);
                BG1 = sprites[BGnum1];
            }
            if (BG2 == null)
            {
                BGnum2 = Random.Range(0, sprites.Count);
                BG2 = sprites[BGnum2];
            }
            if (BG3 == null)
            {
                BGnum3 = Random.Range(0, sprites.Count);
                BG3 = sprites[BGnum3];
            }
            foreach (GameObject GB in GameObject.FindGameObjectsWithTag("Background"))
            {
                if (GB.name == "BGBlock1")
                {
                    SR = GB.GetComponent<SpriteRenderer>();
                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum1, SR, BG1, transform);

                }
                if (GB.name == "BGBlock2")
                {
                    SR = GB.GetComponent<SpriteRenderer>();

                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum2, SR, BG2,transform);
                }
                if (GB.name == "BGBlock3")
                {
                    SR = GB.GetComponent<SpriteRenderer>();

                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum3, SR, BG3,transform);
                }
            }

            spawnbool = true;
        }
        if (spawnbool == true)
        {
            foreach (GameObject GB in GameObject.FindGameObjectsWithTag("Background"))
            {
                if (GB.name == "BGBlock1")
                {
                    SR = GB.GetComponent<SpriteRenderer>();

                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum1, SR, BG1,transform);
                }
                if (GB.name == "BGBlock2")
                {
                    SR = GB.GetComponent<SpriteRenderer>();

                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum2, SR, BG2,transform);
                }
                if (GB.name == "BGBlock3")
                {
                    SR = GB.GetComponent<SpriteRenderer>();

                    transform = GB.GetComponent<Transform>();
                    ChangeBackGroundSize(BGnum3, SR, BG3,transform);
                }
            }
        }
    }

    void ChangeBackGroundSize(int BGnum, SpriteRenderer SR, Sprite sprite, Transform GO )
    {
        if(BGnum == 0)
        {
            GO.localScale =(new Vector3(setX0, SetY, 0));
            SR.sprite = sprite;
        }
        else if(BGnum == 1 || BGnum1 == 2)
        {
            GO.localScale=(new Vector3 (setX123, SetY, 0));
            SR.sprite = sprite;
        }
        else if(BGnum == 3)
        {
            GO.localScale=(new Vector3(SetX4, SetY, 0));
            SR.sprite = sprite;
        }
    }
}
