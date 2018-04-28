using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;

	public static float globalTime;

	// Use this for initialization
	void Start () {
        timerText = gameObject.GetComponent<Text>();
        startTime = Time.time;
    }

    private void Update()
    {
        float t = Time.time - startTime;
		globalTime = t;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        if (seconds.Length < 5)
        {
            if (minutes.Length < 2)
            {
                timerText.text = "0" + minutes + ":0" + seconds;
            }
            else
            {
                timerText.text = minutes + ":0" + seconds;
            }   
        }
        else
        {
            if (minutes.Length < 2)
            {
                timerText.text = "0" + minutes + ":" + seconds;
            }
            else
            {
                timerText.text = minutes + ":" + seconds;
            }
        }
        
    }

}
