using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(target != null && toAttack)
        {
            Attack();
            toAttack = false;
        }
        else
        {
            Attack();
            toAttack = true;
        }
    }
}
