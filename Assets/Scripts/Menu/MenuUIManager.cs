using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadArcadeMode()
    {
        SceneManager.LoadScene("ArcadeMode");
    }

    public void LoadLevel(int but_num)
    {
        SceneManager.LoadScene(but_num);
    }
}
