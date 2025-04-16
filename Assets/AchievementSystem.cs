using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementSystem : MonoBehaviour
{
    [System.Serializable]
    public class Achievement
    {
        public string id;
        public string title;
        public string description;
        public bool isUnlocked;
        public int progress; // For tracking progress (e.g., number of rocks hit)
        public int targetProgress; // Target goal (e.g., hit 10 rocks)
    }

    public static AchievementSystem Instance;

    [Header("Achievement List")]
    public List<Achievement> achievements = new List<Achievement>();

    [Header("UI Elements")]
    public GameObject popupPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Load achievement progress from PlayerPrefs
        LoadAchievements();

        // Ensure popup is hidden on start
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    public void Unlock(string id)
    {
        Debug.Log($"Trying to unlock achievement with ID: {id}");

        Achievement achievement = achievements.Find(a => a.id == id);
        if (achievement == null)
        {
            Debug.LogWarning($"Achievement ID not found: {id}");
            return;
        }

        if (achievement.isUnlocked)
        {
            Debug.Log($"Achievement '{achievement.title}' already unlocked.");
            return;
        }

        // Track progress and unlock if target is met
        achievement.progress++;

        if (achievement.progress >= achievement.targetProgress)
        {
            achievement.isUnlocked = true;
            SaveAchievements(); // Save progress
            ShowPopup(achievement);
        }
    }

    void ShowPopup(Achievement achievement)
    {
        if (popupPanel == null || titleText == null || descriptionText == null)
        {
            Debug.LogError("UI elements not assigned in the inspector!");
            return;
        }

        titleText.text = achievement.title;
        descriptionText.text = achievement.description;
        popupPanel.SetActive(true);

        CancelInvoke(nameof(HidePopup));
        Invoke(nameof(HidePopup), 3f);
    }

    void HidePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    // Save all achievements and progress to PlayerPrefs
    void SaveAchievements()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.id + "_progress", achievement.progress);
            PlayerPrefs.SetInt(achievement.id + "_unlocked", achievement.isUnlocked ? 1 : 0);
        }
        PlayerPrefs.Save();
        Debug.Log("Achievements saved.");
    }

    // Load achievement progress from PlayerPrefs
    void LoadAchievements()
    {
        foreach (var achievement in achievements)
        {
            achievement.progress = PlayerPrefs.GetInt(achievement.id + "_progress", 0);
            achievement.isUnlocked = PlayerPrefs.GetInt(achievement.id + "_unlocked", 0) == 1;
        }
        Debug.Log("Achievements loaded.");
    }
}
