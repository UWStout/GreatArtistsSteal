using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void Play(){
		SceneManager.LoadScene("levelBriefing");
	}

	public void Credits(){
		SceneManager.LoadScene("main Credits");
	}

	public void Highscore(){

	}

	public void Quit(){
		Application.Quit ();
	}
}
