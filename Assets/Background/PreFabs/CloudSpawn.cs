using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {
	public float dist = 0;
	// Use this for initialization
	void Start () {
		dist = Random.Range (8f, 15f);
		Vector3 position = new Vector3(Random.Range(40, 340.0f), Random.Range(0f, 61f), dist);
		transform.SetPositionAndRotation(position,transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate ((dist / 8) * Time.deltaTime, 0, 0);

		if (transform.position.x > 375) {
			dist = Random.Range (8f, 15f);
			Vector3 position = new Vector3(Random.Range(-40.0f, -10.0f), Random.Range(10f, 51f), dist);
			transform.SetPositionAndRotation(position,transform.rotation);
		}
	}
}
