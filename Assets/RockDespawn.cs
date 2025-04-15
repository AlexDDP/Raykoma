using UnityEngine;

public class RockDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which rocks despawn
    public int rocksDodged = 0;

    void Update()
    {
        if (boat != null)
        {
            // Check if the rock is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
                rocksDodged++;
            }
             if(RocksDodged > 20) 
                {
                    AchievementSystem.Instance.UnlockAchievement("Rock Dodger 1!!");  // Unlock the Rock Dodger 1!! achievement
                    Debug.Log("Achievement Unlocked: Rock Dodger 1!!");
                } 
                else if (RocksDodged > 50)
                {
                    AchievemenSystem.Instance.UnlockAchievement("Rock Dodger 2!!");  // Unlock the Rock Dodger 2!! achievement
                    Debug.Log("Achievement Unlocked: Rock Dodger 2!!");
                } 
                else if(RocksDodged > 100)
                {
                    AchievementSystem.Instance.UnlockAchievement("Rock Dodger 3!!");  // Unlock the Rock Dodger 3!! achievement
                    Debug.Log("Achievement Unlocked: Rock Dodger 3!!");
                } 
                else if(RocksDodged > 200)
                {
                    AcheivementSystem.Instance.UnlockAchievement("Rock Dodger 4!!");  // Unlock the Rock Dodger 4!! achievement
                    Debug.Log("Achievement Unlocked: Rock Dodger 4!!");
                }
        }
    }
}
