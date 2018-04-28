using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;


public class Exit : MonoBehaviour {

	private static bool hasKey;
	Scene currentScene;
	private bool canInteract;
	public string Name;

	void Start () {
		//hasKey = Key.hasKey;
		hasKey = false;

	}
	
	// Update is called once per frame
	void Update () {
		Name = PlayerPrefs.GetString("name");
		hasKey = Key.hasKey;
		//hasKey = true;
		Scene currentScene = SceneManager.GetActiveScene();
		if(canInteract == true && hasKey == true){
			if(Input.GetKeyDown(KeyCode.E)){
				Debug.Log("YAY");
				if(currentScene.name == "Level One"){
					Debug.Log("Beat Level Uno");
					hasKey = false;
					updateScore ();
					SceneManager.LoadScene("briefing two");
				}
				else if(currentScene.name == "Level Two"){
					Debug.Log("Beat Level Dos");
					hasKey = false;
					updateScore ();
					SceneManager.LoadScene("briefing three");
				}
				else if(currentScene.name == "Level Three"){
					Debug.Log("Beat Level Tres");
					hasKey = false;
					updateScore ();
					SceneManager.LoadScene("briefing four");
				}
				else if(currentScene.name == "Level Four"){
					Debug.Log("Beat Level Quattro");
					hasKey = false;
					updateScore ();
					SceneManager.LoadScene("briefing five");
				}
				else if(currentScene.name == "Level Five"){
					Debug.Log("Beat Level Five");
					hasKey = false;
					updateScore ();


					// Add name to highscore list
					SceneManager.LoadScene("mainMenu");
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

																		//Noah Added
	public void updateScore(){
		ScoreManager.changeScore (Name, "Level", 1); //Noah Added
		ScoreManager.changeScore (Name, "Time",  (int)Timer.globalTime);
		ScoreManager.changeScore (Name, "Money", Score.globalScore);

	}
}
