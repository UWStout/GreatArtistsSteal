using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D collision){
		if(collision.transform.tag == ("LightSwitch")){
			if(LightsOn.litTime == true){
				Destroy(gameObject);
				LightsOn.litTime = false;
				Debug.Log("Lit No More");
			}
		}
	}

}

