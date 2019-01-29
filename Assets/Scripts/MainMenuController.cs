using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Slider audioSlider;
    public GameObject optionsPanel;
    public GameObject creditsPanel;
    public Text lastScoreText;
    public Text gyroscopeText;

    private void Start()
    {
        audioSlider.value = AudioListener.volume;

        if (PlayerPrefs.HasKey("Last"))
        {
            lastScoreText.text = "Лучший рекорд: " + PlayerPrefs.GetInt("Last");
        }

        if (PlayerPrefs.HasKey("Gyro"))
        {
            var gyroVal = PlayerPrefs.GetInt("Gyro");

            if (gyroVal == 0)
                gyroscopeText.text = "Выключен";
            if (gyroVal == 1)
                gyroscopeText.text = "Включен";
        }
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickOptionPanel()
    {
        optionsPanel.SetActive(!optionsPanel.activeSelf);
        creditsPanel.SetActive(false);
    }
    
    public void ClickCreditsPanel()
    {
        creditsPanel.SetActive(!creditsPanel.activeSelf);
        optionsPanel.SetActive(false);
    }
    
    public void ClockCreditsButton(string url)
    {
        Application.OpenURL(url);
    }


    public void ClickGyroscopeButton()
    {
        if (Input.gyro == null) return;
        var gyroVal = 0;
        if (PlayerPrefs.HasKey("Gyro")) gyroVal = PlayerPrefs.GetInt("Gyro");

        if (gyroVal == 0)
        {
            gyroVal = 1;
            gyroscopeText.text = "Включен";
        }
        else if (gyroVal == 1)
        {
            gyroVal = 0;
            gyroscopeText.text = "Выключен";
        }

        PlayerPrefs.SetInt("Gyro", gyroVal);
    }

    public void AudioSlider(float value)
    {
        AudioListener.volume = value;
    }
}