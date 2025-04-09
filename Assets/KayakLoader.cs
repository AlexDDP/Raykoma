using UnityEngine;

public class KayakLoader : MonoBehaviour
{
    public Sprite[] boatSprites;              // Array of boat sprites (drag them here)
    public SpriteRenderer mainBoatRenderer;   // Reference to the SpriteRenderer of the main boat

    void Start()
    {
        // Get the selected boat index from PlayerPrefs
        int selectedIndex = PlayerPrefs.GetInt("SelectedBoatIndex", 0); // Default to index 0 if nothing is saved

        // Debug message to check the selected boat index
        Debug.Log("Loaded Boat Index: " + selectedIndex);

        // Change the sprite of the main boat based on the selected index
        if (selectedIndex >= 0 && selectedIndex < boatSprites.Length)
        {
            mainBoatRenderer.sprite = boatSprites[selectedIndex];
            Debug.Log("Boat sprite changed successfully!");
        }
        else
        {
            Debug.LogError("Invalid boat index selected.");
        }
    }
}
