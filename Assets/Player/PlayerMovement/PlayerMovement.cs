using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //reference to the PlayerAnimatorController
    Animator anim;

    private float counter = 0f;

    public GameObject GUI;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public bool canControl = true;

    //How fast the player moves (sneaking)
    public float topSpeed = 4f;
    bool sprint = false;

    //determine sprite direction
    bool faceRight = true;

    //checks if player is grounded (if player is grounded, can jump, if not, can not)
    bool grounded = false;//not grounded
    public Transform groundCheck;//transform at player feet to check if grounded or not
    float groundRadius = 0.2f;//how large the circle is when checking distance to ground
    public float jumpForce = 200f;//how high the player can jump
    public LayerMask whatIsGround;//checks which layer is currently considered the ground
    public float gravityForce = -40f;

    //physics in fixed update
    private void FixedUpdate()
    {
        if (canControl == true)
        {
            //true or false output for whether the ground transform hit the whatIsGround with the groundRadius
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);//tell the animator that the player is grounded

            //get movement direction of player
            float move = Input.GetAxis("Horizontal");

            

            GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

            anim.SetFloat("Speed", Mathf.Abs(move));

            //if facing negative direction and not facing the right FLIP
            if (move > 0 && !faceRight)
            {
                Flip();
            }
            else if (move < 0 && faceRight)//re-flips the sprite to the original direction if going back
            {
                Flip();
            }
        }
        else if (canControl == false)
        {
            GUI.SetActive(false);
            StartCoroutine(delayPause());
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
        }
        
    }

	GameObject pauseMenu;
    private void Update()
    {
        if (canControl == true)
        {
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
            

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1)
                {
                    //Cursor.visible = true;
                    Time.timeScale = 0;
                    //GameObject.FindGameObjectWithTag("PauseMenu").SetActive(true);
                    //GameObject.Find("PauseMenu").SetActive(false);
                    pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
                    
                }
                else
                {
                    //Cursor.visible = false;
                    Time.timeScale = 1;
                    //GameObject.Find("PauseMenu").SetActive(false);
                    //GameObject.FindGameObjectWithTag("PauseMenu").SetActive(false);
                    pauseMenu.transform.GetChild(0).gameObject.SetActive(false);
                }          

            }


            if ((grounded && Input.GetKeyDown(KeyCode.Space)) || (grounded && Input.GetButtonDown("Jump")))//determines whether or not the player is near the ground and can jump or not
            {
                //adding jumpforce to the y-axis of the rigidBody
                FindObjectOfType<AudioManager>().Play("PlayerJump");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
            if (!grounded)//adding faster fall speed to character when player is not grounded
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, gravityForce));
            }

            /*if (Input.GetKeyDown(KeyCode.S))
            {
                anim.SetBool("Crouching", true);
                if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)))
                {
                    anim.SetBool("CrouchWalk", true);
                    anim.SetBool("KeyDown", true);
                }
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                anim.SetBool("Crouching", false);
                anim.SetBool("CrouchWalk", false);
            }*/


            if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift) || (Input.GetButtonDown("Controller_Sprint")))
            {
                //anim.SetBool("Crouching", false);
                //anim.SetBool("CrouchWalk", false);
                sprint = true;
                topSpeed = 10f;
                
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.RightShift) || (Input.GetButtonUp("Controller_Sprint")))
            {
                topSpeed = 4f;
                sprint = false;
            }
            anim.SetBool("Sprint", sprint);
        }
        else if (canControl == false)
        {
            Debug.Log("Player cant control");
            //gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        
    }

    //flips the direction of the sprite depending on which way the player is facing/moving
    void Flip()
    {
        //face the opposite direction
        faceRight = !faceRight;
        //get local scale
        Vector3 theScale = transform.localScale;
        //flip the sprite on the x axis
        theScale.x *= -1;
        //apply the flip to the local scale of the player
        transform.localScale = theScale;
    }

    
    IEnumerator delayPause()
    {
        yield return new WaitForSeconds(4f);
        
        Time.timeScale = 0;
        
    }

}
