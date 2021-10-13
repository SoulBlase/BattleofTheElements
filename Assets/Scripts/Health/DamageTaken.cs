using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken : MonoBehaviour
{
    //Player 1
    public static float HealthP1;
    public static float maxHealthP1 = 100f;

    //Player 2
    public static float HealthP2;
    public static float maxHealthP2 = 100f;

    //public string fighterName;

    void Start()
    {
        HealthP1 = maxHealthP1;
        HealthP2 = maxHealthP2;
    }

    void Update()
    {
        //Tells how much health is in player 1 and two
        Debug.Log("Player 1 Health: " + HealthP1 + "Player 2 Health: " + HealthP2);
    }

    public float healthPercent
    {
        get
        {
          return HealthP1 / maxHealthP1;
        }
    }
}
