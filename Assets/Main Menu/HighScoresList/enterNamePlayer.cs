using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enterNamePlayer : MonoBehaviour {

	public Text enterName;
	ScoreManager scoreManger;
	public GameObject nameDialog;

	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetString("name") + " right here");
	}
	
	public void EnterName(){
		if (enterName.text != string.Empty) {
			PlayerPrefs.SetString("name", enterName.ToString());
			ScoreManager.setScore (enterName.ToString(), "Time", 0);
			ScoreManager.setScore (enterName.ToString(), "Money", 0);
			ScoreManager.setScore (enterName.ToString(), "Level", 0);

			//Debug.Log ("yeah idk");
			//Debug.Log (enterName.ToString());

			MainMenu.loadMan1 ();
			return;

			//nameDialog.SetActive (!nameDialog.activeSelf);
		} 

		//Debug.Log ("DIDNT WORK NOAH ______________________");
	}
}
