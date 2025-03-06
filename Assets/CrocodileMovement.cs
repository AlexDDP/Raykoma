using UnityEngine;

public class CrocodileMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed for crocodile movement
    public float moveRange = 3f; // How far the crocodile moves up and down
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        // Up and down movement using sine wave and Time.deltaTime for frame-rate independence
        float newY = Mathf.Sin(Time.time * moveSpeed) * moveRange + startY;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
