using UnityEngine;

public class HeartChange1 : MonoBehaviour
{
    public Sprite[] heartSprites = new Sprite[4]; 
    private SpriteRenderer spriteRenderer;
    public static int life;

    void Start()
    {
        life = GameProperties.healthPoints1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        life = Mathf.Max(GameProperties.healthPoints1, 0);
        spriteRenderer.sprite = heartSprites[life];
    }
}
