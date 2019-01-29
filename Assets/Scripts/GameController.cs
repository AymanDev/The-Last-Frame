using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float gameSpeed = 1f;

    public static GameController instance;

    private void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        InvokeRepeating("TimeIncrementer", 2f, 2f);
    }

    private void TimeIncrementer()
    {
        if (Time.timeScale < 3.0f)
            Time.timeScale += 0.025f;
    }
}