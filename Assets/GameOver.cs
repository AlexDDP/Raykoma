using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void RestartButton() {
        SceneManager.LoadSceneAsync("Game");
    }

    public void ExitButton() {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
