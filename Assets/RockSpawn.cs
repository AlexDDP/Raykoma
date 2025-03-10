using System;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public static Boolean spawnRocks;
    public float spawnDistance = 15f;
    public float spawnMin = -4.5f;
    public float spawnTop = 0f;
    public float yInc = 4.5f;
    public int rocksPerSpawn;
    public float timeTilSpawn = 5.0f;
    public float timer;
    public GameObject boat;

    void Start()
    {
        rocksPerSpawn = 2;
        timer = timeTilSpawn;
        spawnRocks = true;
    }

    void Update()
    {
        if (timer < 0.0f && spawnRocks)
        {
            spawnTop = 0f;
            spawnMin = -4.5f;

            for (int i = 0; i < rocksPerSpawn; i++)
            {
                float randomY = UnityEngine.Random.Range(spawnMin, spawnTop);
                float randomOffsetX = UnityEngine.Random.Range(-3f, 5f);
                Vector2 spawnPosition = new Vector2(spawnDistance + randomOffsetX, randomY);

                // Instantiate the rock
                GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);

                // Get the RockDespawn component from the rock and assign the boat reference
                RockDespawn rockDespawn = rock.GetComponent<RockDespawn>();
                if (rockDespawn != null)
                    rockDespawn.boat = boat;  // Assign the boat reference dynamically

                spawnMin += yInc;
                spawnTop += yInc;
            }
            if (timeTilSpawn > 2f) timeTilSpawn -= 0.2f;
            timer = UnityEngine.Random.Range(1f, timeTilSpawn);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}