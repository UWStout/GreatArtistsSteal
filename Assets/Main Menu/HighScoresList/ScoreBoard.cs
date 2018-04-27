using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreBoard : MonoBehaviour {

	//List of "Users"
	Dictionary<string, Dictionary<string, int>> playerScores;

	void Start(){
		setScore ("quill18", "Time / Level", 9001);
		setScore ("quill18", "Money", 9001);

		setScore ("penis ", "Time / Level", 2201);
		setScore ("penis", "Money", 901);

		setScore ("assHAT", "Time / Level", 3001);
		setScore ("assHAT", "Money", 69);




		Debug.Log( getScore("quill18", "kills") );
	}

	void Init(){
		if (playerScores != null) {
			return;
		}

		playerScores = new Dictionary<string, Dictionary<string, int>>();

	}

	public int getScore(string username, string scoreType){
		Init ();

		if (playerScores.ContainsKey (username) == false) {
			return 0;
		}

		if (playerScores [username].ContainsKey (scoreType) == false) {
			return 0;
		}

		return playerScores [username] [scoreType];
	}

	public void setScore(string username, string scoreType, int value){
		Init ();

		if (playerScores.ContainsKey (username) == false) {
			
			playerScores[username] = new Dictionary<string, int>();
		}

		if (playerScores [username].ContainsKey (scoreType) == false) {
			//return 0;
		}

		//return playerScores [username] [scoreType];

	}

	public void changeScore(string username, string scoreType, int amount){
		Init ();
		int curScore = getScore (username, scoreType);
		setScore (username, scoreType, curScore + amount);
	}

	public string[] getPlayerNames(){
		Init ();
		return playerScores.Keys.ToArray();
	}

}
