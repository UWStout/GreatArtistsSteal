using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

	
	void OnCollisionEnter2D(Collision2D coll)
	{
    	if (coll.gameObject.name == "Player")
    	{
            FindObjectOfType<AudioManager>().Play("PianoHit");
        }
	}

}
