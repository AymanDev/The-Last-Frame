using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Sprite greenHealth;
    public Sprite yellowHealth;
    public Sprite redHealth;

    public Image image;

    public GameObject deathScreen;

    public static UI instance;

    public GameObject screenController;
    public GameObject gyroController;

    private void Start()
    {
        instance = this;

        if (!PlayerPrefs.HasKey("Gyro")) return;
        var gyroVal = PlayerPrefs.GetInt("Gyro");

        if (gyroVal != 1) return;
        gyroController.SetActive(true);
        screenController.SetActive(false);
    }


    public void UpdateHealthUi()
    {
        switch (PlayerController.instance.health)
        {
            case 1:
                image.sprite = redHealth;
                break;
            case 2:
                image.sprite = yellowHealth;
                break;
            case 3:
                image.sprite = greenHealth;
                break;
            default:
                image.sprite = redHealth;
                break;
        }
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }

    public void LogoutToMainMenu()
    {
        SceneManager.LoadScene(0);
        RateController.instance.ShownRatePanel();
    }
}