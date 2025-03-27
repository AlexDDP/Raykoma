using UnityEngine;

public class BoatController2 : MonoBehaviour
{
    public static float moveSpeed = GameProperties.objectMoveSpeed;  // Speed of the boat
    private Rigidbody2D rb;
    float moveY;


    void Start()
    {
        moveSpeed = GameProperties.objectMoveSpeed; // y speed, wont change
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
        moveY = 0;
    }

    void Update()
    {
        moveY = 0;
        moveSpeed = GameProperties.objectMoveSpeed;
        if (Input.GetKey(KeyCode.UpArrow)) moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -1f;
        Vector2 moveDirection = new Vector2(0, moveY).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement

        // Clamp the Y position, this stops kayak from going out of range
        Vector2 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4f, 4f); // -4 and 4 is the y range of camera
        rb.position = clampedPosition;  // Apply clamped position
    }
}
