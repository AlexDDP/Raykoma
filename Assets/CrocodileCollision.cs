using UnityEngine;
using TMPro;

public class CrocodileCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    public int lifeCount = 3;            
    public TMP_Text collisionText;       
    private BoatSpriteChange boatSpriteChange;  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
        boatSpriteChange = GetComponent<BoatSpriteChange>(); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision object is the boat
        if (collision.gameObject.CompareTag("Boat"))
        {
            lifeCount--;  

            if (lifeCount <= 0)
            {
                
                ScoreUpdate.gameEnded = true;
                WaterDrag.terminate = true;
                RockSpawner.spawnRocks = false;
                RockMovement.moveSpeed = 0f;
                BoatController.moveSpeed = 0f;
                boatSpriteChange.UpdateSprite(gameObject);  
            }

            
            collisionText.text = "Life: " + lifeCount;

            
            Destroy(gameObject);
        }

        
        rb.angularVelocity = 0f;
    }
}
