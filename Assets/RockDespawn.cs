using UnityEngine;

public class RockDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which rocks despawn
    public int rocksDodged = 0;  // Number of rocks dodged

    void Update()
    {
        if (boat != null)
        {
            // Check if the rock is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
                rocksDodged++;  // Increment the number of rocks dodged
            }
        }
    }
}
