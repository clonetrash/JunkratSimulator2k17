using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeTextDisplay : MonoBehaviour {

	public CountdownProperty countdownTime;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		text.text = countdownTime.value > 0 ? FormatTime(countdownTime.value) : "";
	}

	void OnBecameVisible() {
        enabled = true;
    }

	void OnBecameInvisible() {
        enabled = false;
    }
	
	string FormatTime (float time)
	{
		int minutes = (int) time/60;

		int seconds = (int) time%60;

		int centiseconds = (int) ((time%1)*100);

		return String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds); // :00 beduetet at timmer zwei zeichen
	}
}
