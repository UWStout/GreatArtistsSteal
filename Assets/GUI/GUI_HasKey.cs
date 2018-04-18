using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_HasKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Key.hasKey == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
            //gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
	}
}
