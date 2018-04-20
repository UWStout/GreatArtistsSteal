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
		if(canGrab == true && Chest.activeSelf == false){
			if(Input.GetKeyDown(KeyCode.E)){
            	Debug.Log("Collected Key");
				key.SetActive(false);
				hasKey = true;
			}
		}
		if(canGrab == true && Chest.activeSelf == true){
			if (Input.GetKeyDown(KeyCode.E))
            	{
					Debug.Log("Opened Chest");
					Chest.SetActive(false);
					key.SetActive(true);
				}
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Player"))
        {

            canGrab = true;
        }
    }
}
