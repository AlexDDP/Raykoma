using System;
using UnityEngine;

public class LogSpawn : MonoBehaviour
{
    public GameObject logPrefab;  // Reference to the log prefab
    public static Boolean spawnLogs;  // Control spawning of logs
    public float spawnDistance = 15f;
    public float spawnMin = -4.5f;
    public float spawnTop = 0;
    public float yInc = 4.5f;
    public int logsPerSpawn;  // Control how many logs spawn at a time
    public float timeTilSpawn = 5.0f;
    public float timer;
    public GameObject boat;

    void Start()
    {
        logsPerSpawn = 2;
        timer = timeTilSpawn;
        spawnLogs = true;
    }

    void Update()
    {
        if (timer < 0.0f && spawnLogs)
        {
            spawnTop = 0f;
            spawnMin = -4.5f;

            for (int i = 0; i < logsPerSpawn; i++)
            {
                float randomY = UnityEngine.Random.Range(spawnMin, spawnTop);
                float randomOffsetX = UnityEngine.Random.Range(-3f, 5f);
                Vector2 spawnPosition = new Vector2(spawnDistance + randomOffsetX, randomY);

                // Instantiate the log
                GameObject log = Instantiate(logPrefab, spawnPosition, Quaternion.identity);

                // You can add a LogDespawn component if needed, but it's optional
                LogDespawn logDespawn = log.GetComponent<LogDespawn>();
                if (logDespawn != null)
                    logDespawn.boat = boat;  // Assign the boat reference dynamically

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
