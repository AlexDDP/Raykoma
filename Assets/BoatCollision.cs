using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public static int lifeCount = 3;
    public GameObject effects;
    public AudioClip rockCollisionSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;
    public AudioSource backgroundMusic;

    public static bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("Game Over: You reached the finish line!");
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
            LogSpawn.spawnLogs = false;
            LogMovement.moveSpeed = 0f;
            DisableCrocodileMovement();
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();  // Stop the background music from playing
            }
            Destroy(collision.gameObject);

        }
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
                LogSpawn.spawnLogs = false;
                LogMovement.moveSpeed = 0f;
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
        //marwans line of code(uknknown purpose but it works)
        rb.angularVelocity = 0f;
    }


    // Function to disable all CrocodileMovement components in the scene
    private void DisableCrocodileMovement()
    {
        // Find all objects with the CrocodileMovement script and disable the script
        CrocodileMovement[] crocodileMovements = FindObjectsOfType<CrocodileMovement>();
        foreach (CrocodileMovement crocodileMovement in crocodileMovements)
        {
            // Disable the component to stop crocodile movement
            crocodileMovement.enabled = false;
        }
    }
}
