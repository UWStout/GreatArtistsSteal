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
		//Debug.Log (PlayerPrefs.GetString("name") + " right here");
	}
	
	public void EnterName(){
		if (enterName.text != string.Empty) {
			PlayerPrefs.SetString("name", enterName.text);
			string nom = enterName.text;
			Debug.Log (nom);
			ScoreManager.setScore (nom, "Time", 0);
			ScoreManager.setScore (nom, "Money", 0);
			ScoreManager.setScore (nom, "Level", 0);

			//Debug.Log ("yeah idk");
			//Debug.Log (enterName.ToString());

			MainMenu.loadMan1 ();
			return;

			//nameDialog.SetActive (!nameDialog.activeSelf);
		} 

		//Debug.Log ("DIDNT WORK NOAH ______________________");
	}


}
