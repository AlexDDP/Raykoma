//test!!!
using UnityEngine;
using TMPro;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private int collisionCounter = 0;
    public TMP_Text collisionText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // FIX -- -- Use Rigidbody2D instead of Rigidbody
        //if (collisionText != null)
       // {
           // collisionText.text = "Collisions: 0";
       // }
    }

    void OnCollisionEnter2D(Collision2D collision)  // FIX -- -- Use OnCollisionEnter2D for 2D physics
    {
        if (collision.gameObject.CompareTag("Rock"))  
        {
            collisionCounter++;

            if (collisionText != null)
            {
                collisionText.text = "Collisions: " + collisionCounter;
            }

            //DEBUG LOG
            Debug.Log("Collision detected! Total collisions: " + collisionCounter);

            rb.angularVelocity = 0f;
        }
    }
}
