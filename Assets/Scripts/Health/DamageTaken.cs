using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    //Players Health
    public float Health;
    public float maxHealth = 100f;


    //[RequireComponent(typeof(Animator))]

    //public string fighterName;

    void Start()
    {
        Health = maxHealth;
    }

    void Update()
    {
        //Tells how much health is in player 1 and 2
        //Debug.Log("Player 1 Health: " + HealthP1 + " | Player 2 Health: " + HealthP2);
    }

    public float healthPercent
    {
        get
        {
          return Health / maxHealth;
        }
    }

    public virtual void hurt(float damage)
    {
        if(Health >= damage)
        {
            Health -= damage;
        }
        else
        {
            Health = 0;
        }

        if(Health > 0)
        {
            Animator a = GetComponent<Animator>();
            a.SetTrigger("Hit");
        }

    }
}
