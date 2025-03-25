using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Make sure this is included

public class SettingsManager : MonoBehaviour
{
    public Slider volumeSlider;    // Volume slider UI element
    public Toggle fullscreenToggle; // Fullscreen toggle UI element

    void Start()
    {
        // Set the initial values based on current game settings
        volumeSlider.value = AudioListener.volume;
        fullscreenToggle.isOn = Screen.fullScreen;

        // Add listeners to handle changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
        fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
    }

    // Method to set the volume based on the slider
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Set the global audio volume
    }

    // Method to toggle fullscreen mode
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // Set fullscreen mode
    }

    // Method to apply and save settings (optional)
    public void ApplySettings()
    {
        // You can save settings to PlayerPrefs or a file here if needed
        // Example: PlayerPrefs.SetFloat("Volume", AudioListener.volume);
        // Example: PlayerPrefs.SetInt("Fullscreen", Screen.fullScreen ? 1 : 0);
    }

    // Method to go back to the main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // Replace with your actual main menu scene name
    }
}
