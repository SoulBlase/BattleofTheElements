using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
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

    }

    void OnTriggerEnter2D(Collider2D HitCol)
    {
        if(HitCol.gameObject.tag == "P1 Head Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP1 -= HeadHealthDamage;
            Debug.Log("Player 1: " + DamageTaken.HealthP1);
        } 
        else if(HitCol.gameObject.tag == "P1 Torso Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP1 -= TorsoHealthDamage;
            Debug.Log("Player 1: " + DamageTaken.HealthP1);
        }
        else if(HitCol.gameObject.tag == "P1 Legs Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP1 -= LegsHealthDamage;
            Debug.Log("Player 1: " + DamageTaken.HealthP1);
        }

        if(HitCol.gameObject.tag == "P2 Head Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP2 -= HeadHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.HealthP2);
        }
        else if(HitCol.gameObject.tag == "P2 Torso Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP2 -= TorsoHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.HealthP2);
        }
        else if(HitCol.gameObject.tag == "P2 Legs Hitboxes" && Blocking == false)
        {
            DamageTaken.HealthP2 -= LegsHealthDamage;
            Debug.Log("Player 2: " + DamageTaken.HealthP2);
        }

        Player1Controller somebody = HitCol.gameObject.GetComponent<Player1Controller>();
        if(somebody != null && somebody != owner)
        {
            Debug.Log("I hit" + somebody + "with" + punchName);
        }
    }
}
