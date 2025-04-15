using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CrocodileDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which rocks despawn
    public int CrocodilesDodged = 0;

    void Update()
    {
        if (boat != null)
        {
            // Check if the rock is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
                CrocodilesDodged++;
            }

            if(CrocodilesDodged > 25) {
                AchievementSystem.Instance.Unlock("Crocodile Master 1!");
                Debug.Log("Crocodile Master 1!");
            
            } else if(CrocodilesDodged > 50) {
                AchievementSystem.Instance.Unlock("Crocodile Master 2!");
                Debug.Log("Crocodile Master 2!");

            } else if(CrocodilesDodged > 75) {
                AchievementSystem.Instance.Unlock("Crocodile Master 3!");
                Debug.Log("Crocodile Master 3!");
            }
        }
    }
}
