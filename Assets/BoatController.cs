using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the boat

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get Rigidbody2D component
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");  // A/D or Left/Right arrow keys
        float moveY = Input.GetAxis("Vertical");    // W/S or Up/Down arrow keys

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        rb.linearVelocity = moveDirection * moveSpeed;
    }
}
