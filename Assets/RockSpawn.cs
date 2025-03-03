using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;  
    public float spawnDistance = 15f;  
    public float spawnInterval = 2f;  
    public Vector2 spawnAreaMin;  
    public Vector2 spawnAreaMax; 
    public int rocksPerSpawn = 3; 

    public GameObject boat; 

    private float lastSpawnX;

    void Start()
    {
        
        if (boat == null)
        {
            Debug.LogError("Boat reference is not assigned in RockSpawner!");
            return;
        }

        lastSpawnX = boat.transform.position.x;
        InvokeRepeating("CheckAndSpawnRocks", 0f, spawnInterval);  
    }

    void CheckAndSpawnRocks()
    {
        if (boat.transform.position.x >= lastSpawnX + spawnDistance)
        {
            for (int i = 0; i < rocksPerSpawn; i++)
            {
                float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                float randomOffsetX = Random.Range(-2f, 2f);
                Vector2 spawnPosition = new Vector2(boat.transform.position.x + spawnDistance + randomOffsetX, randomY);

                // Instantiate the rock
                GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);

                // Get the RockDespawn component from the rock and assign the boat reference
                RockDespawn rockDespawn = rock.GetComponent<RockDespawn>();
                if (rockDespawn != null)
                {
                    rockDespawn.boat = boat;  // Assign the boat reference dynamically
                }
            }

            lastSpawnX = boat.transform.position.x;
        }
    }

}