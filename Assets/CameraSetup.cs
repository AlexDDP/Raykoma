using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothing = 5f;  

    private Vector3 offset;  

    void Start()
    {
        
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        //This is a change in GitHub
        
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
