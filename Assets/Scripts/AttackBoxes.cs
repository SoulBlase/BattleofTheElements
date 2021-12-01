using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxes : MonoBehaviour
{
    [Header("Health Damage")]
    [Range(0f, 100f)]
    public float HeadHealthDamage;
    [Range(0f, 100f)]
    public float TorsoHealthDamage;
    [Range(0f, 100f)]
    public float LegsHealthDamage;

    [Header("Debug Stuff")]
    private bool Blocking = false;

    public string punchName;
    public float damage;
    
    public Player1Controller owner;

    void Start()
    {
        Blocking = false;
    }

    void Update()
    {
        /*if(Blocking == true)
        {
            //
        }*/
    }

    void OnTriggerEnter(Collider HitCol)
    {
        /*
        if(HitCol.gameObject.tag == "P1 Head Hitboxes" && Blocking == false)
        {
            StatusBars.healthValue -= HeadHealthDamage;
            Debug.Log("Player 1: " + StatusBars.healthValue);
        } 
        else if(HitCol.gameObject.tag == "P1 Torso Hitboxes" && Blocking == false)
        {
            DamageTaken.Health -= TorsoHealthDamage;
            Debug.Log("Player 1: " + DamageTaken.Health);
        }
        else if(HitCol.gameObject.tag == "P1 Legs Hitboxes" && Blocking == false)
        {
            DamageTaken.Health -= LegsHealthDamage;
            Debug.Log("Player 1: " + DamageTaken.Health);
        }

        if(HitCol.gameObject.tag == "P2 Head Hitboxes" && Blocking == false)
        {
            DamageTaken.Health -= HeadHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.Health);
        }
        else if(HitCol.gameObject.tag == "P2 Torso Hitboxes" && Blocking == false)
        {
            DamageTaken.Health -= TorsoHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.Health);
        }
        else if(HitCol.gameObject.tag == "P2 Legs Hitboxes" && Blocking == false)
        {
            DamageTaken.Health -= LegsHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.Health);
        }
        */


        /*
        Player1Controller somebody = HitCol.gameObject.GetComponentInParent<Player1Controller>();

        print("This is the player controller: " + somebody.name);
        if(somebody != null && somebody != owner)
        {
            Debug.Log("I hit" + somebody + "with" + punchName);
        }
        */
    }
}
