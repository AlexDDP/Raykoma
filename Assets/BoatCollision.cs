using UnityEngine;
using TMPro;

public class BoatCollision : MonoBehaviour
{
    private Rigidbody2D rb;
    private int lifeCount = 3;
    public TMP_Text collisionText;
    
    // initialises boatSprtie Change so i dont get stupid static error
    private BoatSpriteChange boatSpriteChange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // assigns it to the right class or something idk
        boatSpriteChange = GetComponent<BoatSpriteChange>();

        if (collisionText != null)
        {
            collisionText.text = "Life: " + lifeCount;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            lifeCount--;
            if (lifeCount <= 0)
            {
                BoatController.moveSpeed = 0f;
                // Call UpdateSprite on the BoatSpriteChange component
                boatSpriteChange.UpdateSprite(gameObject);
            }

            if (collisionText != null)
            {
                collisionText.text = "Life: " + lifeCount;
            }

            rb.angularVelocity = 0f;
        }
    }
}
