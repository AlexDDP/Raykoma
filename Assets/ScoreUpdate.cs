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
        playerName = System.Environment.UserName;
        Debug.Log("Player Name: " + playerName);
        timer = timeTilUpdate;
        filePath = Application.dataPath + "/highScore.txt"; // Saves inside Assets folder
        LoadHighScore();
        highScoreText.text = "" + scoreTextString;
    }
    void Update()
    {
        if(timer < 0 && !gameEnded)
        {
            score += 1;
            scoreText.text = "Score: " + score;
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
            File.WriteAllText(filePath, "High Score: " + highScore.ToString() + " got by " + playerName);
        }
    }

    public void LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            scoreTextString = File.ReadAllText(filePath);
            string num = "";
            int idx = 12;
            while (Char.IsDigit(scoreTextString[idx]))
            {
                num += scoreTextString[idx];
                idx++;
            }
            if(!string.IsNullOrEmpty(num)) highScore = int.Parse(num);
            else highScore = 0;
        }

    }
}
