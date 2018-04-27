using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreBoard scoreBoard;

	// Use this for initialization
	void Start () {
		scoreBoard = GameObject.FindObjectOfType<ScoreBoard> ();

		if (scoreBoard == null) {
			Debug.LogError ("you for got to add the score board component");
			return;
		}

	//	string[] names = ScoreBoard.getPlayerNames();

		for (int i = 0; i < 5; i++) {
			GameObject go = (GameObject)Instantiate (playerScoreEntryPrefab);
			go.transform.SetParent (this.transform);
			go.transform.Find ("PlayerName").GetComponent<Text>().text = name;
		}
	}

}
