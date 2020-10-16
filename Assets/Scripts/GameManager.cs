using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverPanel;
    public GameObject WinPanel;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    int currentScore;

    public Sprite[] planets;


    void Awake()
    {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = planets[PlayerPrefs.GetInt("SelectedSkin")];
    }

    void Start()
    {
        currentScore = 0;




        if (SceneManager.GetActiveScene().buildIndex == 1) bestScoreText.text = PlayerPrefs.GetInt("Lvl1BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 2) bestScoreText.text = PlayerPrefs.GetInt("Lvl2BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 3) bestScoreText.text = PlayerPrefs.GetInt("Lvl3BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 4) bestScoreText.text = PlayerPrefs.GetInt("Lvl4BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 5) bestScoreText.text = PlayerPrefs.GetInt("Lvl5BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 6) bestScoreText.text = PlayerPrefs.GetInt("Lvl6BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 7) bestScoreText.text = PlayerPrefs.GetInt("Lvl7BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 8) bestScoreText.text = PlayerPrefs.GetInt("Lvl8BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 9) bestScoreText.text = PlayerPrefs.GetInt("Lvl9BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 10) bestScoreText.text = PlayerPrefs.GetInt("Lvl10BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 11) bestScoreText.text = PlayerPrefs.GetInt("Lvl11BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 12) bestScoreText.text = PlayerPrefs.GetInt("Lvl12BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 13) bestScoreText.text = PlayerPrefs.GetInt("Lvl13BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 14) bestScoreText.text = PlayerPrefs.GetInt("Lvl14BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 15) bestScoreText.text = PlayerPrefs.GetInt("Lvl15BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 16) bestScoreText.text = PlayerPrefs.GetInt("Lvl16BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 17) bestScoreText.text = PlayerPrefs.GetInt("Lvl17BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 18) bestScoreText.text = PlayerPrefs.GetInt("Lvl18BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 19) bestScoreText.text = PlayerPrefs.GetInt("Lvl19BestScore").ToString();
        if (SceneManager.GetActiveScene().buildIndex == 20) bestScoreText.text = PlayerPrefs.GetInt("Lvl20BestScore").ToString();




        SetScore();
    }


    void Update()
    {

    }


    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void AddScore()
    {
        currentScore++;


        if (SceneManager.GetActiveScene().buildIndex == 1) 
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl1BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl1BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl2BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl2BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl3BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl3BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl4BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl4BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl5BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl5BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl6BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl6BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl7BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl7BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl8BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl8BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl9BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl9BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl10BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl10BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl11BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl11BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 12)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl12BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl12BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl13BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl13BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl14BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl14BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 15)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl15BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl15BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl16BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl16BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 17)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl17BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl17BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl18BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl18BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 19)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl19BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl19BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            if (currentScore > PlayerPrefs.GetInt("Lvl20BestScore", 0))
            {
                PlayerPrefs.SetInt("Lvl20BestScore", currentScore);
                bestScoreText.text = currentScore.ToString();
            }
        }




        SetScore();
    }


    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }


}
