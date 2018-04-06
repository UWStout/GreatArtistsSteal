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

    private GameObject[] guard;
    private float distanceToGuard = 22f;

    public float smoothSpeed = 80f;
    //public Vector3 offset;

    public Transform camera;
    private bool pull = false;


    private void Start()
    {
        guard = GameObject.FindGameObjectsWithTag("Guard");
        transform.position = new Vector3(player.position.x, cameraHeight, -13);
    }

    private void FixedUpdate()
    {
        if (distance < distanceToGuard)
        {
            pull = true;
        }
        else if (distance > distanceToGuard)
        {
            pull = false;
        }
    }

    // Update is called once per frame
    void Update () {

        distance = Vector3.Distance(player.transform.position, guardObject.transform.position);

        Vector3 position = transform.position;

        //currently unused_______________________________________________________
        //Vector3 smoothedPosition = Vector3.Lerp(position, position, smoothSpeed);
        //_______________________________________________________________________

        float xPos = Mathf.Lerp(transform.position.x, player.transform.position.x, 50 * smoothSpeed * Time.deltaTime);
        float xPos2 = Mathf.Lerp(transform.position.x, player.transform.position.x + 1.5f, 50 * smoothSpeed * Time.deltaTime);
        float xPos3 = Mathf.Lerp(transform.position.x, player.transform.position.x - 1.5f, 50 * smoothSpeed * Time.deltaTime);


        if ((player.position.x <= 3) && (pull == false))
        {
            position.x = 4;
            position.y = cameraHeight;
        }
        else if ((player.position.x <= 3) && (pull == true))
        {
            position.x = 4;
            position.y = cameraHeight;
        }
        else if ((player.position.x >= 220) && (pull = false))
        {
            position.x = 220;
            position.y = cameraHeight;
        }
        else if ((player.position.x >= 220) && (pull == true))
        {
            position.x = 4;
            position.y = cameraHeight;
        }
        else if (((player.position.x > 3) || (player.position.x < 220)) && (pull == false))
        {
            /*position.x = player.transform.position.x;
            position.y = cameraHeight;
            transform.position = position;*/
            transform.position = new Vector3(xPos, cameraHeight, -13);
        }
        else if (((player.position.x > 3) || (player.position.x < 220)) && (pull == true))
        {
            if (player.position.x < guardObject.position.x)
            {
                transform.position = new Vector3(xPos2, cameraHeight, -13);
            }
            else if (player.position.x > guardObject.position.x)
            {
                transform.position = new Vector3(xPos3, cameraHeight, -13);
            }
        }
            
        /*if (player.position.x - guardObject.position.x < distanceToGuard)
        {
            if (player.position.x < guardObject.position.x)
            {
                transform.position = new Vector3(xPos2, cameraHeight, -13);
                pull = true;
            }
            else if (player.position.x > guardObject.position.x)
            {
                transform.position = new Vector3(xPos3, cameraHeight, -13);
                pull = true;
            }
        }
        else
        {
            pull = false;
        }*/

    }
}
