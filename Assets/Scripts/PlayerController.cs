using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum PlayerType
    {
        Human, AI
    }

    //Movement
    public float speed;
    public float jump;
    private float direction;
    float moveVelocity;

    public GameObject player;

    public string fighterName;

    public PlayerType character;
    public FighterStates currentState = FighterStates.Idle;

    public KeyCode[] attackKey;

    private Rigidbody myBody;
    protected Animator animate;

    public DamageTaken playerHealth;

    //public PlayController opponent;
    public string inputVert;
    public string inputHori;

    public PlayerController opponent;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        animate = player.GetComponent<Animator>();
    }

    public void FixedUpdateHumanInput()
    {
        if (direction > 0)
        {
            animate.SetBool("Walk", true);
            Debug.Log("Walking Works " + direction);
        }
        else
        {
            animate.SetBool("Walk", false);
        }

        if (direction < 0)
        {
            animate.SetBool("Walk_Back", true);
            Debug.Log(direction);
        }
        else
        {
            animate.SetBool("Walk_Back", false);
        }

        if (Input.GetAxis(inputVert) < -0.1)
        {
            animate.SetBool("Crouch", true);
        }
        else
        {
            animate.SetBool("Crouch", false);
        }

        if (inputVert.Equals("Vertical"))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                animate.SetTrigger("Jump");
                Debug.Log("Jump works");

            }
        }

        else if (inputVert.Equals("Vertical2"))
        {
             if (Input.GetKeyDown(KeyCode.UpArrow))
             {
                animate.SetTrigger("Jump");
                Debug.Log("Jump works");

             }
        }
       
        if (Input.GetKeyDown(attackKey[0]))
        {
            animate.SetTrigger("Punch");
            Debug.Log("Punch works");
        }

        if (Input.GetKeyDown(attackKey[1]))
        {
            animate.SetTrigger("Kick");
            Debug.Log("Kick works");
        }

        if (Input.GetKeyDown(KeyCode.M))
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
        direction = Input.GetAxis(inputHori);
        moveVelocity = speed * direction * Time.deltaTime;
        myBody.velocity = new Vector3(0, GetComponent<Rigidbody>().velocity.y, moveVelocity);

        /*animate.SetFloat("Health", playerHealth.healthPercent);
        if (opponent != null)
        {
            animate.SetFloat("Opponent_Health", opponent.playerHealth.healthPercent);
        }
        else
        {
            animate.SetFloat("Opponent_Health", 1);
        }
        */

        if (character == PlayerType.Human)
        {
            FixedUpdateHumanInput();
        }

        //animate.SetFloat("velocityX", moveVelocity);
        //animate.SetFloat("velocityY", moveVelocity);

    }

    public bool Attacking
    {
        get
        {
            return currentState == FighterStates.Attack;
        }
    }
}
