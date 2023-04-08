using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    // the position of the enemy in the container
    public int position;

    private Combatant[] enemies;
    private Combatant loadedEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        enemies = GetComponentsInChildren<Combatant>(true);

        int r = Random.Range(0, enemies.Length);
        Debug.Log(r);
        enemies[r].gameObject.SetActive(true);
        enemies[r].position = position;
        loadedEnemy = enemies[r];
    }


    public Combatant GetEnemy()
    {
        return loadedEnemy;
    }
}
