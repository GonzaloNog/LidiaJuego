using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float speedSprint = 10f;
    public float speedRotation = 10f;
    public float jumpForce = 10;

    public Transform camaraTransform;
    public ThisPersonCamera camaraPlayer;

    private float finishSpeed;
    private Rigidbody rb;
    private Vector3 movement;
    private bool isGround;
    private bool combate = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(combate)
            modoCombate();
        else
            movimiento();
    }
    private void FixedUpdate()
    {

        Vector3 velocity = movement * finishSpeed;
        Vector3 newVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        rb.linearVelocity = newVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Combate");
            combate = true;
            camaraPlayer.setCombate(true);
            LevelManager.instance.camaraSwitch("combate");
            rb.isKinematic = true;
            this.gameObject.transform.position = LevelManager.instance.combate.playerStart.position;
            this.gameObject.transform.rotation = LevelManager.instance.combate.playerStart.rotation;
            collision.gameObject.transform.position = LevelManager.instance.combate.enemigoStart.position;
            collision.gameObject.transform.rotation = LevelManager.instance.combate.enemigoStart.rotation;
        }
        else
            isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
        else
            isGround = false;
    }

    public void movimiento()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camaraTransform.eulerAngles.y;
            Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speedRotation * Time.deltaTime);

            movement = targetRotation * Vector3.forward;
        }
        else
            movement = Vector3.zero;
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finishSpeed = speedSprint;
        }
        else
        {
            finishSpeed = speed;
        }
    }
    public void modoCombate()
    {

    }
}
