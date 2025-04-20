using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BoatSelectorUI : MonoBehaviour
{
    public GameObject popupTextObject;
    public TextMeshProUGUI popupText;

    public Button[] selectButtons;
    public int[] costs = { 100, 0 }; // Match number of boats

    void Start()
    {
        // Set up all buttons, regardless of affordability
        for (int i = 0; i < selectButtons.Length; i++)
        {
            int index = i; // Needed to capture correct index inside listener
            selectButtons[i].onClick.RemoveAllListeners();
            selectButtons[i].onClick.AddListener(() => SelectBoat(index));
            selectButtons[i].interactable = true; // Always clickable
        }
    }

    public void SelectBoat(int boatIndex)
    {
        int currentCoins = PlayerPrefs.GetInt("Coins", 0);
        int boatCost = costs[boatIndex];

        if (currentCoins >= boatCost)
        {
            currentCoins -= boatCost;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);
            PlayerPrefs.Save();

            ShowPopup("Purchase Successful!");
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ShowPopup("Not enough coins!");
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
        PlayerPrefs.SetInt("SelectedBoatIndex", 1);
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs have been reset.");
    }
}
