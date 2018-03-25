using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour {

	public LayerMask playerLayer;
	public float shotdistance = 124f;

	// Use this for initialization
	void Start () {
		StartCoroutine (LaserRoutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private IEnumerator LaserRoutine () {
		while (true) {
		yield return new WaitForSeconds (3);  //yield return nur in coroutine möglich
		
		 float laserStart = Time.time;
		 while (Time.time-laserStart < 1f) {   //basically alles fancige ist nur in coroutine möglich
			 yield return (null);
			Debug.DrawRay(transform.position, transform.right);
			 if (Physics2D.Raycast(transform.position,transform.right,shotdistance, playerLayer)) {
				 LevelLoader.ResetLevel();
			 }
		 }
		 }
	}

	//source https://msdn.microsoft.com/en-us/library/system.timers.timer.elapsed(v=vs.110).aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2
	
	void CheckVision() {

	}

	
}
