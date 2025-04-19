using UnityEngine;

public class AchievementSound : MonoBehaviour
{
    public AudioClip achievementSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (achievementSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(achievementSound);
        }

        // Optional: Trigger any animations or fade-in UI here
    }
}
