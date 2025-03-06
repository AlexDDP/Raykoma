using System;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour 
{
    public TMP_Text scoreText;
    public int score = 0;
    public float timeTilUpdate = 0.1f;
    public float timer;
    public static Boolean gameEnded = false;
    void Start()
    {
        timer = timeTilUpdate;
    }
    void Update()
    {
        if(timer < 0 && !gameEnded)
        {
            score += 1;
            scoreText.text = "Score: " + score;
            timer = timeTilUpdate;
        }
        timer -= Time.deltaTime;
    }
}
