using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public void Start()
    {
        Time.timeScale = 1f;
    }
    
    public void Exit()
    {
        Application.Quit();
    }


    public void ArcadeMode()
    {
        SceneManager.LoadScene("ArcadeMode");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }


    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
