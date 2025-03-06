using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    public float moveSpeed = 1f;    
    public float moveRange = 3f;    
    private float startY;

    private float lifetime = 5f;  
    private float timeRemaining;

    private Rigidbody2D rb;

    void Start()
    {
        startY = transform.position.y;
        timeRemaining = lifetime;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the crocodile up and down using sine wave, trick i found online
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveRange + startY;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Countdown
        timeRemaining -= Time.deltaTime;

        // Destroy the crocodile when the timer runs out
        if (timeRemaining <= 0)
        {
            Destroy(gameObject);  // Destroy the crocodile after the timer expires
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Boat"))
        {
            
            BoatCollision boatCollision = collision.gameObject.GetComponent<BoatCollision>();
            if (boatCollision != null)
            {
                boatCollision.lifeCount--;  // Reduce life
                Destroy(gameObject);  // Destroy the crocodile
            }
        }
    }
}
