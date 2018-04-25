using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardBGone : MonoBehaviour {
	public GameObject Guard;

	// Use this for initialization
	void Start () {
		Guard = GameObject.FindGameObjectWithTag("Guard");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Guard"))
        {
			//Guard.GetComponent<SpriteRenderer>().enabled = false;
			//Guard.SetActive(false);
			//Destroy(Guard);
            Debug.Log("Guard Deleted"); 
        } 
    }
}
