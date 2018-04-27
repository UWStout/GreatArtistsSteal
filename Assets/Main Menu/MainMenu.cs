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

	public void debreifingLoad(int time, int money, int level){

	}

	public void debreifingContinue(int time, int money, int level){

	}


	public void loadMan1(){
		SceneManager.LoadScene("Level One");
	}

	public void loadMan2(){
		SceneManager.LoadScene("Level Two");
	}

	public void loadMan3(){
		SceneManager.LoadScene("Level Three");
	}

	public void loadMan4(){
		SceneManager.LoadScene("Level Four");
	}

	public void loadMan5(){
		SceneManager.LoadScene("Level Five");
	}


	public void MenuQuit(){
		Application.Quit();
	}
}
