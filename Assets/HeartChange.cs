using UnityEngine;

public class HeartChange : MonoBehaviour
{
    public Sprite[] heartSprites = new Sprite[4]; 
    private SpriteRenderer spriteRenderer;
    public static int life;

    void Start()
    {
        life = GameProperties.healthPoints;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        life = Mathf.Max(GameProperties.healthPoints, 0);
        spriteRenderer.sprite = heartSprites[life];
    }
}
