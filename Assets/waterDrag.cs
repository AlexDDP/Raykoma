using System;
using UnityEngine;

public class WaterDrag : MonoBehaviour
{   
    public Rigidbody2D drag;
    public float timeTilExpand = 0.3f;
    public float timer;
    public float pivotPosX;
    public float pivotPosY;
    public float prevPivotX;
    public float prevPivotY;
    public float spriteWidth;
    public float spriteHeigth;
    public float scaleIncreaseX = 0.25f;
    public float scaleIncreaseY = 0.075f;
    public static Boolean terminate = false;
    private void Start()
    {
        timer = timeTilExpand;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteHeigth = GetComponent<SpriteRenderer>().bounds.size.y;
        pivotPosX = -spriteWidth / 2;
        prevPivotX = pivotPosX;
        pivotPosY = -spriteHeigth / 2;
        prevPivotY = pivotPosY;
        drag = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        if (terminate)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        if(timer <= 0 && !terminate)
        {
            // makes drag longer
            transform.localScale += new Vector3(scaleIncreaseX, scaleIncreaseY, 0f);
            // finds sprite width after being scaled
            spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
            spriteHeigth = GetComponent<SpriteRenderer>().bounds.size.y;
            // calculation for where new pivot point should be (half the width of sprite);
            pivotPosX = -spriteWidth / 2;
            pivotPosY = -spriteHeigth / 2;
            // incrementing its position based on the difference of current and previous pivot positon
            transform.localPosition += new Vector3(pivotPosX - prevPivotX, pivotPosY - prevPivotY, 0f);
            // update old pivot positon
            prevPivotX = pivotPosX;
            prevPivotY = pivotPosY;
            timer = 0.3f;
        }
        else
        {
            timer -= Time.deltaTime; 
        }
    }
}
