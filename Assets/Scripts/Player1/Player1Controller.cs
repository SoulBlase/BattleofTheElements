using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public enum PlayerType
    {
        Human, AI
    }

    public GameObject player;

    public string figherName;

    public PlayerType character;
    public FighterStates currentState = FighterStates.Idle;

    private Rigidbody myBody;
    protected Animator animate;

    public DamageTaken playerHealth;

    public Player1Controller opponent;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animate = player.GetComponent<Animator>();
    }

    public void UpdateHumanInput()
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
            animate.SetBool("Walk_Back", true);
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

    // Update is called once per frame
    void Update()
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
            UpdateHumanInput();
        }
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
}
