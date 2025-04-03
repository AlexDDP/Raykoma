using UnityEngine;

public class BoatController : MonoBehaviour
{
    public static float moveSpeed;  // Speed of the boat
    public static float moveSpeed = 5f;  // Speed of the boat
    private Rigidbody2D rb;
    public float time10s = 10f;
    public float timeTilBoost;


    void Start()
    {
        moveSpeed = 5f; // y speed, wont change
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        if(GameProperties.healthPoints <= 0)
        {
            moveSpeed = 0f;
        }
        float moveY = Input.GetAxis("Vertical");    // W S Keys
        Vector2 moveDirection = new Vector2(0, moveY).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement

        // Clamp the Y position, this stops kayak from going out of range
        Vector2 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4f, 4f); // -4 and 4 is the y range of camera
        rb.position = clampedPosition;  // Apply clamped position
    }
}
