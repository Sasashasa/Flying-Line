using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    
    void Start()
    {
        if (PlayerPrefs.GetInt("DontDestroy", 1) == 1 || PlayerPrefs.GetInt("DontDestroy", 1) == 2) 
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0) Destroy(this.gameObject);
    }

    void Update()
    {
        
    }
}
