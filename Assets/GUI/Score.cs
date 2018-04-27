using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text scoreText;
    private static int score = 0;

    private void Start()
    {
        scoreText = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
    }

	public void AddScore(int multiplier)
    {
		score = score + 10*multiplier;

		//Add to Money score for highscore Dictionary

    }
}
