using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class BoatSelectorUI : MonoBehaviour
{
    public GameObject popupTextObject; // Drag the Text GameObject here in Inspector
    public TextMeshProUGUI popupText; // The actual Text component (or TextMeshProUGUI if using TMP)

    public Button selectButton;        // The button to select the boat
    public int[] costs = { 100, 0 };    // Cost for each boat (boatIndex 0 = 10 coins, boatIndex 1 = 0 coins)

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
       //else
        //{
          //  selectButton.interactable = false; // Disable the button
        //}
    }
    void ShowPopup(string message)
    {
        popupText.text = message;
        popupTextObject.SetActive(true);
        CancelInvoke(nameof(HidePopup)); // Prevents double invoke if clicked fast
        Invoke(nameof(HidePopup), 2f); // Hides after 2 seconds
    }

    void HidePopup()
    {
        popupTextObject.SetActive(false);
    }


    // Function to select the boat
    public void SelectBoat(int boatIndex)
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        int boatCost = costs[boatIndex];  // Get the cost of the selected boat

        if (currentCoins >= boatCost)
        {
            currentCoins -= boatCost;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);
            PlayerPrefs.Save();

            // Show success message
            ShowPopup("Purchase Successful!");

            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ShowPopup("Not enough coins!");
        }
    }


    // Call this function when you want to reset PlayerPrefs (e.g., on button click)
    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll(); // Clears all saved PlayerPrefs data
        PlayerPrefs.Save(); // Save the changes to PlayerPrefs (optional)
        PlayerPrefs.SetInt("SelectedBoatIndex", 1);
        PlayerPrefs.Save();  // Save the changes to PlayerPrefs
        Debug.Log("PlayerPrefs have been reset.");
    }
}
