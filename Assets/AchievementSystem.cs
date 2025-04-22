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
        public int progress;
        public int targetProgress;
        public int rewardCoins;
    }

    public static AchievementSystem Instance;

    [Header("Achievement List (auto-filled)")]
    public List<Achievement> achievements = new List<Achievement>();

    [Header("UI Elements")]
    public GameObject popupPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    [Header("Sound")]
    public AudioClip achievementSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
        }
        else
        {
            Destroy(gameObject);
        }

        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Start()
    {
        //if (achievements.Count == 0)
        //{
            AddCollisionBasedAchievements();
       // }

        LoadAchievements();
    }

    void AddCollisionBasedAchievements()
    {
        achievements = new List<Achievement>
        {
            new Achievement { id = "rock1", title = "Rock Survivor I", description = "Survive 10 rock hits", targetProgress = 10, rewardCoins = 50 },
            new Achievement { id = "rock2", title = "Rock Survivor II", description = "Survive 30 rock hits", targetProgress = 30, rewardCoins = 100 },
            new Achievement { id = "rock3", title = "Rock Survivor III", description = "Survive 50 rock hits", targetProgress = 50, rewardCoins = 150 },

            new Achievement { id = "croco1", title = "Crocodile Survivor I", description = "Survive 10 crocodile hits", targetProgress = 10, rewardCoins = 25 },
            new Achievement { id = "croco2", title = "Crocodile Survivor II", description = "Survive 25 crocodile hits", targetProgress = 25, rewardCoins = 50 },
            new Achievement { id = "croco3", title = "Crocodile Survivor III", description = "Survive 45 crocodile hits", targetProgress = 45, rewardCoins = 75 },
        };
    }

    public void Unlock(string id)
    {
        Achievement achievement = achievements.Find(a => a.id == id);
        if (achievement == null || achievement.isUnlocked)
            return;

        achievement.progress++;

        PlayerPrefs.SetInt(achievement.id + "_progress", achievement.progress);
        PlayerPrefs.Save();

        if (achievement.progress >= achievement.targetProgress)
        {
            achievement.isUnlocked = true;

            int currentCoins = PlayerPrefs.GetInt("Coins", 0);
            currentCoins += achievement.rewardCoins;
            PlayerPrefs.SetInt("Coins", currentCoins);
            PlayerPrefs.Save();

            SaveAchievements();
            ShowPopup(achievement);

            Debug.Log($"Unlocked: {achievement.title} (+{achievement.rewardCoins} coins)");
        }
    }

    void ShowPopup(Achievement achievement)
    {
        if (popupPanel == null || titleText == null || descriptionText == null)
        {
            Debug.LogError("UI elements not assigned!");
            return;
        }

        titleText.text = achievement.title;
        descriptionText.text = achievement.description + $" (+{achievement.rewardCoins} coins)";
        popupPanel.SetActive(true);

        // Play sound
        if (achievementSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(achievementSound);
        }

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

    void SaveAchievements()
    {
        foreach (var a in achievements)
        {
            PlayerPrefs.SetInt(a.id + "_progress", a.progress);
            PlayerPrefs.SetInt(a.id + "_unlocked", a.isUnlocked ? 1 : 0);
        }
        PlayerPrefs.Save();
    }

    void LoadAchievements()
    {
        foreach (var a in achievements)
        {
            a.progress = PlayerPrefs.GetInt(a.id + "_progress", 0);
            a.isUnlocked = PlayerPrefs.GetInt(a.id + "_unlocked", 0) == 1;
        }
    }
}
