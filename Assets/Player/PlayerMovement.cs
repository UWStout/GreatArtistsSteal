using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Movement

    public float speed;
    public float jump;
    float moveVelocity;

    //grounded variable (Checks if the player is on the groud for jumping)
    bool grounded = true;
	
	// Update is called once per frame
	void Update () {
		//Player Jump (space to jump)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        //reset move speed to 0
        moveVelocity = 0;

        //left and right player movement
        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
	}

    //check if player is grounded (can jump)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
