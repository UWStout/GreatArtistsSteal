﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MainMenu : MonoBehaviour {

	public GameObject nameDialog;

	public void Play(){
        
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene("levelBriefing");
	}

	public void Credits(){
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene("main Credits");
	}

	public void ControlsMenu(){
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene ("main Controls");
	}

	public void Highscore(){
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene ("highscores");
	}

	public void mainReturn(){
        FindObjectOfType<AudioManager>().Play("MenuClick");
        SceneManager.LoadScene ("mainMenu");
		PlayerPrefs.SetString ("name", null);
	}

	public void debreifingLoad(float time, int money, int level){

	}

	public void debreifingContinue(int time, int money, int level){

	}


	public static void loadMan1(){
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
        FindObjectOfType<AudioManager>().Play("MenuClick");
        Application.Quit();
	}


	public void enterName(){
		//this.GetComponent<Button> ().interactable = false;
		nameDialog.SetActive (!nameDialog.activeSelf);
	}

    public AudioMixer audioMixer;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
