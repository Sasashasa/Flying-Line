using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

    public bool isPause = false;

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















    public void Level1() 
    {
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(3);
    }

    public void Level4()
    {
        SceneManager.LoadScene(4);
    }

    public void Level5()
    {
        SceneManager.LoadScene(5);
    }

    public void Level6()
    {
        SceneManager.LoadScene(6);
    }

    public void Level7()
    {
        SceneManager.LoadScene(7);
    }

    public void Level8()
    {
        SceneManager.LoadScene(8);
    }

    public void Level9()
    {
        SceneManager.LoadScene(9);
    }

    public void Level10()
    {
        SceneManager.LoadScene(10);
    }



}
