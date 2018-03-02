using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
	
	// Update is called once per frame
	void Update () {

        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = 4;
        transform.position = position;
	}
}
