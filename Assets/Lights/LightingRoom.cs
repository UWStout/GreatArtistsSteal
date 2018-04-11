using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRoom : MonoBehaviour {

    GameObject guard;
    private bool guardInRoom = false;
    private bool playerInRoom = false;
    private bool guardIsChasing = false;
    private int lastLog = (int)Math.Floor(Time.time);
	
	// Update is called once per frame
	void Update () {
        // Log info every second
        int curTimeSecs = (int)Math.Floor(Time.time);
        if (curTimeSecs > lastLog) {
            Debug.Log("Chasing: " + guardIsChasing +
                      ", GuardRoom: " + guardInRoom +
                      ", PlayerRoom: " + playerInRoom);
            lastLog = curTimeSecs;
        }

        // Update guard state
        if(guard != null) {        
            GuardMovement chasingScript = guard.GetComponent<GuardMovement>();
            guardIsChasing = (chasingScript != null) && chasingScript.chasing;
        }

        // Turn on the lights
        if (guardInRoom && playerInRoom && guardIsChasing)
        {
            FindObjectOfType<AudioManager>().Play("LightOn");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == ("Player"))
        {
            playerInRoom = true;
        }

        if (collision.transform.tag == ("Guard"))
        {
            Debug.Log("Guard has entered the room");
            guardInRoom = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.transform.tag == ("Player"))
        {
            playerInRoom = false;
        }

        if (collision.transform.tag == ("Guard"))
        {
            Debug.Log("Guard has entered the room");
            guardInRoom = false;
        }
    }
}
