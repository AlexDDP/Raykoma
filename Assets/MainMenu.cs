using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void OpenSettings()
    {
        
        SceneManager.LoadSceneAsync("Settings");
    }
    public void OpenShop()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

    public void OpenCredits()
    {
        SceneManager.LoadSceneAsync("credits");
    }
}
