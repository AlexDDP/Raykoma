using System.Collections;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    public GameObject crocodilePrefab; // Reference to the crocodile prefab
    public float minSpawnInterval = 2f; // Minimum spawn interval
    public float maxSpawnInterval = 5f; // Maximum spawn interval

    private RockMovement rockMovement; // Reference to RockMovement script

    void Start()
    {
        // Find the RockMovement script in the scene
        rockMovement = FindObjectOfType<RockMovement>();

        if (rockMovement == null)
        {
            Debug.LogError("RockMovement script not found in the scene!");
        }

        // Start the spawn coroutine
        StartCoroutine(SpawnCrocodiles());
    }

    IEnumerator SpawnCrocodiles()
    {
        while (true)
        {
         
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));


            Vector3 spawnPosition = GetRandomSpawnPosition();

            
            GameObject crocodile = Instantiate(crocodilePrefab, spawnPosition, Quaternion.identity);
            CrocodileMovement crocodileMovementScript = crocodile.GetComponent<CrocodileMovement>();

            if (crocodileMovementScript != null && rockMovement != null)
            {

                crocodileMovementScript.moveSpeed = RockMovement.moveSpeed;
            }
        }
    }

    // Get a random spawn position within the camera's view, idk why this is needeed 
    Vector3 GetRandomSpawnPosition()
    {
        Camera camera = Camera.main;
        float cameraWidth = camera.orthographicSize * camera.aspect;
        float cameraHeight = camera.orthographicSize * 2;

        float spawnX = Random.Range(-cameraWidth, cameraWidth);
        float spawnY = Random.Range(-cameraHeight / 2, cameraHeight / 2);

        return new Vector3(spawnX, spawnY, 0f);
    }
}
