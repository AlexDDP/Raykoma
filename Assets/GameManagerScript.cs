using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    
    public void gameOver() {
        gameOverUI.SetActive(true);
    }

    public void RestartButton() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton() {
        SceneManager.LoadSceneAsync("Main Menu");
    }

    public GameObject gameSelectUI;

    public void Select() {
        gameSelectUI.SetActive(true);
    }
}
