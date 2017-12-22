using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMove : MonoBehaviour {


	public float moveDistance = 30f;
	public float moveSpeed = 1f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move () {
		float position = Time.time * moveSpeed;
        position = Mathf.PingPong (position, moveDistance*2) - moveDistance;
		transform.position = new Vector2 (this.transform.position.x, (position-10)); 
		
		//(position,this.transform.position.x);
	}
}

