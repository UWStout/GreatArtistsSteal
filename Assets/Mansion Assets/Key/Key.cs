using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	private bool canGrab=false;
	public static bool hasKey = false;

	public GameObject key;
	public GameObject Chest;

	// Use this for initialization
	void Start () {
		key = GameObject.Find("Key_Color");
		Chest = GameObject.Find("Chest_Color");
		key.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K)&&Input.GetKeyDown(KeyCode.I)&&Input.GetKeyDown(KeyCode.J)){
           
            hasKey = true;
			//Debug.Log("Key Collected... for testing");
		}
		if(canGrab == true && Chest.activeSelf == false){
			if(Input.GetKeyDown(KeyCode.E)){
				key.SetActive(false);
				hasKey = true;
				if(hasKey == true){
                    FindObjectOfType<AudioManager>().Play("KeyPickup");
                    //Debug.Log("Collected Key");}
                }
			}
		}
		if(canGrab == true && Chest.activeSelf == true){
			if (Input.GetKeyDown(KeyCode.E))
            	{
                FindObjectOfType<AudioManager>().Play("ChestOpening");
                //Debug.Log("Opened Chest");
                Chest.SetActive(false);
					key.SetActive(true);
				}
		}
	}
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {

            canGrab = true;
        }
    }
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {

            canGrab = false;
        }
    }
}
