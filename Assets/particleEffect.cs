using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public GameObject effects; // Assign your particle prefab in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rock")) // Make sure rocks have the "Rock" tag
        {
            Debug.Log("Boat hit a rock!"); // Debugging

            // Instantiate particle effect at the boat's position
            GameObject effectInstance = Instantiate(effects, transform.position, Quaternion.identity);

            // Get the ParticleSystem component and play it
            ParticleSystem ps = effectInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play(); // Manually play the particle effect
            }

            // Destroy the effect after it's done playing
            Destroy(effectInstance, ps.main.duration);
        }
    }
}
