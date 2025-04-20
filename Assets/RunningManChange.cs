using UnityEngine;

public class RunningManChange : MonoBehaviour
{
    public Sprite[] characterPositions = new Sprite[4]; 
    private SpriteRenderer spriteRenderer;
    public float iterationTime;
    public float timer;
    public static int index;

    void Start()
    {
        index = 0;
        iterationTime = 0.2f;
        timer = iterationTime;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if(timer < 0)
        {
            index++;
            if (index == 4) index = 0;
            spriteRenderer.sprite = characterPositions[index];
            timer = iterationTime;
        }
        timer -= Time.deltaTime;
        
    }
}
