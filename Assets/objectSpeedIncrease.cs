using UnityEngine;

public class objectSpeedIncrease : MonoBehaviour
{
    public float time10s = 10f;
    public float timeTilBoost;
    void Start()
    {
        timeTilBoost = time10s;
    }

    void Update()
    {
        if (timeTilBoost > 0)
        {
            timeTilBoost -= Time.deltaTime;
        }
        if (timeTilBoost <= 0 && GameProperties.objectMoveSpeed < 9f)
        {
            timeTilBoost = time10s;
            GameProperties.objectMoveSpeed = (float)(GameProperties.objectMoveSpeed * 1.2);
        }
    }
}
