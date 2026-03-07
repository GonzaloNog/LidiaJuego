using UnityEngine;

public abstract class Fighter : Characters, IDamageable
{
    public bool dead;
    public float bonusDamage;
    public HealthComponent healthComponent;
    public float Damage => bonusDamage + attributes.dmg;
    public virtual void Attack()
    {
        if (target == null)
        {
            Debug.LogWarning("No objetive assigned to attack.");
            return;
        }

        IDamageable scriptObjetive;

        if (target.TryGetComponent<IDamageable>(out scriptObjetive))
        {
            if (Vector3.Distance(transform.position, target.position) <= attributes.attackRange)
            {
                if (scriptObjetive != null)
                {
                    scriptObjetive.TakeDmg(Damage);
                    Debug.Log($"{this.gameObject.name} ataca a {target.name} por {Damage} de daño.");

                }
            }
            else
            {
                Debug.LogWarning($"{target.name} is too far away.");
            }

            Debug.LogWarning($"{target.name} doesn't have script.");
        }
    }

    public virtual void TakeDmg(float x)
    {
        healthComponent.HealthChange(-x);
    }

    public virtual void OnDead()
    {
        Debug.Log("Dead.");
    }

    public virtual void Start()
    {
        healthComponent.Initialize(attributes.maxLife);

        healthComponent.onDeath.AddListener(OnDead);
    }
    

}
