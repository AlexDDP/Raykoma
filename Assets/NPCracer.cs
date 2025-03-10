using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class NPCRacer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 2f;   // Speed of NPC movement
    public float laserLength = 5f; // Raycast detection distance
    public float dodgeSpeed = UnityEngine.Random.Range(2,-2);  // Speed of dodging

    public float upperLimit = 4.5f; // Adjust based on your scene size
    public float lowerLimit = -4.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Assign Rigidbody2D at start
    }

    void FixedUpdate()
    {

        //Get the first object hit by the ray
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, laserLength);

        //If the collider of the object hit is not NUll
        if (hit.collider != null)
        {
            rb.linearVelocity = new Vector2(0, -dodgeSpeed);
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.tag);
        }

        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);

        // Clamp NPC position within screen bounds
        float clampedY = Mathf.Clamp(transform.position.y, lowerLimit, upperLimit);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}