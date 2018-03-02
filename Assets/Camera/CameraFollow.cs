using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    float cameraHeight = 4.5f;
	
	// Update is called once per frame
	void Update () {

        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = cameraHeight;
        transform.position = position;
	}
}
