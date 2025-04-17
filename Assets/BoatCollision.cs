using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BoatCollision : MonoBehaviour
{
    public GameObject effects;
    public AudioClip rockCollisionSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    public AudioSource backgroundMusic;

    public static bool isGameOver = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            //audioSource.PlayOneShot(gameOverSound);
            //ScoreUpdate.gameEnded = true;
            //WaterDrag.terminate = true;
            //RockSpawner.spawnRocks = false;
            //GameProperties.objectMoveSpeed = 0f;
            //BoatController.moveSpeed = 0f;
            //ScrollingBackground.scrollSpeed = 0f;
            //coinSpawner.spawnCoins = false;
            //CrocodileSpawner.spawnCrocodiles = false;
            //LogSpawn.spawnLogs = false;
            //if (backgroundMusic != null)
            //{
            //    backgroundMusic.Stop();  // Stop the background music from playing
            //}
            GameProperties.healthPoints = 3;
            GameProperties.objectMoveSpeed = 5f;
            string sceneName = SceneManager.GetActiveScene().name;
            Destroy(collision.gameObject);
            if (sceneName == "SampleScene")
                SceneManager.LoadSceneAsync("Cycling");
            else if (sceneName == "Cycling")
                SceneManager.LoadSceneAsync("Running");
            else if (sceneName == "Running")
                SceneManager.LoadSceneAsync("EndingScene");
        }

        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Crocodile"))
        {
            GameProperties.healthPoints--;
            //if (GameProperties.healthPoints <= 0)
            if (collision.gameObject.CompareTag("Rock"))
            {
                //AchievementSystem.Instance.Unlock("hit_rock");
                audioSource.PlayOneShot(rockCollisionSound);
            }

            if (GameProperties.healthPoints <= 0)
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
                LogSpawn.spawnLogs = false;
                LogMovement.moveSpeed = 0f;
                if (backgroundMusic != null)
                {
                    backgroundMusic.Stop();  // Stop the background music from playing
                }
                StartCoroutine(ResetGameAfterDelay()); // changed from LoadGameSceneAfterDelay
            }

            Destroy(collision.gameObject);
        }

        //GameObject effectInstance = Instantiate(effects, transform.position, Quaternion.identity);

        //    // Get the ParticleSystem component and play it
        //    ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
        //    if (ps != null)
        //    {
        //        ps.Play(); // Manually play the particle effect
        //    }

        //    // Destroy the effect after it's done playing
        //    Destroy(effectInstance, ps.main.duration);
        //    //marwans line of code(uknknown purpose but it works)
        //    rb.angularVelocity = 0f;
        //}


        //// Function to disable all CrocodileMovement components in the scene
        //private void DisableCrocodileMovement()
        //{
        //    // Find all objects with the CrocodileMovement script and disable the script
        //    CrocodileMovement[] crocodileMovements = FindObjectsOfType<CrocodileMovement>();
        //    foreach (CrocodileMovement crocodileMovement in crocodileMovements)
        //    {
        //        // Disable the component to stop crocodile movement
        //        crocodileMovement.enabled = false;
        //    }
        //}
    }

    System.Collections.IEnumerator ResetGameAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f);

        // Reset values
        GameProperties.healthPoints = 3;
        GameProperties.objectMoveSpeed = 5f;
        ScoreUpdate.score = 0;
        ScoreUpdate.gameEnded = false;
        WaterDrag.terminate = false;
        RockSpawner.spawnRocks = true;
        coinSpawner.spawnCoins = true;
        CrocodileSpawner.spawnCrocodiles = true;
        LogSpawn.spawnLogs = true;
        ScrollingBackground.scrollSpeed = 2f; // or your default
        coinMovement.moveSpeed = 3f; // or your default
        LogMovement.moveSpeed = 3f; // or your default

        // Reload the game scene
        SceneManager.LoadScene("Game");
    }

    System.Collections.IEnumerator LoadGameSceneAfterDelay()
    {
        yield return new WaitForSecondsRealtime(2f); // Wait 2 real-world seconds
        SceneManager.LoadScene("Game");
    }
}
