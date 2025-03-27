using UnityEngine;

public class RockDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which rocks despawn

    public int RocksDodged = 0; // Number of rocks dodged

    void Update()
    {
        if (boat != null)
        {
            // Check if the rock is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
                RocksDodged++;  // Increment the number of rocks dodged

                if(RocksDodged > 20) 
                {
                    AchievementManager.Instance.UnlockAchievement("Rock Dodger 1!!");  // Unlock the "Dodged 20 Rocks" achievement

                }
            }
        }
    }
}
