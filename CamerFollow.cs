using UnityEngine;

public class PlayeraCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 1f;

    public Transform background;
    public Vector3 backgroundOffset;
    public float backgroundParallax = 0.01f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            transform.position = smoothedPosition;

            Vector3 backgroundTargetPosition = new Vector3(target.position.x + backgroundOffset.x, target.position.y + backgroundOffset.y, background.position.z);
            Vector3 backgroundSmoothedPosition = Vector3.SmoothDamp(background.position, backgroundTargetPosition, ref velocity, smoothSpeed);
            background.position = backgroundSmoothedPosition;
        }
    }
}
