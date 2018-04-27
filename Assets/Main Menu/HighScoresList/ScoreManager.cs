using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	//List of "Users"
	Dictionary<string, Dictionary<string, int>> playerScores;

	void Start(){

		//testing
		setScore ("quill18", "Time", 1);
		setScore ("quill18", "Money", 3);

		setScore ("penis", "Time", 22);
		setScore ("penis", "Money", 9);

		setScore ("assHAT", "Time", 3);
		setScore ("assHAT", "Money", 6);




		Debug.Log( getScore("quill18", "Money") );
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

		playerScores [username] [scoreType] = value;
			
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

	public string[] getPlayerNames(string sortingScoreType){
		Init ();
		return playerScores.Keys.OrderByDescending( n => getScore(n, sortingScoreType)).ToArray();
	}



}
