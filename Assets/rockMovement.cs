using UnityEngine;
using TMPro;

public class RockMovement : MonoBehaviour
{
    // public static float moveSpeed = 5f;  // Speed of the boat
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    public void Update()
    {
        Vector2 moveDirection = new Vector2(-1, 0).normalized;
        Vector2 newVelocity = moveDirection * GameProperties.objectMoveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement
    }
}
