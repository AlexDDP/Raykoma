using UnityEngine;

public class npcscript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public int moveX = 50;
    public int moveSpeed = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(50, 0).normalized;
        Vector2 newVelocity = moveDirection * moveSpeed;

        rb.linearVelocity = newVelocity;  // Apply movement
    }
}
