using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    public static float crocSpeed;  // Speed of the crocodile
    private Rigidbody2D rb;
    private bool movingUp = true;
    private float prevY;
    float randSpeed;
    float checkYtimer;
    float checkYIntervals;
    void Start()
    {
        checkYIntervals = 0.35f;
        checkYtimer = checkYIntervals;
        crocSpeed = GameProperties.objectMoveSpeed;
        randSpeed = UnityEngine.Random.Range(0, 5);
        rb = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        crocSpeed = GameProperties.objectMoveSpeed+randSpeed;
        // Move left in X and oscillate up/down in Y
        float moveX = -1;  // Moves left
        float moveY = movingUp ? 0.5f : -0.5f;  // Moves up and down

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        Vector2 newVelocity = moveDirection * crocSpeed;
        rb.linearVelocity = newVelocity;

        // Change direction in Y after a certain range
        if (transform.position.y > 5f) movingUp = false;
        if (transform.position.y < -5f) movingUp = true;
        if(checkYtimer < 0f){
            if(prevY == transform.position.y) movingUp = !movingUp;
            prevY = transform.position.y;
            checkYtimer = checkYIntervals;
        }
        checkYtimer -= Time.deltaTime;
        
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         BoatCollision.lifeCount--; // Reduce player life

    //         if (BoatCollision.lifeCount <= 0)
    //         {
    //             ScoreUpdate.gameEnded = true;
    //             WaterDrag.terminate = true;
    //             RockSpawner.spawnRocks = false;
    //             GameProperties.objectMoveSpeed = 0f;
    //             ScrollingBackground.scrollSpeed = 0f;
    //         }

    //         Destroy(gameObject); // Remove crocodile after collision
    //     }
    // }
}
