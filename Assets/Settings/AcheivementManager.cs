using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    [Serializable]
    public class Achievement
    {
        public string name;
        public string description;
        public bool unlocked;
    }

    public List<Achievement> achievements = new List<Achievement>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UnlockAchievement(string achievementName)
    {
        Achievement achievement = achievements.Find(a => a.name == achievementName);
        if (achievement != null && !achievement.unlocked)
        {
            achievement.unlocked = true;
            Debug.Log($"Achievement Unlocked: {achievementName}");
        }
    }
}
