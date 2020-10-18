using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings_Sliders : MonoBehaviour
{

    public Slider musicSlider, soundsSlider;
    public Text musicText, soundsText;

    public AudioSource musicSource, soundsSource;

    void Start()
    {

        if (!PlayerPrefs.HasKey("MusicVolume")) 
        {
            PlayerPrefs.SetInt("MusicVolume", 3);
        }

        if (!PlayerPrefs.HasKey("SoundsVolume"))
        {
            PlayerPrefs.SetInt("SoundsVolume", 8);
        }


        musicSlider.value = PlayerPrefs.GetInt("MusicVolume");
        soundsSlider.value = PlayerPrefs.GetInt("SoundsVolume");


    }

    
    void Update()
    {
        musicSource.volume = (float)PlayerPrefs.GetInt("MusicVolume") / 9;
        soundsSource.volume = (float)PlayerPrefs.GetInt("SoundsVolume") / 9;


        PlayerPrefs.SetInt("MusicVolume", (int)musicSlider.value);
        PlayerPrefs.SetInt("SoundsVolume", (int)soundsSlider.value);

        musicText.text = musicSlider.value.ToString();
        soundsText.text = soundsSlider.value.ToString();
    }
}
