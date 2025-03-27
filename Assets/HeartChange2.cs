using UnityEngine;

public class HeartChange2 : MonoBehaviour
{
    public Sprite[] heartSprites = new Sprite[4]; 
    private SpriteRenderer spriteRenderer;
    public static int life;

    void Start()
    {
        life = GameProperties.healthPoints2;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        life = Mathf.Max(GameProperties.healthPoints2, 0);
        spriteRenderer.sprite = heartSprites[life];
    }
}
