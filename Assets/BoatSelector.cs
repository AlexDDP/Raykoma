using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatSelectorUI : MonoBehaviour
{
    public Button selectButton;        // The button to select the boat
    public int[] costs = { 10, 0 };    // Cost for each boat (boatIndex 0 = 10 coins, boatIndex 1 = 0 coins)

    // Function to set the button interactability based on coins
    void Start()
    {
        // Get the boat index (you can set this dynamically for each boat)
        int boatIndex = PlayerPrefs.GetInt("SelectedBoatIndex", 0);  // Default to 0 if no selection

        // Get the cost of the selected boat based on boatIndex
        int boatCost = costs[boatIndex];

        // Check if the player has enough coins to select the boat
        if (PlayerPrefs.GetInt("Coins", 0) >= boatCost)
        {
            selectButton.interactable = true; // Enable the button
        }
        else
        {
            selectButton.interactable = false; // Disable the button
        }
    }

    // Function to select the boat
    public void SelectBoat(int boatIndex)
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        int boatCost = costs[boatIndex];  // Get the cost of the selected boat

        // Check if the player has enough coins to select the boat
        if (currentCoins >= boatCost)
        {
            // Deduct coins for the boat
            currentCoins -= boatCost;
            PlayerPrefs.SetInt("Coins", currentCoins);  // Update the coin balance in PlayerPrefs
            PlayerPrefs.Save();

            // Save the selected boat index
            PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);
            PlayerPrefs.Save();

            Debug.Log("Boat Selected! Coins Remaining: " + currentCoins);
            // Load the game scene or transition
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.Log("Not enough coins to select this boat!");
            // Optionally, show a UI message here to inform the player
        }
    }

    // Call this function when you want to reset PlayerPrefs (e.g., on button click)
    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll(); // Clears all saved PlayerPrefs data
        PlayerPrefs.Save(); // Save the changes to PlayerPrefs (optional)
        Debug.Log("PlayerPrefs have been reset.");
    }
}
