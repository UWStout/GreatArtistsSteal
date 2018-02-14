using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //How fast the player moves (sneaking)
    public float topSpeed = 5f;

    //determine sprite direction
    bool faceRight = true;

    //checks if player is grounded (if player is grounded, can jump, if not, can not)
    bool grounded = false;//not grounded
    public Transform groundCheck;//transform at player feet to check if grounded or not
    float groundRadius = 0.2f;//how large the circle is when checking distance to ground
    public float jumpForce = 300f;//how high the player can jump
    public LayerMask whatIsGround;//checks which layer is currently considered the ground

    //physics in fixed update
    private void FixedUpdate()
    {
        //true or false output for whether the ground transform hit the whatIsGround with the groundRadius
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //get movement direction of player
        float move = Input.GetAxis("Horizontal");
        //add velocity to the direction of player
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //if facing negative direction and not facing the right FLIP
        if (move > 0 && !faceRight)
        {
            Flip();
        }else if (move < 0 && faceRight)//re-flips the sprite to the original direction if going back
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
