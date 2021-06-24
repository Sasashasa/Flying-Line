using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ArcadeGameManager : MonoBehaviour
{
    [Header("Компоненты")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    [Header("UI элементы")]
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Sprite[] planets;

    [Header("Вспомогательные поля")]
    private int _curScore = 0;


    private void Awake()
    {
        GameObject.Find("Hero").GetComponent<SpriteRenderer>().sprite = planets[PlayerPrefs.GetInt("SelectedSkin")];
    }


    private void Start()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume")/9;
        soundsSource.volume = (float)PlayerPrefs.GetInt("SoundsVolume")/9;

        bestScoreText.text = PlayerPrefs.GetInt("ArcadeBestScore").ToString();
    }


    public void CallGameOver()
    {
        StartCoroutine(WaitGameOver());
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void AddScore()
    {
        _curScore++;

        if (_curScore > PlayerPrefs.GetInt("ArcadeBestScore", 0))
        {
            PlayerPrefs.SetInt("ArcadeBestScore", _curScore);
            bestScoreText.text = _curScore.ToString();
        }

        SetScore();
    }

    private void SetScore()
    {
        currentScoreText.text = _curScore.ToString();
    }

    private IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
    }
}
