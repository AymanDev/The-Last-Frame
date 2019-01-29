using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateController : MonoBehaviour
{
    public GameObject ratePanel;

    public static bool created = false;
    public static RateController instance;


    private void Awake()
    {
        if (PlayerPrefs.HasKey("Rated")) Destroy(gameObject);
        if (created) return;

        instance = this;
        DontDestroyOnLoad(gameObject);
        created = true;

    }

    public void ShownRatePanel()
    {
        if (PlayerPrefs.HasKey("Rated")) return;
        //ratePanel = GameObject.Find("RatePanel");
        ratePanel.SetActive(true);
    }


    public void RateOrCancelClick(int type)
    {
        if (type == 0)
        {
            Application.OpenURL("market://details?id=com.aymandev.lastframe");
        }
        PlayerPrefs.SetInt("Rated", 1);
        ratePanel.SetActive(false);
    }
}