using UnityEngine;

public class LogDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which logs despawn
    public int logsDodged = 0;

    void Update()
    {
        if (boat != null)
        {
            // Check if the log is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the log object
                logsDodged++;

            }
            if(logsDodged > 20) 
            {
                AcheivementSystem.Instance.Unlock("Branch Master 1!");
                Debug.Log("Branch Master 1!");
            }
            else if(logsDodged > 40) {
                AcheivementSystem.Instance.Unlock("Branch Master 2!");
                Debug.Log("Branch Master 2!");
            }
            else if(logsDodged > 60) {
                AcheivementSystem.Instance.Unlock("Branch Master 3!");
                Debug.Log("Branch Master 3!");
            }
        }
    }
}
