using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void Play(){

		SceneManager.LoadScene("Level One");

	}

	public void Credits(){
		SceneManager.LoadScene("main Credits");
		Debug.Log ("Worked");
	}

	public void Highscore(){

	}

	public void Quit(){
		Application.Quit ();
	}
}
