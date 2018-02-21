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
    float wallRadius = 0.2f;
    public Transform wallNearL;
    public Transform wallNearR;
    bool movingLeft = true;


    //guard move speed
    public float walkSpeed = 3f;

    private void FixedUpdate()
    {
        wallCheckL = Physics2D.OverlapCircle(wallNearR.position, wallRadius, whatIsGuardWall);
        wallCheckR = Physics2D.OverlapCircle(wallNearL.position, wallRadius, whatIsGuardWall);

        switch (movingLeft)
        {
            case true:
                moveLeft();
                if (wallCheckL)
                {
                    movingLeft = false;
                    Debug.Log("Left Wall Check");
                }
                break;

            case false:
                moveRight();
                if (wallCheckR)
                {
                    movingLeft = true;
                    Debug.Log("Right Wall Check");
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
    }
    public void moveRight()
    {
        transform.position += -transform.right * walkSpeed * Time.deltaTime;
    }
}
