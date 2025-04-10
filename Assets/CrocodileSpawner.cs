using System;
using UnityEngine;

public class CrocodileSpawner : MonoBehaviour
{
    public GameObject crocodilePrefab;
    public static bool spawnCrocodiles = true;
    public float spawnDistance = 15f;
    public float spawnMin = -4.5f;
    public float spawnTop = 0;
    public float yInc = 4.5f;
    public int crocsPerSpawn = 1;
    public float timeTilSpawn = 5.0f;
    public float timer;

    void Start()
    {
        timer = timeTilSpawn;
    }

    void Update()
    {
        if (timer <= 0.0f && spawnCrocodiles)
        {
            spawnTop = 0f;
            spawnMin = -4.5f;

            for (int i = 0; i < crocsPerSpawn; i++)
            {
                float randomY = UnityEngine.Random.Range(spawnMin, spawnTop);
                float randomOffsetX = UnityEngine.Random.Range(-3f, 5f);
                Vector2 spawnPosition = new Vector2(spawnDistance + randomOffsetX, randomY);

                GameObject crocodile = Instantiate(crocodilePrefab, spawnPosition, Quaternion.identity);

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
