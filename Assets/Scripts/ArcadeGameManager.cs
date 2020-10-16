using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ArcadeGameManager : MonoBehaviour
{

    public GameObject GameOverPanel;
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
        bestScoreText.text = PlayerPrefs.GetInt("ArcadeBestScore").ToString();
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
        PlayerPrefs.SetInt("AudioDestroyAmount", 2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void AddScore()
    {
        currentScore++;

        if (currentScore > PlayerPrefs.GetInt("ArcadeBestScore", 0))
        {
            PlayerPrefs.SetInt("ArcadeBestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }

        SetScore();
    }


    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }


}
