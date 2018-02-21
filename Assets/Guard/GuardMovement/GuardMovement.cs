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
    bool wallNum = false;

    //guard move speed
    public float walkSpeed = 3f;

    private void FixedUpdate()
    {
        wallCheck = Physics2D.OverlapCircle(wallNear.position, wallRadius, whatIsGuardWall);
    }

    private void Update()
    {
        if (wallCheck == false && wallNum == false)
        {
            moveLeft();
        }
        else if ((wallCheck == true))
        {
            moveRight();
            wallNum = true;
        }
        
    }

    public void moveLeft()
    {
        transform.position += transform.right * walkSpeed * Time.deltaTime;
    }
    public void moveRight()
    {
        transform.position += -transform.right * walkSpeed * Time.deltaTime;
    }
}
