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
		scoreBoard ();
	}

	//this will become a single call (tut is for multiplayer)
	void scoreBoard () {
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
            float temp = scoreManager.getScore(name, "Time");

            string minutes = ((int)temp / 60).ToString();
            string seconds = (temp % 60).ToString("f2");

            string readout;

            if (seconds.Length < 5)
            {
                if (minutes.Length < 2)
                {
                    readout = "0" + minutes + ":0" + seconds;
                }
                else
                {
                    readout = minutes + ":0" + seconds;
                }
            }
            else
            {
                if (minutes.Length < 2)
                {
                    readout = "0" + minutes + ":" + seconds;
                }
                else
                {
                    readout = minutes + ":" + seconds;
                }
            }

            go.transform.Find("PlayerTime").GetComponent<Text>().text = readout;
			go.transform.Find ("PlayerLevel").GetComponent<Text> ().text = scoreManager.getScore (name, "Level").ToString();
			go.transform.Find ("PlayerMoney").GetComponent<Text> ().text = scoreManager.getScore (name, "Money").ToString();

		}
	}

}
