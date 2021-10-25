using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject Punch;
    public GameObject Body;
    public GameObject Kick;
    [Range(0f, 10f)]
    public float[] HitPeak1;
    [Range(0f, 10f)]
    public float[] HitPeak2;
    
    public enum PlayerType
    {
        Human, AI
    }

    public GameObject player;

    public string fighterName;

    public PlayerType character;
    public FighterStates currentState = FighterStates.Idle;

    private Rigidbody myBody;
    protected Animator animate;

    public DamageTaken playerHealth;

    public Player1Controller opponent;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animate = player.GetComponent<Animator>();
    }

    //Hit Timings
    private IEnumerator HitTimingPunch()
    {
        yield return new WaitForSeconds(HitPeak1[0]);
        Punch.SetActive(true);
        yield return new WaitForSeconds(HitPeak2[0]);
        Punch.SetActive(false);
    }

    private IEnumerator HitTimingBody()
    {
        yield return new WaitForSeconds(HitPeak1[1]);
        Body.SetActive(true);
        yield return new WaitForSeconds(HitPeak2[1]);
        Body.SetActive(false);
    }

    private IEnumerator HitTimingKick()
    {
        yield return new WaitForSeconds(HitPeak1[2]);
        Kick.SetActive(true);
        yield return new WaitForSeconds(HitPeak2[2]);
        Kick.SetActive(false);
    }

    public void FixedUpdateHumanInput()
    {
        if (Input.GetAxis("Horizontal") > 0.1)
        {
            animate.SetBool("Walk", true);
            Debug.Log("Walking Works");
        }
        else
        {
            animate.SetBool("Walk", false);
        }

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animate.SetBool("Walk", true);
        }
        else
        {
            animate.SetBool("Walk_Back", false);
        }

        if(Input.GetAxis("Vertical") < -0.1)
        {
            animate.SetBool("Crouch", true);
        }
        else
        {
            animate.SetBool("Crouch", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animate.SetTrigger("Jump");
            Debug.Log("Jump works");

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            animate.SetTrigger("Punch");
            StartCoroutine(HitTimingPunch());
            Debug.Log("Animation works");

            animate.SetTrigger("Punch");
            Debug.Log("Punch works");

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animate.SetBool("Block", true);
            Debug.Log("Block works");
        }
        else
        {
            animate.SetBool("Block", false);
        }
    }

    void FixedUpdate()
    {

        animate.SetFloat("Health", playerHealth.healthPercent);
        if (opponent != null)
        {
            animate.SetFloat("Opponent_Health", opponent.playerHealth.healthPercent);
        }
        else
        {
            animate.SetFloat("Opponent_Health", 1);
        }

        if (character == PlayerType.Human)
        {
            FixedUpdateHumanInput();
        }

        StayBetweenHit();
    }

    public bool attacking
    {
        get
        {
            return currentState == FighterStates.Attack;
        }

    }

    public Rigidbody body
    {
        get
        {
            return myBody;
        }
    }

    //So the HitPeak stay in between
    private void StayBetweenHit()
    {
        if(HitPeak1[0] >= HitPeak2[0])
        {
            HitPeak1[0] = HitPeak2[0] - 1f;
        }
        if(HitPeak1[1] >= HitPeak2[1])
        {
            HitPeak1[1] = HitPeak2[1] - 1f;
        }
        if(HitPeak1[2] >= HitPeak2[2])
        {
            HitPeak1[2] = HitPeak2[2] - 1f;
        }
    }
}
