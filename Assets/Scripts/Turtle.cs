using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public override void TakeDmg(float damage)
    {
        base.TakeDmg(damage/2);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && toAttack)
        {
            Attack();
            toAttack = false;
        }
        else
        {
            Attack();
            toAttack=true;
        }
    }
}
