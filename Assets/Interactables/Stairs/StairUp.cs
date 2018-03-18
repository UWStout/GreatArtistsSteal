using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairUp : MonoBehaviour {

    public Transform player;
    //public GameObject player;
    private float locationUp = 5f;
    private bool triggerEntered = false;
    float changeHeight = 4.5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && triggerEntered == true)
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + locationUp);
            //player.transform.position = player.transform.position +9;
            Debug.Log("PlayerMoveUp");

            CameraFollow.cameraHeight = CameraFollow.cameraHeight + changeHeight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = true;
            Debug.Log("can interact");         
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            triggerEntered = false;
            Debug.Log("cant interact");
        }
    }
}
