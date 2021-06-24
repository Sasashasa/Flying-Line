using UnityEngine;
using UnityEngine.UI;

public class SetUpSkinsPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] skinsCheckMarks;

    [SerializeField] private Image curHeroImage;

    [SerializeField] private Text curHeroConditionText;
    [SerializeField] private Text curHeroCostText;
    [SerializeField] private Text coinsAmountText;

    private int _tempIndex;
    private int _tempCost;

    private enum TextCondition {SELECTED, SELECT, BUY, SECRET}

    [System.Serializable]
    private struct Hero 
    {
        public Sprite sprite;
        public bool isSecret;
        public int cost;
    }

    [SerializeField] private Hero[] heroes;


    private void Start()
    {
        CountStarsAmount();
        CheckSecretSkins();

        PlayerPrefs.SetInt("UnlockSkin_0", 1);
        PlayerPrefs.SetInt("ButStatus", 1);
        _tempIndex = PlayerPrefs.GetInt("CurSelectedSkin", 0);

        curHeroImage.sprite = heroes[_tempIndex].sprite;

        curHeroConditionText.text = "SELECTED";

        coinsAmountText.text = PlayerPrefs.GetInt("CoinsAmount", 0).ToString();

        CheckUnlockSkin();
    }


    public void ChooseHero(int index) 
    {
        if (PlayerPrefs.GetInt($"UnlockSkin_{index}") == 1) //если скин открыт
        {
            curHeroCostText.gameObject.SetActive(false);
            curHeroImage.sprite = heroes[index].sprite;

            if (PlayerPrefs.GetInt("CurSelectedSkin") == index) //если скин уже выбран
            {
                curHeroConditionText.text = TextCondition.SELECTED.ToString();

                PlayerPrefs.SetInt("ButStatus", 1);
            }
            else //если скин не выбран
            {
                curHeroConditionText.text = TextCondition.SELECT.ToString();

                _tempIndex = index;

                PlayerPrefs.SetInt("ButStatus", 2);
            }
        }
        else //если скин закрыт
        {
            if (heroes[index].isSecret) //если скин секретный
            {
                curHeroCostText.gameObject.SetActive(false);
                curHeroConditionText.text = TextCondition.SECRET.ToString();
                curHeroImage.sprite = heroes[index].sprite;

                PlayerPrefs.SetInt("ButStatus", 1);
            }
            else //если скин открывается за монеты
            {
                curHeroCostText.gameObject.SetActive(true);
                curHeroConditionText.text = TextCondition.BUY.ToString();
                _tempIndex = index;
                curHeroImage.sprite = heroes[index].sprite;

                PlayerPrefs.SetInt("ButStatus", 3);

                _tempCost = heroes[index].cost;
                curHeroCostText.text = _tempCost.ToString();
            }
        }
    }

    public void SetHero() 
    {
        int butStatus = PlayerPrefs.GetInt("ButStatus");

        if (butStatus == 2) //если скин открыт, но не выбран
        {
            PlayerPrefs.SetInt("CurSelectedSkin", _tempIndex);
            curHeroConditionText.text = TextCondition.SELECTED.ToString();
        }
        else if (butStatus == 3) //если скин закрыт
        {
            int coinsAmount = PlayerPrefs.GetInt("CoinsAmount");

            if (coinsAmount >= _tempCost) 
            {
                coinsAmount -= _tempCost;
                coinsAmountText.text = coinsAmount.ToString();

                PlayerPrefs.SetInt("CoinsAmount", coinsAmount);
                PlayerPrefs.SetInt($"UnlockSkin_{_tempIndex}", 1);
                PlayerPrefs.SetInt("ButStatus", 2);

                curHeroConditionText.text = TextCondition.SELECT.ToString();

                curHeroCostText.gameObject.SetActive(false);
                skinsCheckMarks[_tempIndex].SetActive(true);
            }
        }
    }


    private void CountStarsAmount()
    {
        PlayerPrefs.SetInt("StarsAmount", 0);

        for (int i = 1; i <= 20; i++)
        {
            int stars = PlayerPrefs.GetInt($"Lvl{i}Stars");

            PlayerPrefs.SetInt("StarsAmount", PlayerPrefs.GetInt("StarsAmount") + stars);
        }
    }

    private void CheckSecretSkins() 
    {
        int lvlsPassed = PlayerPrefs.GetInt("LvlsPassed");

        if (lvlsPassed >= 5) 
        {
            PlayerPrefs.SetInt("UnlockSkin_10", 1);
        }

        if (lvlsPassed >= 10) 
        {
            PlayerPrefs.SetInt("UnlockSkin_11", 1);
        }

        if (lvlsPassed >= 15) 
        {
            PlayerPrefs.SetInt("UnlockSkin_12", 1);
        }

        if (lvlsPassed >= 20) 
        {
            PlayerPrefs.SetInt("UnlockSkin_13", 1);
        }

        if (PlayerPrefs.GetInt("CrownsAmount") >= 60) 
        {
            PlayerPrefs.SetInt("UnlockSkin_14", 1);
        }

        if (PlayerPrefs.GetInt("ArcadeBestScore") >= 80) 
        {
            PlayerPrefs.SetInt("UnlockSkin_15", 1);
        }
    }


    private void CheckUnlockSkin()
    {
        for (int i = 0; i < skinsCheckMarks.Length; i++)
        {
            if (PlayerPrefs.GetInt($"UnlockSkin_{i}", 0) == 1)
            {
                skinsCheckMarks[i].SetActive(true);
            }
            else
            {
                skinsCheckMarks[i].SetActive(false);
            }
        }
    }
}
