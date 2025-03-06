using System;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public static Boolean spawnRocks;
    public float spawnDistance = 15f;  
    public Vector2 spawnAreaMin;  
    public Vector2 spawnAreaMax; 
    public int rocksPerSpawn = 3;
    public float timeTilSpawn = 5.0f;
    public float timer;
    public GameObject boat; 

    void Start()
    {
        timer = timeTilSpawn;
        spawnRocks = true;
    }

    void Update()
    {
        if (timer < 0.0f && spawnRocks)
        {
            for (int i = 0; i < rocksPerSpawn; i++)
            {
                float randomY = UnityEngine.Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                float randomOffsetX = UnityEngine.Random.Range(-2f, 2f);
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
            if(timeTilSpawn > 1.6f) timeTilSpawn-=0.2f;
            timer = timeTilSpawn;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}