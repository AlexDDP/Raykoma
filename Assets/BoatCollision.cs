using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public int lifeCount = 3;
    public TMP_Text collisionText;
    public TMP_Text Coins;
    // initialises boatSprtie Change so i dont get stupid static error
    private BoatSpriteChange boatSpriteChange;
    public int playerCoins = 0;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Crocodile"))
        {
            if (collision.gameObject.CompareTag("Rock"))
            {
                audioSource.PlayOneShot(rockCollisionSound);
            }

            lifeCount--;
            if (lifeCount <= 0)
            {
                audioSource.PlayOneShot(gameOverSound);
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                RockMovement.moveSpeed = 0f;
                BoatController.moveSpeed = 0f;
                ScrollingBackground.scrollSpeed = 0f;
                coinMovement.moveSpeed = 0f;
                coinSpawner.spawnCoins = false;
                CrocodileSpawner.spawnCrocodiles = false;
                DisableCrocodileMovement();
                if (backgroundMusic != null)
                {
                    backgroundMusic.Stop();  // Stop the background music from playing
                }

            }

            Destroy(collision.gameObject);
        }
        GameObject effectInstance = Instantiate(effects, transform.position, Quaternion.identity);

        // Get the ParticleSystem component and play it
        ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play(); // Manually play the particle effect
        }

        // Destroy the effect after it's done playing
        Destroy(effectInstance, ps.main.duration);
=======
        if(collision.gameObject.CompareTag("Coin")) 
        {
            playerCoins++;
            Coins.text = "Coins: " + playerCoins;
        }
>>> >>>>>>> //Stashed changes
        //marwans line of code(uknknown purpose but it works)
        rb.angularVelocity = 0f;
    }


    // Function to disable all CrocodileMo/// vement components in the scene
    private void DisableCrocodileMovement()
   {
        // Find all objects with the CrocodileMovement script and disable  the script
        CrocodileMovement[] crocodileMovements = FndObjectsOfType<CrocodileMovement>();
        foreach (CrocodleMovement crocodileMovement in crocodileMovements)
        {
            // Disable the component to stop crocodile movement
            crocodileMovement.enabled = false;
        }
    }
}
