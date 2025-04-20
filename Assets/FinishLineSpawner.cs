using UnityEngine;
using System.Collections;  // Required for coroutines

public class FinishLineSpawner : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject finishLinePrefab;  // Drag in the prefab in Inspector
    public float delay;  // Time before spawning the finish line
    public float moveSpeed;  // Speed at which the finish line moves towards the player
    private GameObject finishLineInstance;  // To store the spawned finish line object

    void Start()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        delay = GameProperties.finishLineTimer; // assigns delay from GAME PROPERTIES file
        Invoke(nameof(SpawnFinishLine), delay);  // Delay before spawning the finish line
    }

    public void SpawnFinishLine()
    {
        moveSpeed = GameProperties.objectMoveSpeed;

        // Spawn the finish line 5 units ahead of the camera
        Vector2 spawnPos = new Vector3(15f, 0, 0.1f);  // Adjust X (camera + 5 units)

        Debug.Log("Spawning Finish Line at: " + spawnPos);

        finishLineInstance = Instantiate(finishLinePrefab, spawnPos, Quaternion.identity);
        rb = finishLineInstance.GetComponent<Rigidbody2D>();
        
 
    }
    public void Update()
    {   
        if (rb)
        {
            moveSpeed = GameProperties.objectMoveSpeed;
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
        }
    }



}
