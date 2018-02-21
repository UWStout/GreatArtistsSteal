using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {

    //determine sprite direction
    bool faceRight = true;

    //left and right wall check
    bool wallCheckL = false;
    bool wallCheckR = false;
    public LayerMask whatIsGuardWall;//determines what is considered a wall for the guard
    float wallRadius = .2f;
    public Transform wallNearL;
    public Transform wallNearR;
    bool movingRight = true;

    bool Patrolling = true;

    //animator
    Animator anim;

    //guard move speed
    public float walkSpeed = 3f;

    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool( "Patrolling",Patrolling);
    }

    private void FixedUpdate()
    {
        wallCheckL = Physics2D.OverlapCircle(wallNearR.position, wallRadius, whatIsGuardWall);
        wallCheckR = Physics2D.OverlapCircle(wallNearL.position, wallRadius, whatIsGuardWall);

        switch (movingRight)
        {
            case true:
                moveRight();
                if (wallCheckR)
                {
                    Flip();
                    movingRight = false;
                    faceRight = false;
                }
                break;

            case false:
                moveLeft();
                if (wallCheckL)
                {
                    Flip();
                    movingRight = true;
                    faceRight = true;
                }
                break;
        }
    }

    private void Update()
    {

        

    }

    public void moveLeft()
    {
        transform.position += transform.right * walkSpeed * Time.deltaTime;
        Patrolling = true;
    }
    public void moveRight()
    {
        transform.position += -transform.right * walkSpeed * Time.deltaTime;
        Patrolling = true;
    }

    //flips the direction of the sprite depending on which way the player is facing/moving
    void Flip()
    {
        Vector3 theScale = transform.localScale;

        theScale.x = -theScale.x;

        transform.localScale = theScale;


        /*/face the opposite direction
        faceRight = !faceRight;
        //get local scale
        Vector3 theScale = transform.localScale;
        //flip the sprite on the x axis
        theScale.x *= -1;
        //apply the flip to the local scale of the player
        transform.localScale = theScale;
        //*/
    }
}
