using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public static float moveSpeed = 5f;  // Speed of the boat
    private Rigidbody2D rb;
    public float time10s = 10f;
    public float timeTilBoost;


    void Start()
    {
        timeTilBoost = time10s;
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        if (timeTilBoost > 0)
        {
            timeTilBoost -= Time.deltaTime;
        }
        if (timeTilBoost <= 0)
        {
            timeTilBoost = time10s;
            moveSpeed = (float)(moveSpeed * 1.5);
        }
        float moveX = Input.GetAxis("Horizontal");  // A D Keys

        Vector2 moveDirection = new Vector2(-1, 0).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;

        rb.linearVelocity = newVelocity;  // Apply movement
    }
}
