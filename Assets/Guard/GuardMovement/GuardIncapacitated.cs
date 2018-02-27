using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIncapacitated : MonoBehaviour {

    bool guardIncapacitated = false;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //GuardMovement incapacitated = gameObject.GetComponent<GuardMovement>();
        GuardMovement incapacitated = gameObject.GetComponentInParent<GuardMovement>();

        if (collision.gameObject.tag == ("Player"))
        {
            incapacitated.GuardIncapacitated();
        }
    }
}
