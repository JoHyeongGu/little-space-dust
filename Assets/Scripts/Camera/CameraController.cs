using UnityEngine;

public class CameraController : SingletonMono<CameraController>
{
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;

    protected override void Awake()
    {
        base.Awake();
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        smoothedPosition.z = -10f;
        transform.position = smoothedPosition;
    }
}
