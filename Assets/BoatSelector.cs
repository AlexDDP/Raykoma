using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatSelectorUI : MonoBehaviour
{
    // Function for selecting the first boat (or any boat index you want)
    public void SelectBoat(int boatIndex)
    {
        PlayerPrefs.SetInt("SelectedBoatIndex", boatIndex);  // Save the boat index to PlayerPrefs
        Debug.Log("Selected Boat Index: " + boatIndex);       // Debug message
        SceneManager.LoadScene("SampleScene");                  // Load the GameScene
    }
}
