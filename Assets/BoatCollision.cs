using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
    public int lifeCount = 3;
    public TMP_Text collisionText;
    public TMP_Text Coins;
    // initialises boatSprtie Change so i dont get stupid static error
    private BoatSpriteChange boatSpriteChange;
    public int playerCoins = 0;
    
    
=======
    public static int lifeCount = 3;
    public GameObject effects;

>>>>>>> main
=======
<<<<<<< Updated upstream
    public static int lifeCount = 3;
    public GameObject effects;

=======
<<<<<<< Updated upstream
    public static int lifeCount = 3;
    public GameObject effects;

>>>>>>> Stashed changes
=======
    public int lifeCount = 3;
    public TMP_Text collisionText;
    public TMP_Text Coins;
    // initialises boatSprtie Change so i dont get stupid static error
    private BoatSpriteChange boatSpriteChange;
    public int playerCoins = 0;
    
    
>>>>>>> Stashed changes
<<<<<<< Updated upstream
>>>>>>> main
=======
>>>>>>> Stashed changes
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Crocodile"))
        {
            lifeCount--;
            if (lifeCount <= 0)
            {
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                RockMovement.moveSpeed = 0f;
                BoatController.moveSpeed = 0f;
                ScrollingBackground.scrollSpeed = 0f;
                coinMovement.moveSpeed = 0f;
                coinSpawner.spawnCoins = false;
            }
            Destroy(collision.gameObject);
        }
<<<<<<< Updated upstream
<<<<<<< HEAD
<<<<<<< HEAD
        if(collision.gameObject.CompareTag("Coin")) 
        {
            playerCoins++;
            Coins.text = "Coins: " + playerCoins;
        }
=======
=======
<<<<<<< Updated upstream
>>>>>>> main
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
        GameObject effectInstance = Instantiate(effects, transform.position, Quaternion.identity);

        // Get the ParticleSystem component and play it
        ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play(); // Manually play the particle effect
        }

        // Destroy the effect after it's done playing
        Destroy(effectInstance, ps.main.duration);
<<<<<<< Updated upstream
<<<<<<< HEAD
>>>>>>> main
=======
=======
>>>>>>> Stashed changes
=======
        if(collision.gameObject.CompareTag("Coin")) 
        {
            playerCoins++;
            Coins.text = "Coins: " + playerCoins;
        }
>>>>>>> Stashed changes
<<<<<<< Updated upstream
>>>>>>> main
=======
>>>>>>> Stashed changes
        //marwans line of code(uknknown purpose but it works)
        rb.angularVelocity = 0f;
        }
}

