using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRoom : MonoBehaviour {

    GameObject guard;//set to an array of gameobjects of guards
    GameObject player;
    //GameObject GUI;

    void Start() {
        guard = null;
        player = null;
        
    }
	
	// Update is called once per frame
	void Update () {
        // Update guard state
        if (guard != null && player != null)
        {
            Debug.Log("Both in same room.");
            GuardMovement chasingScript = guard.GetComponent<GuardMovement>();
            if ((chasingScript != null) && chasingScript.chasing)
            {
                Debug.Log("GOTCHA!");
                FindObjectOfType<AudioManager>().Play("LightOn");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerGUI = GameObject.FindGameObjectWithTag("GUI");
        //Debug.Log("Enter: " + collision.gameObject.tag);

        if (collision.transform.tag == ("Player"))
        {
            player = collision.gameObject;
            
        }

        if (collision.transform.tag == ("Guard"))
        {
            guard = collision.gameObject;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject playerGUI = GameObject.FindGameObjectWithTag("GUI");
        Debug.Log("Exit: " + collision.gameObject.tag);

        if (collision.transform.tag == ("Player"))
        {
            player = null;
            
        }

        if (collision.transform.tag == ("Guard"))
        {
            guard = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "SecCamera")
        {
          //This was being called over 10,000 times -_-  //Debug.Log("security camera in room");
            if (CameraAnimation.playerSpotted == true)
            {
                Debug.Log("security camera in room spotted player");
                Destroy(gameObject);
            }
        }
    }
}
