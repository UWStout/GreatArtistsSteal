using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSpawn : MonoBehaviour {
	public GameObject cloud1;
	public GameObject cloud2;
	public GameObject cloud3;
	public GameObject cloud4;
	public GameObject cloud5;

	// Use this for initialization
	void Start () {
		int temp = 0;
		int low = 1;
		int high = 8;
		temp = Random.Range (low, high);
		for(int i=0; i<temp; i++){
			Instantiate(cloud1, transform.position, transform.rotation);
		}
		temp = Random.Range (low, high);
		for(int i=0; i<temp; i++){
			Instantiate(cloud2, transform.position, transform.rotation);
		}
		temp = Random.Range (low, high);
		for(int i=0; i<temp; i++){
			Instantiate(cloud3, transform.position, transform.rotation);
		}
		temp = Random.Range (low, high);
		for(int i=0; i<temp; i++){
			Instantiate(cloud4, transform.position, transform.rotation);
		}
		temp = Random.Range (low, high);
		for(int i=0; i<temp; i++){
			Instantiate(cloud5, transform.position, transform.rotation);
		}



	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
