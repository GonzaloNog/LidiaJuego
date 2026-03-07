using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter, IDamageable

{
    
    void Start()
    {
        attributes.aggresive = true;
    }

    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody not found.");
        }
    }

    public override void Attack()
    {
        if (target == null)
        {
            Debug.LogWarning("No objetive assigned to attack.");
            return;
        }

        Fighter scriptObjetive;

        if (target.TryGetComponent<Fighter>(out scriptObjetive))
        {
            if (Vector3.Distance(transform.position, target.position) <= attributes.attackRange)
            {
                if (scriptObjetive != null)
                {
                    scriptObjetive.TakeDmg(attributes.dmg);
                    Debug.Log($"{this.gameObject.name} ataca a {target.name} por {attributes.dmg} de daño.");

                }
            }
            else
            {
                Debug.LogWarning($"{target.name} is too far away.");
            }

            Debug.LogWarning($"{target.name} doesn't have script.");
        }
    }
}
