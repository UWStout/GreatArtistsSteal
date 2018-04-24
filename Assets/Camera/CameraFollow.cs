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
	private float movementTime = .45f;
	float lerpValue = 0f;



    private void Start()
    {
        guard = GameObject.FindGameObjectsWithTag("Guard");
        transform.position = new Vector3(player.position.x, cameraHeight, -13);
    }

    // Update is called once per frame
    void Update () {

		distance = Vector3.Distance (player.transform.position, guardObject.transform.position);

		Vector3 position = transform.position;

		//currently unused_______________________________________________________
		//Vector3 smoothedPosition = Vector3.Lerp(position, position, smoothSpeed);
		//_______________________________________________________________________

		float xPos = Mathf.Lerp (transform.position.x, player.transform.position.x, 50 * smoothSpeed * Time.deltaTime);
		float xPos2 = Mathf.Lerp (transform.position.x, player.transform.position.x + 1.5f, 50 * smoothSpeed * Time.deltaTime);
		float xPos3 = Mathf.Lerp (transform.position.x, player.transform.position.x - 1.5f, 50 * smoothSpeed * Time.deltaTime);


		if ((player.position.x <= 3)) {
			position.x = 3;
			position.y = cameraHeight;
		} else if ((player.position.x >= 221)) {
			position.x = 221;
			position.y = cameraHeight;
		} else if (((player.position.x > 3) || (player.position.x < 220))) {
			/*position.x = player.transform.position.x;
            position.y = cameraHeight;
            transform.position = position;*/
			transform.position = new Vector3 (xPos, cameraHeight, -13);
		}
        
		Vector3 posUpEnd = new Vector3 (transform.position.x, transform.position.y + 9, transform.position.z);
		if (lerpUp == true) {
			if (lerpValue < 1) {
				lerpValue += Time.deltaTime * movementTime;
				transform.position = Vector3.Lerp (transform.localPosition, posUpEnd, lerpValue);
			} else {
				lerpValue = 0;
				//transform.position = new Vector3(xPos, cameraHeight, -13);

				cameraHeight = cameraHeight + 9f;
				lerpUp = false;
				Debug.Log("Stop lerp up");
			}

		}

		Vector3 posDownEnd = new Vector3 (transform.position.x, transform.position.y - 9, transform.position.z);
		if (lerpDown == true)
        {
			if (lerpValue < 1) {
				lerpValue += Time.deltaTime * movementTime;
				transform.position = Vector3.Lerp (transform.localPosition, posDownEnd, lerpValue);
			} else {
				lerpValue = 0;
				//transform.position = new Vector3(xPos, cameraHeight, -13);

				cameraHeight = cameraHeight - 9f;
				lerpDown = false;
				Debug.Log("Stop Lerp down");
			}
        }

	}

    public void LerpUp()
    {
        lerpUp = true;
    }

    public void LerpDown()
    {
        lerpDown = true;
    }
}
