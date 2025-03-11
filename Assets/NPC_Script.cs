using UnityEngine;

public class NPC_Script: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb;
    public int moveY = -1;
    public float timer;
    public float timeTS = 2.5f;
    public float moveSpeed = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        timer = timeTS;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timeTS;
            moveY *= -1;
            Vector2 moveDirection = new Vector2(0, moveY).normalized;
            Vector2 newVelocity = moveDirection * moveSpeed;
            rb.linearVelocity = newVelocity;
        }
        rb.angularVelocity = 0;
    }
}
