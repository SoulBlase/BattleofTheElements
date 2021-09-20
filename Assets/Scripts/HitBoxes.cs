using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxes : MonoBehaviour
{

    void Start()
    {
        this.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D HitCol)
    {
        if(HitCol.gameObject.tag == "Attack Hit")
        {
            DamageTaken.health -= 10f;
        }
    }
}
