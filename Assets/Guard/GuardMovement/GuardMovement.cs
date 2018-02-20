using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour {

    //determine sprite direction
    bool faceRight = true;

    //left and right wall check
    bool wallCheck = false;
    public LayerMask whatIsGuardWall;//determines what is considered a wall for the guard
    float wallRadius = 1.6f;
    public Transform wallNear;

    //guard move speed
    public float walkSpeed = 2f;

    public void Start()
    {
        
    }

    private void FixedUpdate()
    {
        wallCheck = Physics2D.OverlapCircle(wallNear.position, wallRadius, whatIsGuardWall);
    }

    private void Update()
    {
        if (wallCheck)
        {
            transform.position += transform.right * walkSpeed * Time.deltaTime;
        } else if (!wallCheck)
        {
            transform.position += -transform.right * walkSpeed * Time.deltaTime;
        }
        
    }

    void Flip()//flips sprite depending on movement
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
