using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    public GameObject crocodilePrefab; 
    public float spawnInterval = 3f;  
    public float spawnRangeX = 5f;    
    public float spawnHeight = 4f;    

    private void Start()
    {
        InvokeRepeating("SpawnCrocodile", 0f, spawnInterval);
    }

    void SpawnCrocodile()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnY = Random.Range(-spawnHeight, spawnHeight);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // instantiate 
        Instantiate(crocodilePrefab, spawnPosition, Quaternion.identity);
    }
}
