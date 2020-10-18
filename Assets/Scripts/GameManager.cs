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

    public AudioSource musicSource, soundsSource;


    public SimpleAds Ad;


    void Awake()
    {
        GameObject.Find("Player").GetComponent<SpriteRenderer>().sprite = planets[PlayerPrefs.GetInt("SelectedSkin")];
    }

    void Start()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 9;
        soundsSource.volume = (float)PlayerPrefs.GetInt("SoundsVolume") / 9;


        currentScore = 0;


        for (int i = 1; i <=20; i++) 
        {
            if (SceneManager.GetActiveScene().buildIndex == i)
            {
                bestScoreText.text = PlayerPrefs.GetInt("Lvl" + i + "BestScore").ToString(); 
            }
        }


        SetScore();
    }


    public void CallGameOver()
    {
        StartCoroutine(GameOver());
        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount", 0) + 1);
        PlayerPrefs.SetInt("DeathCount2", PlayerPrefs.GetInt("DeathCount2", 0) + 1);
        if (PlayerPrefs.GetInt("DeathCount") >= 30)
        {
            Ad.ShowAd();
        }
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


        for (int i = 1; i <= 20; i++) 
        {
            if (SceneManager.GetActiveScene().buildIndex == i) 
            {
                if (currentScore > PlayerPrefs.GetInt("Lvl" + i + "BestScore", 0)) 
                {
                    PlayerPrefs.SetInt("Lvl" + i + "BestScore", currentScore);
                    bestScoreText.text = currentScore.ToString();
                }
            }
        }


        SetScore();
    }


    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }


}
