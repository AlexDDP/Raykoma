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

        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource is missing on the coin GameObject!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Coins"))
        {
          
            coins++;
            coinsText.text = "Coins: " + coins;

          
            if (audioSource != null && coinSound != null)
            {
                audioSource.PlayOneShot(coinSound); 
            }
            else
            {
                Debug.LogWarning("audioSource or coinSound is missing.");
            }

           
            Destroy(other.gameObject);
        }
    }
}
