using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraFollow follow = gameObject.GetComponent<CameraFollow>();

        if(gameObject.transform.tag == ("Player"))
        {
            Debug.Log("StopCameraMovemnt.x");
            follow.StopFollow();
            
        }
    }
}
