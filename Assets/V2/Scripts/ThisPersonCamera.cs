using UnityEngine;

public class ThisPersonCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;

    float xRotation = 0f;
    float yRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse X") * GameManager.instance.mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse Y") * GameManager.instance.mouseSensitivity * Time.deltaTime;

        xRotation += mouseX;
        yRotation += mouseY;
        
        xRotation = Mathf.Clamp(xRotation, 0f, 60f);

        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        Vector3 position = target.position - (rotation * Vector3.forward * distance);
        
        transform.position = position;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
