using System;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public float CurrentHealth {get; private set;}
    public float MaxHealth {get; private set;}

    public UnityEvent onDeath;


    public void Initialize(float maxLife)
    {
        MaxHealth = maxLife;
        CurrentHealth = MaxHealth;
    }

    public void HealthChange(float lifeChange)
    {
        float newLife = CurrentHealth + lifeChange;

        CurrentHealth = Mathf.Clamp(newLife, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            onDeath?.Invoke();
        }
    }
}