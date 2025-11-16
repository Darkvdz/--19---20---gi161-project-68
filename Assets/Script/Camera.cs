using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private float fixedZ;
    private float fixedY;

    void Start()
    {
        fixedZ = transform.position.z;
        fixedY = transform.position.y;
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = fixedZ;
        desiredPosition.y = fixedY;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.rotation = Quaternion.identity;
    }
}
