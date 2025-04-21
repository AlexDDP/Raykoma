using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BoatSelectorUI : MonoBehaviour
{
    public GameObject popupTextObject;
    public TextMeshProUGUI popupText;

    public Button[] selectButtons;
    public int[] costs = { 200, 0, 400 }; // Cost of each boat

    void Start()
    {
        // Set up all buttons
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int index = i;
            selectButtons[i].onClick.RemoveAllListeners();
            selectButtons[i].onClick.AddListener(() => SelectBoat(index));
            selectButtons[i].interactable = true;
        }
    }

    public void SelectBoat(int boatIndex)
    {
        if (boatIndex < 0 || boatIndex >= costs.Length)
        {
            Debug.LogError($"Invalid boat index: {boatIndex}");
            ShowPopup("ERROR: Invalid boat!");
            return;
        }

        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        int boatCost = costs[boatIndex];

        // Check if already unlocked
        bool isUnlocked = PlayerPrefs.GetInt($"BoatUnlocked_{boatIndex}", 0) == 1;

        if (isUnlocked || boatCost == 0)
        {
            // No cost needed, just select
            PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);
            PlayerPrefs.Save();
            ShowPopup("BOAT SELECTED!");
            SceneManager.LoadScene("SampleScene");
            return;
        }

        if (currentCoins >= boatCost)
        {
            // Deduct coins and unlock boat
            currentCoins -= boatCost;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt($"BoatUnlocked_{boatIndex}", 1);
            PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);
            PlayerPrefs.Save();

            ShowPopup("PURCHASE SUCCESSFUL!");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ShowPopup("NOT ENOUGH COINS!");
        }
    }

    void ShowPopup(string message)
    {
        popupText.text = message;
        popupTextObject.SetActive(true);
        CancelInvoke(nameof(HidePopup));
        Invoke(nameof(HidePopup), 2f);
    }

    void HidePopup()
    {
        popupTextObject.SetActive(false);
    }

    public void ResetAllData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs have been reset.");
    }
   

}
