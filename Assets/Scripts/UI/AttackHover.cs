using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHover : MonoBehaviour
{
    public int attack;
    public AttackInfo attackInfo;
    private void OnMouseEnter()
    {
        attackInfo.gameObject.SetActive(true);
        attackInfo.UpdateInfo(attack);
    }
    private void OnMouseExit()
    {
        attackInfo.gameObject.SetActive(false);
    }
}
