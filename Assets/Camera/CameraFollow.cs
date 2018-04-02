using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public static float cameraHeight = -5f;

    public GameObject playerPosition;
    public GameObject guardPosition;
    public float distance;
    public Transform playerObject;
    public Transform guardObject;

    public float smoothSpeed = 80f;
    //public Vector3 offset;

    public Transform camera;

    private void Start()
    {
        transform.position = new Vector3(player.position.x, cameraHeight, -13);
    }

    // Update is called once per frame
    void Update () {

        Vector3 position = transform.position;

        //currently unused_______________________________________________________
        //Vector3 smoothedPosition = Vector3.Lerp(position, position, smoothSpeed);
        //_______________________________________________________________________

        float xPos = Mathf.Lerp(transform.position.x, player.transform.position.x, 50 * smoothSpeed * Time.deltaTime);

        if (player.position.x <= 4)
        {
            position.x = 4;
            position.y = cameraHeight;
        }
        else if (player.position.x >= 220)
        {
            position.x = 220;
            position.y = cameraHeight;
        }
        else
        {
            /*position.x = player.transform.position.x;
            position.y = cameraHeight;
            transform.position = position;*/
            transform.position = new Vector3(xPos, cameraHeight, -13);
        }

        /*position.x = player.transform.position.x;
        position.y = cameraHeight;
        transform.position = position;  */

        //distance = Vector3.Distance(playerPosition.transform.position.x, guardPosition.transform.position.x);

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
