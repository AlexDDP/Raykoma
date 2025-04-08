using UnityEngine;
using System.Collections;  // Required for coroutines

public class FinishLineSpawner : MonoBehaviour
{
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

    void SpawnFinishLine()
    {
        moveSpeed = GameProperties.objectMoveSpeed;

        // Spawn the finish line 5 units ahead of the camera
        Vector3 spawnPos = new Vector3(15f, 0, 0.1f);  // Adjust X (camera + 5 units)

        Debug.Log("Spawning Finish Line at: " + spawnPos);

        // Check if prefab is assigned and instantiate it
        if (finishLinePrefab != null)
        {
            finishLineInstance = Instantiate(finishLinePrefab, spawnPos, Quaternion.identity);
            Debug.Log("Finish Line Spawned!");

            // Start moving the finish line towards the player
            StartCoroutine(MoveFinishLine());
        }
 
    }

    IEnumerator MoveFinishLine()
    {
        moveSpeed = GameProperties.objectMoveSpeed;
        // Move the finish line towards the boat
        while (finishLineInstance != null)
        {
            float moveY = finishLineInstance.transform.position.y;  // Keep Y position the same (or change if needed)

            // Update position by moving towards the camera's X
            finishLineInstance.transform.position = Vector3.MoveTowards(finishLineInstance.transform.position,
                                                                        new Vector3(Camera.main.transform.position.x - 5f, moveY, finishLineInstance.transform.position.z),
                                                                        moveSpeed * Time.deltaTime);
            yield return null;  // Wait until the next frame
        }
    }
}
