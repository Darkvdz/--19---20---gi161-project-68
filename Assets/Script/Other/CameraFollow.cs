using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Hero targetHero;
    
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    public float minX = -10f; 
    public float maxX = 10f; 
    
    private float fixedZ;
    private float fixedY;

    void Start()
    {
        fixedZ = transform.position.z;
        fixedY = transform.position.y;

        targetHero = FindAnyObjectByType<Hero>(); 
        if (targetHero != null)
            target = targetHero.transform;

    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = fixedZ;
        desiredPosition.y = fixedY;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);

        transform.position = smoothedPosition;
        transform.rotation = Quaternion.identity;
    }
    
    public void SetCameraLimits(float newMinX, float newMaxX)
    {
        minX = newMinX;
        maxX = newMaxX;
    }
}
