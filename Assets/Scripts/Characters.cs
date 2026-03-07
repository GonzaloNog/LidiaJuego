using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public abstract class Characters : MonoBehaviour
{
   
    public float t;
   
    public Rigidbody rb;

    [SerializeField]
    public Attributes attributes;
    public Transform target;

    public bool toAttack;

    
}
