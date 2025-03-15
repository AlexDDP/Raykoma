using UnityEngine;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock") || collision.gameObject.CompareTag("Crocodile"))
        {
            GameProperties.healthPoints--;
            if (GameProperties.healthPoints <= 0)
            {
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                GameProperties.objectMoveSpeed = 0f;
                ScrollingBackground.scrollSpeed = 0f;
            }
            Destroy(collision.gameObject);
        }

        //marwans line of code(uknknown purpose but it works)
            rb.angularVelocity = 0f;
        }
}

