using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //reference to the PlayerAnimatorController
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //How fast the player moves (sneaking)
    public float topSpeed = 3f;

    //determine sprite direction
    bool faceRight = true;

    //checks if player is grounded (if player is grounded, can jump, if not, can not)
    bool grounded = false;//not grounded
    public Transform groundCheck;//transform at player feet to check if grounded or not
    float groundRadius = 0.2f;//how large the circle is when checking distance to ground
    public float jumpForce = 300f;//how high the player can jump
    public LayerMask whatIsGround;//checks which layer is currently considered the ground

    //checks if player is next to wall (if player is next to wall disable horizontal input (x-axis))
    bool wallNear = false;//not next to a wall on right side
    public Transform wallCheck;//transform at player sides to check if they are close to a wall
    float wallRadius = 0.5f;//how large the circle is when checking distance to wall
    public LayerMask whatIsWall;//checks which layer is currently considered a wall

    //physics in fixed update
    private void FixedUpdate()
    {
        //true or false output for whether the wall transform hit the whatIsWall with the wallRadius
        wallNear = Physics2D.OverlapCircle(wallCheck.position, wallRadius, whatIsWall);

        //true or false output for whether the ground transform hit the whatIsGround with the groundRadius
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //get movement direction of player
        float move = Input.GetAxis("Horizontal");
        //create movement in the player horizontal direction
        //if (wallCheck && (Input.GetKeyDown(KeyCode.A)) || (Input.GetKeyDown(KeyCode.D)))
        //{
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(move));
        //}

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

    private void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //adding jumpforce to the y-axis of the rigidBody
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topSpeed = 6f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            topSpeed = 3f;
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
}
