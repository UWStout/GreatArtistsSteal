using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRoom : MonoBehaviour {

    GameObject guard;//set to an array of gameobjects of guards
    GameObject player;

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
//                FindObjectOfType<AudioManager>().Play("LightOn");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter: " + collision.gameObject.tag);

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
}
