using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public static float moveSpeed;  // Log speed (should be independent of background)
    private Rigidbody2D rb;
    public float time10s = 10f;

    void Start()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        // Instead of locking position, move log forward at a consistent speed
        rb.linearVelocity = new Vector2(-moveSpeed, 0); // Move left at moveSpeed
    }
}
