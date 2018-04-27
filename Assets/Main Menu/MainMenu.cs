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

	public void ControlsMenu(){
		SceneManager.LoadScene ("main Controls");
	}

	public void Highscore(){
		SceneManager.LoadScene ("highscores");
	}

	public void mainReturn(){
		SceneManager.LoadScene ("mainMenu");
	}

	public void MenuQuit(){
		Application.Quit();
	}
}
