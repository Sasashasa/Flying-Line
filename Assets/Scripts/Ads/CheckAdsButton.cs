using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAdsButton : MonoBehaviour
{
    public Button AdsButton;


    public void Update()
    {
        if(PlayerPrefs.GetInt("DeathCount2", 0) >= 40) 
        {
            AdsButton.gameObject.SetActive(true);
        }
        else 
        {
            AdsButton.gameObject.SetActive(false);
        }
    }

}
