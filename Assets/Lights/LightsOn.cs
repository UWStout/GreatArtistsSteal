﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightsOn : MonoBehaviour {
	private GameObject LightSwitch;
	public float interval = 20f;
	public float startTime = 10f;

	public static bool litTime;

	// Use this for initialization
	void Start () {
		LightSwitch = GameObject.FindGameObjectWithTag("LightSwitch");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > startTime){
            startTime = Time.time + interval;
            //Debug.Log("Lights moved");
			LightSwitch.transform.position =  new Vector3(3.66f+Random.Range(0, 20)*24, -4.94f +Random.Range(0,20)*9, 0);
			//Debug.Log("LitTime at:" + transform.position);
			litTime = true;
		}
	}

	
}
