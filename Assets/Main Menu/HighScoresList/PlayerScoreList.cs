using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;
	ScoreManager scoreManager;

	// Use this for initialization

	void Start(){
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}

	//this will become a single call (tut is for multiplayer)
	void Update () {
		if (scoreManager == null) {
			Debug.LogError ("you for got to add the score board component");
			return;
		}
		while (this.transform.childCount > 0) {
			Transform c = this.transform.GetChild (0);
			c.SetParent (null);
			Destroy (c.gameObject);
		}

		string[] names = scoreManager.getPlayerNames("Money");
		foreach (string name in names){
			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("PlayerName").GetComponent<Text>().text = name;
			//go.transform.Find ("PlayerTime").GetComponent<Text> ().text = scoreManager.getScore (name, "Time").ToString();
			go.transform.Find ("PlayerLevel").GetComponent<Text> ().text = scoreManager.getScore (name, "Level").ToString();
			go.transform.Find ("PlayerMoney").GetComponent<Text> ().text = scoreManager.getScore (name, "Money").ToString();

		}
	}

}
