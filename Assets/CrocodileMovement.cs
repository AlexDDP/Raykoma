using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    public static float moveSpeed = 3f;  // Speed of the crocodile
    private Rigidbody2D rb;
    public float time10s = 10f;
    public float timeTilBoost;
    private bool movingUp = true;

    void Start()
    {
        timeTilBoost = time10s;
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        // Increase speed every 10 seconds
        if (timeTilBoost > 0)
        {
            timeTilBoost -= Time.deltaTime;
        }
        if (timeTilBoost <= 0 && moveSpeed < 7f)  // Max speed limit
        {
            timeTilBoost = time10s;
            moveSpeed *= 1.2f;
        }

        // Move left in X and oscillate up/down in Y
        float moveX = -1;  // Moves left
        float moveY = movingUp ? 0.5f : -0.5f;  // Moves up and down

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;

        // Change direction in Y after a certain range
        if (transform.position.y > 2f) movingUp = false;
        if (transform.position.y < -2f) movingUp = true;
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
