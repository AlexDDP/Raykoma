using UnityEngine;

public class BoatController : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/BoatController.cs
    public static float moveSpeed;  // Speed of the boat
=======
    public static float moveSpeed = 5f;  // Speed of the boat
>>>>>>> Stashed changes:Assets/BoatController1.cs
    private Rigidbody2D rb;


    void Start()
    {
<<<<<<< Updated upstream:Assets/BoatController.cs
        moveSpeed = 5f; // y speed, wont change
=======
        moveSpeed = 5f;
>>>>>>> Stashed changes:Assets/BoatController1.cs
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
<<<<<<< Updated upstream:Assets/BoatController.cs
        if(GameProperties.healthPoints <= 0)
        {
            moveSpeed = 0f;
        }
        float moveY = Input.GetAxis("Vertical");    // W S Keys
=======
        moveY = 0;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;
>>>>>>> Stashed changes:Assets/BoatController1.cs
        Vector2 moveDirection = new Vector2(0, moveY).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement

        // Clamp the Y position, this stops kayak from going out of range
        Vector2 clampedPosition = rb.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4f, 4f); // -4 and 4 is the y range of camera
        rb.position = clampedPosition;  // Apply clamped position
    }
}
