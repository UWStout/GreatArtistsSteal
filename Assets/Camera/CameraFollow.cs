using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    float cameraHeight = -3f;

    public GameObject playerPosition;
    public GameObject guardPosition;

	
	// Update is called once per frame
	void Update () {

        Vector3 position = transform.position;
        position.x = player.transform.position.x;
        position.y = cameraHeight;
        transform.position = position;

        /*if (playerPosition.transform.position.x < guardPosition.transform.position.x + 20)
        {
            position.x = player.transform.position.x + 5;
        }
        else if (playerPosition.transform.position.x > guardPosition.transform.position.x - 20)
        {
            position.x = player.transform.position.x - 5;
        }*/
	}
}
