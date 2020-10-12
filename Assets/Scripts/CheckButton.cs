using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{

    public Sprite star, noStar;

    public Button[] lvls;
    


    public void Start()
    {

        Open_lvl();

        Stars();

    }

    void Open_lvl() 
    {
        if (PlayerPrefs.HasKey("LvlsPassed"))
        {
            for (int i = 0; i < lvls.Length; i++)
            {
                if (i <= PlayerPrefs.GetInt("LvlsPassed"))
                    lvls[i].interactable = true;
                else
                    lvls[i].interactable = false;
            }
        }
        else 
        {
            lvls[0].interactable = true;

            for (int i = 1; i < lvls.Length; i++) 
            {
                lvls[i].interactable = false;
            }
        }
    }

    void Stars() 
    {

        for (int i = 1; i < lvls.Length + 1; i++) 
        {
            if (PlayerPrefs.HasKey("Lvl" + i + "Crowns")) 
            {
                if (PlayerPrefs.GetInt("Lvl" + i + "Crowns") == 1) 
                {
                    lvls[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = star;
                    lvls[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                    lvls[i - 1].transform.GetChild(3).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("Lvl" + i + "Crowns") == 2) 
                {
                    lvls[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = star;
                    lvls[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = star;
                    lvls[i - 1].transform.GetChild(3).GetComponent<Image>().sprite = noStar;
                }
                else if (PlayerPrefs.GetInt("Lvl" + i + "Crowns") == 3)
                {
                    lvls[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = star;
                    lvls[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = star;
                    lvls[i - 1].transform.GetChild(3).GetComponent<Image>().sprite = star;
                }
                else if (PlayerPrefs.GetInt("Lvl" + i + "Crowns") == 0)
                {
                    lvls[i - 1].transform.GetChild(1).GetComponent<Image>().sprite = noStar;
                    lvls[i - 1].transform.GetChild(2).GetComponent<Image>().sprite = noStar;
                    lvls[i - 1].transform.GetChild(3).GetComponent<Image>().sprite = noStar;
                }
            }
            else 
            {
                lvls[i - 1].transform.GetChild(1).gameObject.SetActive(false);
                lvls[i - 1].transform.GetChild(2).gameObject.SetActive(false);
                lvls[i - 1].transform.GetChild(3).gameObject.SetActive(false);
            }
        }


    }

}
