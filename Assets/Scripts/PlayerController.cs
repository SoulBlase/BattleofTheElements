using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Movement
    public float speed;
    public float jump;
    float moveVelocity;
    //Grounded Vars
    bool grounded = true;
    public CinemachineVirtualCamera vcam;
    private Scene scene;
    int numOfJumps = 0;
    int maxJumps = 1;
    Animator animator;
    
    public bool IsPlayerDead;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            
            if (grounded || numOfJumps < maxJumps)
            {

                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
                numOfJumps += 1;
                           
            }
            if (grounded)
            {
                numOfJumps = 0;
            }
        }

        moveVelocity = 0;

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1f, 1f, -1f);
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            moveVelocity = speed;
        }

        animator.SetFloat("velocityX", moveVelocity);
        animator.SetFloat("velocityY", moveVelocity);

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        /*if(QuickDirtyHealthScript.health <= 0)
        {
            print("you dead");
        	QuickDirtyHealthScript.health = QuickDirtyHealthScript.maxHealth;
        	SceneManager.LoadScene(1);
        }*/
    }

    //Check if Grounded
    void OnCollisionStay2D()
    {
        animator.SetBool("grounded", true);
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        animator.SetBool("grounded", false);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy" || collision.transform.tag == "DestroyingBorder")
        {
        	QuickDirtyHealthScript.health = QuickDirtyHealthScript.maxHealth;
        	SceneManager.LoadScene(1);
            Destroy(gameObject);
            Destroy(vcam);
        }

        if(collision.gameObject.name == "Mission Pole")
        {
            SceneManager.LoadScene(0);
        }
    }
}
