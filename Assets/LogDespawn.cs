using UnityEngine;

public class LogDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which logs despawn

    void Update()
    {
        if (boat != null)
        {
            // Check if the log is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the log object
            }
        }
    }
}
