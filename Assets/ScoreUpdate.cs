using System;
using TMPro;
using System.IO;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour 
{
    private string filePath;
    public int highScore = 0;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public static int score = 0;
    public float timeTilUpdate = 0.1f;
    public float timer;
    public static Boolean gameEnded = false;
    public string playerName;
    public string scoreTextString;
    void Start()
    {
        timer = timeTilUpdate;
        filePath = Application.dataPath + "/highScore.txt"; // Saves inside Assets folder
        LoadHighScore();
        highScoreText.text =  scoreTextString;
    }
    void Update()
    {
        if(timer < 0 && !gameEnded)
        {
            score += 1;
            scoreText.text = score.ToString();
            timer = timeTilUpdate;
        }
        if (gameEnded)
        {
            SaveHighScore(score);
        }
        timer -= Time.deltaTime;
    }

    public void SaveHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            File.WriteAllText(filePath, highScore.ToString());
        }
    }

    public void LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            scoreTextString = File.ReadAllText(filePath);
            if(!string.IsNullOrEmpty(scoreTextString)) highScore = int.Parse(scoreTextString);
            else highScore = 0;
        }

    }
}
