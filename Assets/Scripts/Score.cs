using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text textScore;
    public Text loseTextScore;

    public static Score instance;

    private void Start()
    {
        instance = this;
        InvokeRepeating("ScoreIncrementer", 1f, 1f);
    }

    private void ScoreIncrementer()
    {
        score += 10;
        textScore.text = "Счет: " + score;
        loseTextScore.text = "Счет: " + score;
    }
}