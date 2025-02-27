using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;

    private Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("CameraFollow: Target is not assigned!");
            return;
        }

        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Keep Y and Z unchanged
        float targetX = target.position.x + offset.x;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Smoothly move only on the X-axis
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1 - Mathf.Exp(-smoothing * Time.deltaTime));
    }
}
