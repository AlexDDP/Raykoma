using UnityEngine;
using TMPro;

public class coinAccum : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsText;
    public AudioClip coinSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Load coins from PlayerPrefs if saved previously
        coins = PlayerPrefs.GetInt("Coins", 0); // Default to 0 if no value exists
        UpdateCoinsUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            coins++;  // Increment coin count
            UpdateCoinsUI();  // Update the UI with new coin count

            // Save the updated coin count to PlayerPrefs
            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.Save();

            AchievementSystem.Instance.Unlock("collect_coin");

            // Play coin sound if available
            if (audioSource != null && coinSound != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
            else
            {
                Debug.LogWarning("audioSource or coinSound is missing.");
            }

            // Destroy the collected coin object
            Destroy(other.gameObject);
        }
    }

    private void UpdateCoinsUI()
    {
        coinsText.text = "Coins: " + coins;  // Update the UI text
    }
}
