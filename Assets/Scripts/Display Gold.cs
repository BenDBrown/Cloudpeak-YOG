using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayGold : MonoBehaviour
{
    int gameObject;
    int level;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI leveltxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject = GameObject.Find("Inventory").GetComponent<Inventory>().gold;
        textMeshProUGUI.text = "This is your gold: " + gameObject;

        level = GameObject.Find("Inventory").GetComponent<Inventory>().level;
        leveltxt.text = "This is your level: " + level;
    }
}
