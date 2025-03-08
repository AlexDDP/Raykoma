using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NPCRacer : MonoBehaviour
{
    Rigidbody2D rb2D;
    public int direction = 0;

    public float upperLimit = 5f; // Set these based on your screen
    public float lowerLimit = -5f;
    public float minX = -1f; // Left boundary for X movement
    public float maxX = 1f;  // Right boundary for X movement
    public float xMoveSpeed = 2f; // Speed for random forward/backward movement

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // Check for obstacles
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,10f);  // Raycast to the right

        if (hit)
        {
            direction = -2;  // Set direction for dodging
            transform.position += Vector3.up * direction * Time.deltaTime;
        }



        // **Clamp NPC position to stay within screen bounds**
        float clampedY = Mathf.Clamp(transform.position.y, lowerLimit, upperLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            // Destroy the rock after a delay
            Destroy(collision.gameObject);

        }
    }

    // **NPC Avoids Player When Too Close**
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player is nearby
        {
            float avoidanceDirection = (Random.value > 0.5f) ? 1 : -2; // Move left or right randomly
            Vector3 newPosition = transform.position + new Vector3(avoidanceDirection * xMoveSpeed * Time.deltaTime, 0, 0);

            // Clamp X position so NPC doesn't move off-screen
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            transform.position = newPosition;
        }
    }
}
