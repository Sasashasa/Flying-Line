using UnityEngine;
using UnityEngine.UI;

public class SetUpSettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    [SerializeField] private Text musicText;
    [SerializeField] private Text soundsText;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundsSource;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetInt("MusicVolume", 3);
        soundsSlider.value = PlayerPrefs.GetInt("SoundsVolume", 8);

        ChangeMusicValue();
        ChangeSoundsValue();
    }


    public void ChangeMusicValue() 
    {
        int value = (int)musicSlider.value;

        PlayerPrefs.SetInt("MusicVolume", value);
        musicSource.volume = (float) value / 9;
        musicText.text = value.ToString();
    }


    public void ChangeSoundsValue()
    {
        int value = (int)soundsSlider.value;

        PlayerPrefs.SetInt("SoundsVolume", value);
        soundsSource.volume = (float) value / 9;
        soundsText.text = value.ToString();
    }
}
