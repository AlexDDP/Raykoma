using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;  
    public float width = 10f;  

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        transform.position = startPosition + new Vector3(offset, 0, 0);
        if (transform.position.x >= width)
        {
            transform.position = startPosition;
        }
    }
}
