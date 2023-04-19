using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    SceneManager manager;
    Inventory Inventory;
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GoToCombat()
    {
        
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }

    public void GoToShop()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
   
    }
}
