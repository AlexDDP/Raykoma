using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Change "Game" to "SampleScene" to match the actual scene name
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void OpenSettings()
    {
        // Replace "Settings" with the name of your settings scene
        SceneManager.LoadSceneAsync("Settings");
    }
}
