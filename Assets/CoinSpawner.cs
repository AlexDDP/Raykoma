using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    public float spawnDistance = 20f; 
    public float spawnInterval = 4f; 
    public float spawnTop = 0f;
     public Vector2 spawnAreaMin;  
    public Vector2 spawnAreaMax; 
    public int coinsPerSpawn = 1; 
    public float spawnMin = -4.5f;
     public float yInc = 4.5f;
    public float timer = 0f;
    public float timeTilSpawn = 3.0f;

    public GameObject boat;
    private float lastSpawnX;
    void Start()
    {
        if (boat == null) {
            Debug.LogError("Boat reference is not assigned in RockSpawner!");
            return;
        }
        lastSpawnX = boat.transform.position.x;
        InvokeRepeating("CheckAndSpawnCoins", 0f, spawnInterval);  
    }

    void Update() 
    {
        if (timer < 0.0f)
        {
            spawnTop = 0f;
            spawnMin = -4.5f;
        
    
        if (boat.transform.position.x >= lastSpawnX + spawnDistance)
        {            for (int i = 0; i < coinsPerSpawn; i++)
            {
                float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
                float randomOffsetX = Random.Range(-2f, 2f); 
                Vector2 spawnPosition = new Vector2(boat.transform.position.x + spawnDistance + randomOffsetX, randomY);
                Instantiate(Coin, spawnPosition, Quaternion.identity);  

    
        if (timeTilSpawn > 2f) 
        {
         timeTilSpawn -= 0.2f;
        timer = UnityEngine.Random.Range(1f, timeTilSpawn);
        }  

        else
        {
            timer -= Time.deltaTime;
        }
        }

        lastSpawnX = boat.transform.position.x;  
         }

    }
    }
}
  


 
