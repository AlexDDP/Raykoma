using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.Audio;

public class BoatCollision1 : MonoBehaviour
{
    private Rigidbody2D rb;
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
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Crocodile"))
        {
            GameProperties.healthPoints1--;
            if (collision.gameObject.CompareTag("Rock"))
            {
                audioSource.PlayOneShot(rockCollisionSound);
            }

            if (GameProperties.healthPoints1 <= 0)
            {
                audioSource.PlayOneShot(gameOverSound);
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                GameProperties.objectMoveSpeed = 0f;
                ScrollingBackground.scrollSpeed = 0f;
                coinMovement.moveSpeed = 0f;
                coinSpawner.spawnCoins = false;
                CrocodileSpawner.spawnCrocodiles = false;
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
}
