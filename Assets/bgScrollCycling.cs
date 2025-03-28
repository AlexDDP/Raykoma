using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ScrollingBackgroundCycle : MonoBehaviour
{
    public GameObject background1;  // First background tile
    public GameObject background2;  // Second background tile
    public GameObject background3;  // Second background tile
    public static float scrollSpeed;  // Speed at which the background scrolls
    public float tileWidth;   // Width of one background tile (adjust based on your texture)
    public float pivot;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        tileWidth = ((Vector2) sr.sprite.bounds.size * transform.lossyScale).x;
        pivot = 25f;
        scrollSpeed = GameProperties.objectMoveSpeed;
    }
    void Update()
    {
        scrollSpeed = GameProperties.objectMoveSpeed;
        // Move both background tiles to the left
        background1.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        background2.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        background3.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Check if background1 has gone off-screen
        if (background1.transform.position.x <= -pivot)
        {
            // Move background1 to the right of background2 to create the infinite loop effect
            background1.transform.position += new Vector3(tileWidth * 3, 0, 0);
        }

        // Check if background2 has gone off-screen
        if (background2.transform.position.x <= -pivot)
        {
            // Move background2 to the right of background1 to create the infinite loop effect
            background2.transform.position += new Vector3(tileWidth * 3, 0, 0);
        }
        // Check if background2 has gone off-screen
        if (background3.transform.position.x <= -pivot)
        {
            // Move background2 to the right of background1 to create the infinite loop effect
            background3.transform.position += new Vector3(tileWidth * 3, 0, 0);
        }
    }
}
