using UnityEngine;
using UnityEngine.UI;  // For UI Button

public class UIManager : MonoBehaviour
{
    public Button playButton;  // Reference to the Play Button
    public GameObject boat;    // Reference to the boat (or any other objects you want to activate)

    void Start()
    {
        // Ensure the Play Button is assigned
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);  // Add listener to the Play button
        }
    }

    // This function is called when the play button is clicked
    public void OnPlayButtonClicked()
    {
        // Hide the button (so it disappears)
        playButton.gameObject.SetActive(false);
        playButton.transform.parent.gameObject.SetActive(false);
        // Start the game (you can activate boat movement or any other game elements here)
        StartGame();
    }

    void StartGame()
    {
        if (boat != null)
        {
            // Start the boat's movement (or other gameplay logic)
            Debug.Log("Game Started!");
            // For example, you can enable movement or other behaviors here
            // boat.GetComponent<BoatController>().EnableMovement();
        }
        else
        {
            Debug.LogError("Boat is not assigned in the UIManager!");
        }
    }
}
