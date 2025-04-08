using UnityEngine;

public class ObjectDespawn : MonoBehaviour
{
    public float despawnDistance = 30f;  // Distance at which rocks despawn

    private void Start()
    {
        despawnDistance = 30f;
    }
    void Update()
    {
        // Check if the rock is beyond a certain distance from the boat
        if (transform.position.x < -despawnDistance)
        {
            Destroy(gameObject);  // Destroy the rock object
        }
    }
}
