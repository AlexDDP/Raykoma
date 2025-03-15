using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    public static float crocSpeed;  // Speed of the crocodile
    private Rigidbody2D rb;
    private bool movingUp = true;
    float randSpeed;

    void Start()
    {
        crocSpeed = RockMovement.moveSpeed;
        randSpeed = UnityEngine.Random.Range(0, 5);
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        crocSpeed = RockMovement.moveSpeed+randSpeed;
        // Move left in X and oscillate up/down in Y
        float moveX = -1;  // Moves left
        float moveY = movingUp ? 0.5f : -0.5f;  // Moves up and down

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        Vector2 newVelocity = moveDirection * crocSpeed;
        rb.linearVelocity = newVelocity;

        // Change direction in Y after a certain range
        if (transform.position.y > 5f) movingUp = false;
        if (transform.position.y < -5f) movingUp = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BoatCollision.lifeCount--; // Reduce player life

            if (BoatCollision.lifeCount <= 0)
            {
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                RockMovement.moveSpeed = 0f;
                BoatController.moveSpeed = 0f;
                ScrollingBackground.scrollSpeed = 0f;
            }

            Destroy(gameObject); // Remove crocodile after collision
        }
    }
}
