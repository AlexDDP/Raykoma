using System;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public static Boolean spawnCoins;
    public float spawnDistance = 15f;
    public float spawnMin = -4.5f;
    public float spawnTop = 0;
    public float yInc = 4.5f;
    public int coinsPerSpawn;
    public float timeTilSpawn = 5.0f;
    public float timer;
    public GameObject boat;

    void Start()
    {
        coinsPerSpawn = 1;
        timer = timeTilSpawn;
        spawnCoins = true;
    }

    void Update()
    {
        if (timer < 0.0f && spawnCoins)
        {
            spawnTop = 0f;
            spawnMin = -4.5f;

            for (int i = 0; i < coinsPerSpawn; i++)
            {
                float randomY = UnityEngine.Random.Range(spawnMin, spawnTop);
                float randomOffsetX = UnityEngine.Random.Range(-3f, 5f);
                Vector2 spawnPosition = new Vector2(spawnDistance + randomOffsetX, randomY);

                // Instantiate the rock
                GameObject coin = Instantiate(Coin, spawnPosition, Quaternion.identity);
                if (coin != null)
                {
                    ObjectDespawn crocDespawn = coin.GetComponent<ObjectDespawn>();
                }

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