using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {

	private static bool hasKey;
	private bool canInteract;
	//public Scene Menu;
	// Use this for initialization
	void Start () {
		hasKey = Key.hasKey;
		//Scene Menu = SceneManager.GetSceneByName("mainMenu");
		//Debug.Log("Script is Running");
	}
	
	// Update is called once per frame
	void Update () {
		hasKey = Key.hasKey;
		if(canInteract == true && hasKey == true){
			//Debug.Log("CanUnlock");
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log("YAY");
                SceneManager.LoadScene("mainMenu");
				}
			}
		}
		
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {
            canInteract = true;
        }
    }
}
