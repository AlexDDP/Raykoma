using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;          // Reference to volume slider
    public Toggle fullscreenToggle;      // Reference to fullscreen toggle

    void Start()
    {
        // Load saved volume or default to 1
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;

        // Load saved fullscreen setting or fallback to current state
        int savedFullscreen = PlayerPrefs.GetInt("Fullscreen", Screen.fullScreen ? 1 : 0);
        bool isFullscreen = (savedFullscreen == 1);
        fullscreenToggle.isOn = isFullscreen;
        Screen.fullScreen = isFullscreen;

        // Add listener only for fullscreen (real-time)
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    // Applies the volume setting only when "Apply" button is clicked
    public void ApplySettings()
    {
        float newVolume = volumeSlider.value;
        AudioListener.volume = newVolume;

        PlayerPrefs.SetFloat("Volume", newVolume);
        PlayerPrefs.Save();

        Debug.Log("Volume applied and saved.");
    }

    // Applies fullscreen immediately when toggle is changed
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("Fullscreen setting applied immediately.");
    }

    
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
