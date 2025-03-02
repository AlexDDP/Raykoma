//test!!!
using UnityEngine;
using TMPro;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public int collisionCounter = 0;
    public TMP_Text collisionText;

    public int PlayerScore = 0;

    public TMP_Text Score;



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
        if (collision.gameObject.CompareTag("Rock") == true)  
        {

            collisionCounter++;
            PlayerScore = PlayerScore - 20;
            Debug.Log("Score is down by 20!");
            
        }
            if (collisionText != null)
            {
                collisionText.text = "Collisions: " + collisionCounter;
            }
            if(Score != null) 
            {
                Score.text = "Score: " + PlayerScore;
            }

            //DEBUG LOG
            Debug.Log("Collision detected! Total collisions: " + collisionCounter);

            rb.angularVelocity = 0f;
        }    
    
    
}

