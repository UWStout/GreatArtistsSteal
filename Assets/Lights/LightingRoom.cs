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
//                FindObjectOfType<AudioManager>().Play("LightOn");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject playerGUI = GameObject.FindGameObjectWithTag("GUI");
        Debug.Log("Enter: " + collision.gameObject.tag);

        if (collision.transform.tag == ("Player"))
        {
            player = collision.gameObject;
            if (Key.hasKey == true)
            {
                playerGUI.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            }
            else if (Key.hasKey == false)
            {
                playerGUI.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                playerGUI.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            }
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
            if (Key.hasKey == true)
            {
                playerGUI.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(3).gameObject.SetActive(true);
            }
            else if (Key.hasKey == false)
            {
                playerGUI.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                playerGUI.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            }
        }

        if (collision.transform.tag == ("Guard"))
        {
            guard = null;
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject playerGUI = GameObject.FindGameObjectWithTag("GUI");

        if (collision.transform.tag == ("Player") && Key.hasKey == true)
        {
            playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (collision.transform.tag == ("Player") && Key.hasKey == false)
        {
            playerGUI.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }*/
}
