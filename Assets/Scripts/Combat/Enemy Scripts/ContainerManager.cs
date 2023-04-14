using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    // the position of the enemy in the container
    public int position;

    private Combatant[] enemies;
    private Combatant loadedEnemy;

    private void Awake()
    {
        foreach(Combatant c in GetComponentsInChildren<Combatant>(true))
        {
            c.position = position;
        }
    }

    void OnEnable()
    {
        enemies = GetComponentsInChildren<Combatant>(true);

        int r = Random.Range(0, enemies.Length);
        Debug.Log("enemy selected at postion: " + r);
        enemies[r].gameObject.SetActive(true);
        loadedEnemy = enemies[r];
    }


    public Combatant GetEnemy()
    {
        return loadedEnemy;
    }
}
