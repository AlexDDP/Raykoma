using UnityEngine;

public class LogMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;  // Log speed (should be independent of background)
    private Rigidbody2D rb;
    public float time10s = 10f;
    public float timeTilBoost;
    private float initialXPosition;

    void Start()
    {
        timeTilBoost = time10s;
        rb = GetComponent<Rigidbody2D>();
        initialXPosition = transform.position.x; // Store initial position
    }

    void Update()
    {
        if (timeTilBoost > 0)
        {
            timeTilBoost -= Time.deltaTime;
        }
        if (timeTilBoost <= 0 && moveSpeed < 9f)
        {
            timeTilBoost = time10s;
            moveSpeed *= 1.2f;
        }

        // Instead of locking position, move log forward at a consistent speed
        rb.velocity = new Vector2(-moveSpeed, 0); // Move left at moveSpeed
    }
}
