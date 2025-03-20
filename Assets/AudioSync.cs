using UnityEngine;

public class MusicSpeedController : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component
    public float pitchIncreaseRate = 0.01f;  // Rate at which the pitch increases
    public float maxPitch = 2f;  // Maximum pitch (speed) limit

    private float timePassed = 0f;  // Time elapsed in the game

    void Start()
    {
        // Get the AudioSource component (if not already assigned)
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Increase time passed (you could also base this on game events)
        timePassed += Time.deltaTime;

        // Increase the pitch based on how much time has passed
        float targetPitch = 1f + timePassed * pitchIncreaseRate;

        // Clamp the pitch to not exceed the maximum limit
        audioSource.pitch = Mathf.Min(targetPitch, maxPitch);
    }
}
