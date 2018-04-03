using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingRoom : MonoBehaviour {

    public GameObject guard;
    private bool guardInRoom = false;
    private bool playerInRoom = false;
    private bool guardIsChasing = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Guard is chasing: "+guardIsChasing);
        Debug.Log("Guard is in room: "+guardInRoom);
        Debug.Log("Player is in room: "+playerInRoom);

        GuardMovement chasingScript = guard.GetComponent<GuardMovement>();
        if (chasingScript.chasing == true)
        {
            guardIsChasing = true;
        }else if (chasingScript.chasing == false)
        {
            guardIsChasing = false;
        }

        if ((guardInRoom == true) && (playerInRoom == true) && (guardIsChasing == true))
        {
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
