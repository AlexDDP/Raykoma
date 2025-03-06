using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;  
    public float spawnDistance = 15f;  
    public Vector2 spawnAreaMin;  
    public Vector2 spawnAreaMax; 
    public int rocksPerSpawn = 3;
    public float timeTilSpawn = 5.0f;
    public GameObject boat; 

    void Start()
    {
        timeTilSpawn = 5.0f;
    }

    void Update()
    {
        if (timeTilSpawn < 0.0f)
        {
            Debug.Log("Spawn");
            for (int i = 0; i < rocksPerSpawn; i++)
            {
                float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                float randomOffsetX = Random.Range(-2f, 2f);
                Vector2 spawnPosition = new Vector2(spawnDistance + randomOffsetX, randomY);

                // Instantiate the rock
                GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);

                // Get the RockDespawn component from the rock and assign the boat reference
                RockDespawn rockDespawn = rock.GetComponent<RockDespawn>();
                if (rockDespawn != null)
                {
                    rockDespawn.boat = boat;  // Assign the boat reference dynamically
                }
            }
            timeTilSpawn = 5.0f;
        }
        else
        {
            timeTilSpawn -= Time.deltaTime;
        }
    }

}