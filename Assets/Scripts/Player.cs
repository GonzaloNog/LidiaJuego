using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Characters;

public class Player : Fighter, IDamageable
{
    public GameObject model3D;
    public float sensibilidadH, sensibilidadV;
    public float rotateH, rotateV;
    public Camera cam;
    public float slowSpeed = 5f;
    public float fastSpeed = 10f;
    public float currentSpeed;
    public GameObject ejeTarget;
    public GameObject ejeCamera;
    public float moveHorizontal;
    public float moveVertical;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody not found.");
        }
        currentSpeed = slowSpeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (rb != null)
        {
            Vector3 camForward = cam.transform.forward;
            Vector3 camRight = cam.transform.right;

            camForward.y = 0;
            camRight.y = 0;

            camForward.Normalize();
            camRight.Normalize();
            model3D.transform.forward = camForward;
            Vector3 movement = camForward * moveVertical + camRight * moveHorizontal;

            rb.linearVelocity = new Vector3(movement.x * currentSpeed, rb.linearVelocity.y, movement.z * currentSpeed);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
       
        
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = fastSpeed;
        }
        else
        {
            currentSpeed = slowSpeed;
        }
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformInteraction();
        }

        if (target != null && toAttack)
        {
            Attack();
            toAttack = false;
        }

    }

    void PerformInteraction()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attributes.attackRange))
        {
            Debug.DrawLine(transform.position, hit.point, Color.green);

            if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
            }
        }
    }


    virtual public void Talk()
    {
        if (target == null)
        {
            Debug.LogWarning("There is not objet to takl with.");
            return;
        }

        NPC targetNPC;

        if (target.TryGetComponent<NPC>(out targetNPC))
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= attributes.attackRange)
            {

            }
            else
            {
                Debug.Log($"{targetNPC.attributes.nombre} it's too far away.");
            }
        }
        else
        {
            Debug.LogWarning("You can't speak with " + target.name + ".");
        }

    }


    public override void TakeDmg(float damage)
    {
        base.TakeDmg(damage / 2);
    }
}