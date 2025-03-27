using UnityEngine;

public class RockDespawn : MonoBehaviour
{
    public GameObject boat;  // Reference to the boat
    public float despawnDistance = 30f;  // Distance at which rocks despawn

    public int rocksDodged = 0; // Number of rocks dodged

    public coinAccum coinNum; // Reference to the coin amount



    void Update()
    {
        if (boat != null)
        {
            // Check if the rock is beyond a certain distance from the boat
            if (Mathf.Abs(transform.position.x - boat.transform.position.x) > despawnDistance)
            {
                Destroy(gameObject);  // Destroy the rock object
                rocksDodged++;  // Increment the number of rocks dodged
                if(rocksDodged > 20)
                {
                    AchievementManager.Instance.UnlockAchievement("Rock dodger 1!!!"); // Unlock the achievement
                    Debug.Log("Achievement Unlocked: Rock dodger 1!!!");
                    coinAccum.coins += 50; // Add 50 coins to the player's total
                } else if(rocksDodged > 50)
                {
                    AchievementManager.Instance.UnlockAchievement("Rock dodger 2!!!"); // Unlock the achievement
                    Debug.Log("Achievement Unlocked: Rock dodger 2!!!");
                    coinAccum.coins += 100; // Add 100 coins to the player's total
                } else if(rocksDodged > 100)
                {
                    AchievementManager.Instance.UnlockAchievement("Rock dodger 3!!!"); // Unlock the achievement
                    Debug.Log("Achievement Unlocked: Rock dodger 3!!!");
                    coinAccum.coins += 150; // Add 200 coins to the player's total
                }
            }
        }
}
}
