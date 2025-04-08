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
        checkYIntervals = 0.1f;
        checkYtimer = checkYIntervals;
        crocSpeed = GameProperties.objectMoveSpeed;
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
}
