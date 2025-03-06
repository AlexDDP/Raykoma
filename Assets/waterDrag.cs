using UnityEngine;

public class waterDrag : MonoBehaviour
{   
    public Rigidbody2D drag;
    public float timeTilExpand = 0.3f;
    public float timer;
    public float pivotPos;
    public float prevPivot;
    public float spriteWidth;
    public float scaleIncrease = 0.25f;
    private void Start()
    {
        timer = timeTilExpand;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        pivotPos = -1.22f - (spriteWidth / 2);
        prevPivot = pivotPos;
        drag = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        if(timer <= 0)
        {
            // makes drag longer
            transform.localScale += new Vector3(scaleIncrease, 0f, 0f);
            // finds sprite width after being scaled
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            // calculation for where new pivot point should be (left side of kayak - half the width of sprite);
            pivotPos = -1.22f - (spriteWidth / 2);
            // incrementing its position based on the difference of current and previous pivot positon
            transform.localPosition += new Vector3(pivotPos - prevPivot, 0f, 0f);
            // update old pivot positon
            prevPivot = pivotPos;
            timer = 0.3f;
        }
        else
        {
            timer -= Time.deltaTime; 
        }
    }
}
