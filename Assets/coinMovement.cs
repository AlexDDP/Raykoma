using UnityEngine;
using TMPro;

public class coinMovement : MonoBehaviour
{
    public static float moveSpeed;  // Speed of the boat
    private Rigidbody2D rb;

    void Start()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        Vector2 moveDirection = new Vector2(-1, 0).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;
        rb.linearVelocity = newVelocity;  // Apply movement
    }
}
