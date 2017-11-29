using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class CountdownProperty : ScriptableObject {

	private bool countdownStarted = false;

	public float value {
		get{return countdownStarted ? TimePoint-Time.time : 0; } 
		
	}

	public void Stop(){
		countdownStarted = false;
	}

	public float TimePoint = 0f ;

	public void CountTime(float duration) 
	{
		if (!countdownStarted){
		 countdownStarted = true; 
		 TimePoint = Time.time + duration;
		}
	}
}
