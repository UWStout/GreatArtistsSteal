﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    float cameraHeight = -5f;

    public GameObject playerPosition;
    public GameObject guardPosition;
    public float distance;

    public Transform camera;

	// Update is called once per frame
	void Update () {

        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = cameraHeight;
        transform.position = position;   

        //distance = Vector3.Distance(playerPosition.transform.position.x, guardPosition.transform.position.x);

        /*if (playerPosition.transform.position.x < guardPosition.transform.position.x + 20)
        {
            position.x = player.transform.position.x + 5;
        }
        else if (playerPosition.transform.position.x > guardPosition.transform.position.x - 20)
        {
            position.x = player.transform.position.x - 5;
        }*/
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("leftWall"))
        {
            Debug.Log("left wall hit");
            /*Vector3 position2 = transform.position;
            position2.x = player.transform.position.x - 100;
            position2.y = cameraHeight;
            transform.position = position2;*/
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("leftWall"))
        {
            Debug.Log("WallHit");
        }
        
    }*/
}
