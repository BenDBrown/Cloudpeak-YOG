using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private int position;

    public void SetPosition(int position)
    {
        this.position = position;
    }

    public int GetPostion()
    {
        return position;
    }

}
