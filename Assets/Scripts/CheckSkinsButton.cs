using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class CheckSkinsButton : MonoBehaviour
{

    public Button[] skins;

    public Sprite[] sprites;

    public Image planetImage;
    public Text mainText, costText;
    public GameObject cost;

    [SerializeField] private int temporary_index;
    [SerializeField] private int temporary_cost;

    public int Money;

    void Start()
    {
        PlayerPrefs.SetInt("MoneyAmount", Money);

 
        CheckSecretSkins();



        if (!PlayerPrefs.HasKey("ButStatus"))
        {
            PlayerPrefs.SetInt("ButStatus", 1);
        }


        if (!PlayerPrefs.HasKey("SelectedSkin"))
        {
            PlayerPrefs.SetInt("SelectedSkin", 0);
        }


        if (!PlayerPrefs.HasKey("UnlockSkin_0")) 
        {
            PlayerPrefs.SetInt("UnlockSkin_0", 1);
        }


        temporary_index = PlayerPrefs.GetInt("SelectedSkin");
        planetImage.sprite = sprites[temporary_index];
        PlayerPrefs.SetInt("ButStatus", 1);
        mainText.text = "SELECTED";



        CheckUnlockSkin();
    }

   

    public void CheckUnlockSkin() 
    {
        for (int i = 0; i < skins.Length; i++) 
        {
            if (PlayerPrefs.GetInt("UnlockSkin_" + i) == 1) 
            {
                skins[i].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            else 
            {
                skins[i].gameObject.transform.GetChild(0).gameObject.SetActive(false);
                PlayerPrefs.SetInt("UnlockSkin_" + i, 0);
            }
        }
    }



    //для кнопок

    public void ChangeButton(int but_index) 
    {
        if (PlayerPrefs.GetInt("UnlockSkin_" + but_index) == 1)     //если скин открыт
        {
            if (PlayerPrefs.GetInt("SelectedSkin") == but_index)        //если скин уже выбран
            {
                cost.SetActive(false);
                mainText.text = "SELECTED";
                PlayerPrefs.SetInt("ButStatus", 1);
                planetImage.sprite = sprites[but_index];
            }
            else    //если скин не выбран
            {
                cost.SetActive(false);
                mainText.text = "SELECT";
                PlayerPrefs.SetInt("ButStatus", 2);
                temporary_index = but_index;
                planetImage.sprite = sprites[but_index];
            }
        }
        else    //если скин закрыт
        {
            if (but_index >=1 && but_index <=9) //если скин открывается за монетки
            {
                cost.SetActive(true);
                mainText.text = "BUY";
                PlayerPrefs.SetInt("ButStatus", 3);
                temporary_index = but_index;
                planetImage.sprite = sprites[but_index];

                if (but_index == 1) 
                {
                    int costSkin = 10;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 2)
                {
                    int costSkin = 20;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 3)
                {
                    int costSkin = 40;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 4)
                {
                    int costSkin = 80;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 5)
                {
                    int costSkin = 150;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 6)
                {
                    int costSkin = 200;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 7)
                {
                    int costSkin = 250;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 8)
                {
                    int costSkin = 350;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }
                if (but_index == 9)
                {
                    int costSkin = 500;
                    temporary_cost = costSkin;
                    costText.text = costSkin.ToString();
                }





            }
            else //если секретный скин
            {
                cost.SetActive(false);
                mainText.text = "SECRET";
                PlayerPrefs.SetInt("ButStatus", 1);
                planetImage.sprite = sprites[but_index];
            }
        }





    }




    public void MainButton() 
    {


        if (PlayerPrefs.GetInt("ButStatus") == 2) //если скин открыт, но не выбран
        {
            PlayerPrefs.SetInt("SelectedSkin", temporary_index);
            mainText.text = "SELECTED";
            PlayerPrefs.SetInt("ButStatus", 2);
        }

        if (PlayerPrefs.GetInt("ButStatus") == 3)
        {
            if (PlayerPrefs.GetInt("MoneyAmount") >= temporary_cost) 
            {
                PlayerPrefs.SetInt("MoneyAmount", PlayerPrefs.GetInt("MoneyAmount") - temporary_cost);
                PlayerPrefs.SetInt("UnlockSkin_" + temporary_index, 1);
                cost.SetActive(false);
                mainText.text = "SELECT";
                PlayerPrefs.SetInt("ButStatus", 2);

                skins[temporary_index].gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
        }


    }



    public void CheckSecretSkins() 
    {
        if (PlayerPrefs.GetInt("LvlsPassed") == 5) PlayerPrefs.SetInt("UnlockSkin_10", 1);
        if (PlayerPrefs.GetInt("LvlsPassed") == 10) PlayerPrefs.SetInt("UnlockSkin_11", 1);
        if (PlayerPrefs.GetInt("LvlsPassed") == 15) PlayerPrefs.SetInt("UnlockSkin_12", 1);
        if (PlayerPrefs.GetInt("LvlsPassed") == 20) PlayerPrefs.SetInt("UnlockSkin_13", 1);
        if (PlayerPrefs.GetInt("CrownsAmount") == 60) PlayerPrefs.SetInt("UnlockSkin_14", 1);
        if (PlayerPrefs.GetInt("ArcadeBestScore") >= 80) PlayerPrefs.SetInt("UnlockSkin_15", 1);
    }




}
