using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	//List of "Users"
	static Dictionary<string, Dictionary<string, int>> playerScores;

	void Start(){
		/*/testing
		setScore ("Noah", "Time", 1);
		setScore ("Noah", "Money", 3);

		setScore ("penis", "Time", 22);
		setScore ("penis", "Money", 9);

		setScore ("assHAT", "Time", 99);
		setScore ("assHAT", "Money", 99);

		setScore ("DickHAT", "Time", 31);
		setScore ("DickHAT", "Money", 644);

		setScore ("ShitHAT", "Time", 43);
		setScore ("ShitHAT", "Money", 100);

		setScore ("A", "Time", 443);
		setScore ("A", "Money", 1400);

		setScore ("B", "Time", 443);
		setScore ("B", "Money", 1400);

		setScore ("d", "Time", 443);
		setScore ("d", "Money", 1400);

		setScore ("c", "Time", 443);
		setScore ("c", "Money", 1400);

		//Debug.Log( getScore("quill18", "Money") );*/
	}

	static void Init(){
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
		return playerScores [username][scoreType];
	}

	public static int getScoreS(string username, string scoreType){
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			return 0;
		}
		if (playerScores [username].ContainsKey (scoreType) == false) {
			return 0;
		}
		return playerScores [username][scoreType];
	}


	public static void setScore(string username, string scoreType, int value){
		Init ();
		if (playerScores.ContainsKey (username) == false) {
			playerScores[username] = new Dictionary<string, int>();
		}
		playerScores [username] [scoreType] = value;
	}


	public static void changeScore(string username, string scoreType, int amount){
		Init ();
		int curScore = getScoreS(username, scoreType);
		setScore (username, scoreType, curScore + amount);
	}





	public string[] getPlayerNames(string sortingScoreType){
		Init ();
		return playerScores.Keys.OrderByDescending( n => getScore(n, sortingScoreType)).ToArray();
	}



}
