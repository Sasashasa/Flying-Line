using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Игровые объекты")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    [Header("UI элементы")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Sprite[] planets;

    [Header("Вспомогательные поля")]
    private int _curScore = 0;
    private int _bestScore;
    private int _curScene;


    private void Awake()
    {
        GameObject.Find("Hero").GetComponent<SpriteRenderer>().sprite = planets[PlayerPrefs.GetInt("SelectedSkin")];
    }

    private void Start()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 9;
        soundsSource.volume = (float)PlayerPrefs.GetInt("SoundsVolume") / 9;

        _curScene = SceneManager.GetActiveScene().buildIndex;
        _bestScore = PlayerPrefs.GetInt($"Lvl{_curScene}BestScore", 0);

        bestScoreText.text = _bestScore.ToString();

        SetScore();
    }


    public void CallGameOver()
    {
        StartCoroutine(WaitGameOver());
    }


    public void AddScore()
    {
        _curScore++;

        if (_curScore > _bestScore) 
        {
            _bestScore = _curScore;
            PlayerPrefs.SetInt($"Lvl{_curScene}BestScore", _bestScore);
            bestScoreText.text = _bestScore.ToString();
        }

        SetScore();
    }


    public void ActicateWinPanel() 
    {
        winPanel.SetActive(true);
    }

    private void SetScore()
    {
        currentScoreText.text = _curScore.ToString();
    }

    private IEnumerator WaitGameOver()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverPanel.SetActive(true);
    }
}
