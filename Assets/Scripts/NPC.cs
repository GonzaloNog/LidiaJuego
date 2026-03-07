using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class NPC : Characters, IInteractable
{
    public bool hasTalked = false;
    public List<string> phrases = new List<string>();

    public void Awake()
    {
        attributes.aggresive = false;

         rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("Rigidbody not found.");
        }
        
    }

    public float radius = 3f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Talk()
    {
        Debug.Log("He is talking.");
    }

    public void Interact()
    {
        Talk();
    }
}
   
