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
    public float timeTilSpawnMax;
    public float timer;
    public GameObject boat;

    void Start()
    {
        timeTilSpawnMax = 15f ;
        timer = 5f;
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

                ObjectDespawn crocDespawn = crocodile.GetComponent<ObjectDespawn>();
     

                spawnMin += yInc;
                spawnTop += yInc;
            }

            if (timeTilSpawnMax > 10f) timeTilSpawnMax -= 0.2f;
            timer = UnityEngine.Random.Range(5f, timeTilSpawnMax);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
