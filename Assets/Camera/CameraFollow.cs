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

    public float smoothSpeed = 10f;
    //public Vector3 offset;

    public Transform camera;
    //private bool pull = false;

    private bool lerpUp = false;
    private bool lerpDown = false;
    private float counter = 0f;


    private void Start()
    {
        guard = GameObject.FindGameObjectsWithTag("Guard");
        transform.position = new Vector3(player.position.x, cameraHeight, -13);
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


        if ((player.position.x <= 3))
        {
            position.x = 3;
            position.y = cameraHeight;
        }
        else if ((player.position.x >= 221))
        {
            position.x = 221;
            position.y = cameraHeight;
        }
        else if (((player.position.x > 3) || (player.position.x < 220)))
        {
            /*position.x = player.transform.position.x;
            position.y = cameraHeight;
            transform.position = position;*/
            transform.position = new Vector3(xPos, cameraHeight, -13);
        }

        
        /*if (lerpUp == true)
        {
            counter += Time.deltaTime * .5f;

            while (counter <= 5)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y + 9, Time.deltaTime * 2f), transform.localPosition.z);
            }
            
        }

        if (lerpDown == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, transform.localPosition.y - 9, Time.deltaTime * 2f), transform.localPosition.z);
        }*/

    }

    /*public void LerpUp()
    {
        lerpUp = true;
    }

    public void LerpDown()
    {
        lerpDown = true;
    }*/
}
