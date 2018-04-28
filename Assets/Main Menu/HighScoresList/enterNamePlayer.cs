using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enterNamePlayer : MonoBehaviour {

	public Text enterName;
	//ScoreManager scoreManger;

	// Use this for initialization
	void Start () {
		
	}
	
	public void EnterName(){
		if (enterName.text != string.Empty) {
		//	PlayerPrefs.SetString("name") = enterName;
//			ScoreManager.setScore (name, "Time", 0);
//			ScoreManager.setScore (name, "Money", 0);
//			ScoreManager.setScore (name, "Level", 0);
		} else {
		
		}
	}
}
