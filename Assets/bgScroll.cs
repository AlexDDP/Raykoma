using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject background1;  // First background tile
    public GameObject background2;  // Second background tile
    public static float scrollSpeed = 5f;  // Speed at which the background scrolls
    public float tileWidth = 19.8f;   // Width of one background tile (adjust based on your texture)

    void Update()
    {
        // Move both background tiles to the left
        background1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        background2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Check if background1 has gone off-screen
        if (background1.transform.position.x <= -tileWidth)
        {
            // Move background1 to the right of background2 to create the infinite loop effect
            background1.transform.position = new Vector3(background2.transform.position.x + tileWidth, background1.transform.position.y, background1.transform.position.z);
        }

        // Check if background2 has gone off-screen
        if (background2.transform.position.x <= -tileWidth)
        {
            // Move background2 to the right of background1 to create the infinite loop effect
            background2.transform.position = new Vector3(background1.transform.position.x + tileWidth, background2.transform.position.y, background2.transform.position.z);
        }
    }
}
