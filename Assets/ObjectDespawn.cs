using UnityEngine;

public class ObjectDespawn : MonoBehaviour
{
    public float despawnDistance;
    void Start(){
        despawnDistance = 0f-30f; 
    }
    void Update()
    {
        {
            if (transform.position.x < despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
            }
        }
    }
}
