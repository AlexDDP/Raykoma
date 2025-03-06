using UnityEngine;
using TMPro;

public class RockMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;  // Speed of the boat
    public float speedMultiplier = 1.1f;
    private Rigidbody2D rb;
    public float timer;
    public float timeTilBoost = 5f;


    void Start()
    {
        timer = timeTilBoost;
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0 && moveSpeed < 10f)
        {
            timer = timeTilBoost;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        Vector2 moveDirection = new Vector2(-1, 0).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement
    }
}
