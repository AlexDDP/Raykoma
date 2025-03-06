using UnityEngine;
using TMPro;
using System;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public int lifeCount = 3;
    public TMP_Text collisionText;
    // initialises boatSprtie Change so i dont get stupid static error
    private BoatSpriteChange boatSpriteChange;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // assigns it to the right class or something idk
        boatSpriteChange = GetComponent<BoatSpriteChange>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            lifeCount--;
            if (lifeCount <= 0)
            {
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                RockMovement.moveSpeed = 0f;
                BoatController.moveSpeed = 0f;
                boatSpriteChange.UpdateSprite(gameObject);
            }
            collisionText.text = "Life: " + lifeCount;
            Destroy(collision.gameObject);
        }

        //marwans line of code(uknknown purpose but it works)
            rb.angularVelocity = 0f;
        }
}

