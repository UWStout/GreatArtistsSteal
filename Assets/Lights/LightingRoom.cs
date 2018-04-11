using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRoom : MonoBehaviour {

    GameObject guard;
    private bool guardInRoom = false;
    private bool playerInRoom = false;
    private bool guardIsChasing = false;

    private void Start()
    {
        guard = GameObject.FindGameObjectWithTag("Guard");
    }

    // Update is called once per frame
    void Update () {
        // Debug.Log("Guard is chasing: "+guardIsChasing);
        // Debug.Log("Guard is in room: "+guardInRoom);
        // Debug.Log("Player is in room: "+playerInRoom);

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
