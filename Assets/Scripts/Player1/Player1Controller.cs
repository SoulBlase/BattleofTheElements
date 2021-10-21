using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject Punch;
    //public GameObject Body;
    //public GameObject Kick;
    //private bool HitActive = false;
    //private float HitTime;
    [Range(0f, 10f)]
    public float HitPeak1;
    [Range(0f, 10f)]
    public float HitPeak2;
    
    public enum PlayerType
    {
        Human, AI
    }

    public GameObject player;

    public string figherName;

    public PlayerType character;

    private Rigidbody myBody;
    //protected Animator //animate;

    public DamageTaken playerHealth;

    public Player1Controller opponent;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        //animate = player.GetComponent<Animator>();
    }

    private IEnumerator HitTiming()
    {
        yield return new WaitForSeconds(HitPeak1);
        Punch.SetActive(true);
        yield return new WaitForSeconds(HitPeak2);
        Punch.SetActive(false);
    }

    public void FixedUpdateHumanInput()
    {
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            //animate.SetBool("Walk", true);
            Debug.Log("Walking Works");
        }
        else
        {
            //animate.SetBool("Walk", false);
        }

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            //animate.SetBool("Walk", true);
        }
        else
        {
            //animate.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //animate.SetTrigger("Punch");
            StartCoroutine(HitTiming());
            Debug.Log("Animation works");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //animate.SetBool("Block", true);
            Debug.Log("Block works");
        }
        else
        {
            //animate.SetBool("Block", false);
        }
    }

    void FixedUpdate()
    {
        /*if (Input.GetButtonDown("Horizontal"))
        {
            player.GetComponent<Animator>().Play("Walking");
        }*/

        //animate.SetFloat("Health", playerHealth.healthPercent);
        if (opponent != null)
        {
            //animate.SetFloat("Opponent_Health", opponent.playerHealth.healthPercent);
        }
        else
        {
            //animate.SetFloat("Opponent_Health", 1);
        }

        if (character == PlayerType.Human)
        {
            FixedUpdateHumanInput();
        }

        if(HitPeak1 >= HitPeak2)
        {
            HitPeak1 = HitPeak2 - 1f;
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.myBody;
        }
    }
}
