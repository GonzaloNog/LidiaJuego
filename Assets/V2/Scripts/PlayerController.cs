using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedSprint = 10f;
    public float speedRotation = 10f;
    public float jumpForce = 10;

    public Transform camaraTransform;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + camaraTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0,targetAngle,0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);

            movement = targetRotation * Vector3.forward;
        }
        else
            movement = Vector3.zero;
        if(Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);

        

        Vector3 velocity = movement * speed;
        Vector3 newVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        rb.linearVelocity = newVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
