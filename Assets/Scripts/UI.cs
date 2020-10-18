using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public bool isPause = false;

    public void Start()
    {
        //PlayerPrefs.DeleteAll();
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
        isPause = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        isPause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }





    public void OpenLevel(int but_num) 
    {
        SceneManager.LoadScene(but_num);
    }



}
