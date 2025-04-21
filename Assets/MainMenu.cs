using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public void PlayGame()
    //{
        // Change "Game" to "SampleScene" to match the actual scene name
       // SceneManager.LoadSceneAsync("SampleScene");
    //}
    public void OpenSettings()
    {
        // Replace "Settings" with the name of your settings scene
        SceneManager.LoadSceneAsync("Settings");
    }
    public void OpenShop()
    {
        SceneManager.LoadSceneAsync("Shop");
    }

    public GameObject Selection;

    public void OpenSelection() {
        if (Selection != null) {
           Selection.SetActive(true); 
        }
    }

    public void Kayaking() {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Cycling() {
        SceneManager.LoadSceneAsync("Cycling");
    }

    public void Running() {
        SceneManager.LoadSceneAsync("Running");
    }

    public GameObject Selection2;
    
    public void OpenSelection2() {
        if (Selection2 != null) {
           Selection2.SetActive(true); 
        }
    }
}
