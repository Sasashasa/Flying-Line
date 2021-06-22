using UnityEngine;
using UnityEngine.UI;

public class SetUpLevelsPanel : MonoBehaviour
{
    [SerializeField] private Sprite activeStarSprite;
    [SerializeField] private Sprite disactiveStarSprite;
    [SerializeField] private Button[] lvlsButtons;


    private void Start()
    {
        OpenLevels();
        SetStars();
    }

    private void OpenLevels() 
    {
        if (!PlayerPrefs.HasKey("LvlsPassed")) 
        {
            PlayerPrefs.SetInt("LvlsPassed", 0);
        }


        for (int i = 0; i < lvlsButtons.Length; i++)
        {
            if (i <= PlayerPrefs.GetInt("LvlsPassed"))
            {
                lvlsButtons[i].interactable = true;
            }
            else
            {
                lvlsButtons[i].interactable = false;
            }
        }
    }

    private void SetStars() 
    {
        for (int i = 1; i <= lvlsButtons.Length; i++) 
        {
            if (PlayerPrefs.HasKey($"Lvl{i}Stars")) 
            {
                int levelStars = PlayerPrefs.GetInt($"Lvl{i}Stars");

                for (int j = 1; j <= levelStars; j++) 
                {
                    lvlsButtons[i-1].transform.GetChild(j).GetComponent<Image>().sprite = activeStarSprite;
                }
            }
            else 
            {
                for (int j = 1; j <= 3; j++)
                {
                    lvlsButtons[i - 1].transform.GetChild(j).gameObject.SetActive(false);
                }
            }
        }
    }
}
