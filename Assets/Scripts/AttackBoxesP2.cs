using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxesP2 : MonoBehaviour
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

    public StatusBars HealthP1;
    //public StatusBars HealthP2;


    //public Player1Controller owner;

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
        
        if(HitCol.gameObject.tag == "P1 Head Hitboxes" && Blocking == false)
        {
            //HealthP1.healthValue -= HeadHealthDamage;
            HealthP1.AdjustHealth(-HeadHealthDamage);
            Debug.Log("Player 1: " + HealthP1.healthValue);
        }
        else if(HitCol.gameObject.tag == "P1 Torso Hitboxes" && Blocking == false)
        {
            HealthP1.AdjustHealth(-TorsoHealthDamage);
            Debug.Log("Player 1: " + HealthP1.healthValue);
        }
        else if(HitCol.gameObject.tag == "P1 Legs Hitboxes" && Blocking == false)
        {
            HealthP1.AdjustHealth(-LegsHealthDamage);
            Debug.Log("Player 1: " + HealthP1.healthValue);
        }
        
        /*
        if(HitCol.gameObject.tag == "P2 Head Hitboxes" && Blocking == false)
        {
            HealthP2.healthValue -= HeadHealthDamage;
            Debug.Log("Player 2: " + HealthP2.healthValue);
        }
        else if(HitCol.gameObject.tag == "P2 Torso Hitboxes" && Blocking == false)
        {
            HealthP2.healthValue -= TorsoHealthDamage;
            Debug.Log("Player 2: " + HealthP2.healthValue);
        }
        else if(HitCol.gameObject.tag == "P2 Legs Hitboxes" && Blocking == false)
        {
            HealthP2.healthValue -= LegsHealthDamage;
            Debug.Log("Player 2: " + HealthP2.healthValue);
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
