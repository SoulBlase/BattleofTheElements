using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
{
    [Header("Player 1 Hitboxes")]
    public Collider2D HeadCollider1;
    public Collider2D TorsoCollider1;
    public Collider2D LegsCollider1;

    [Header("player 2 Hitboxes")]
    public Collider2D HeadCollider2;
    public Collider2D TorsoCollider2;
    public Collider2D LegsCollider2;

    [Header ("Health Damage")]
    [Range(0f, 100f)]
    public float HeadHealthDamage;
    [Range(0f, 100f)]
    public float TorsoHealthDamage;
    [Range(0f, 100f)]
    public float LegsHealthDamage;

    private bool Blocking = false;

    void Start()
    {
        //this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D HitCol)
    {
        if(HitCol.gameObject.tag == "Head Hitboxes" && Blocking == false)
        {
            HeadHealthDamage -= DamageTaken.HealthP1;
        }
    }
}
