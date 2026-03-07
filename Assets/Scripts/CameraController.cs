using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform pivot;
    [SerializeField]
    private float distanceFromTarget;
    [SerializeField]
    private float smoothTime;

    private float rotationY;
    private float rotationX;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private Vector2 rotationXMinMax = new Vector2(-40, 40);


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX += mouseY;

        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(rotationX, rotationY);

        //currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        pivot.localEulerAngles = nextRotation;

        //transform.position = target.position - transform.forward * distanceFromTarget;
    }
}
