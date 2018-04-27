﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {

	private static bool hasKey;
	Scene currentScene;
	Scene previousScene;
	private bool canInteract;
	void Start () {
		hasKey = Key.hasKey;
	}
	
	// Update is called once per frame
	void Update () {
		hasKey = Key.hasKey;
		Scene currentScene = SceneManager.GetActiveScene();
		if(canInteract == true && hasKey == true){
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log("YAY");
				if(currentScene.name == "Level One"){
					Debug.Log("Beat Level Uno");
					hasKey = false;
					//previousScene = "Level One";
					SceneManager.LoadScene("levelBriefing");
				}
				else if(currentScene.name == "Level Two"){
					Debug.Log("Beat Level Dos");
					hasKey = false;
					SceneManager.LoadScene("levelBriefing");
				}
				else if(currentScene.name == "Level Three"){
					Debug.Log("Beat Level Tres");
					hasKey = false;
					SceneManager.LoadScene("levelBriefing");
				}
				else if(currentScene.name == "Level Four"){
					Debug.Log("Beat Level Quattro");
					hasKey = false;
					SceneManager.LoadScene("levelBriefing");
				}
				else if(currentScene.name == "Level Five"){
					Debug.Log("Beat Level Five");
					hasKey = false;
					SceneManager.LoadScene("levelBriefing");
				}
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
