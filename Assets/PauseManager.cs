using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public AudioSource backgroundMusic; // ← Assign this in the inspector

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause(); // Resume music
        }
    }

    void Pause()
    {
        Debug.Log("Pause triggered");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        if (backgroundMusic != null)
        {
            backgroundMusic.Pause(); // Pause music
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
