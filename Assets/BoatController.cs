using UnityEngine;

public class BoatController : MonoBehaviour
{
    public static float moveSpeed;  // Speed of the boat
    private Rigidbody2D rb;


    void Start()
    {
        moveSpeed = 5f; // y speed, wont change
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
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
