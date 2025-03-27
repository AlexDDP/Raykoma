using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    
    public static float moveSpeed;//Speed of the crocodile -0.5 to 0.5
    private Rigidbody2D rb;
    public float time10s = 10f;
    public float timeTilBoost;
    private bool movingUp = true;

    public int crocodilesDodged = 0; // Number of crocodiles dodged

    public coinAccum coinNum; // Reference to the coin amount
                       

    void Start()
    {
        moveSpeed = RockMovement.moveSpeed;
        timeTilBoost = time10s;
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        moveSpeed = RockMovement.moveSpeed;
        moveSpeed = Random.Range(1f, 5f);



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
        else 
        {
            Destroy(gameObject); // Remove crocodile after collision
            crocodilesDodged++;  // Increment the number of crocodiles dodged
        }

        if(crocodilesDodged > 100)
        {
            AchievementManager.Instance.UnlockAchievement("Crocodile Master I!!!"); // Unlock the achievement
            Debug.Log("Achievement Unlocked: Crocodile dodger I!!!");
            coinAccum.coins += 100; // Add 100 coins to the player's total
        } else if(crocodilesDodged > 300)
        {
            AcheivementManager.Instance.UnlockAchievement("Crocodile Master II!!!"); // Unlock the achievement
            Debug.Log("Acheivement Unlocked: Crocodile Dodger II!!!");
            coinAccum.coins += 200; // Add 200 coins to the player's total
        } else if(crocodilesDodged > 500)
        {
            AcheivementManager.Instance.UnlockAchievement("Crocodile Master III!!!"); // Unlock the achievement
            Debug.Log("Acheivement Unlocked: Crocodile Dodger III!!!");
            coinAccum.coins += 300; // Add 300 coins to the player's total
        }
}
