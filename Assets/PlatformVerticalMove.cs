using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformVerticalMove : MonoBehaviour {


	public float moveDistance = 30f;
	public float moveSpeed = 1f;
	private List<Rigidbody2D> collList = new List<Rigidbody2D>();


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
	}

	void Move () {
		float position = Time.time * moveSpeed;
        position = Mathf.PingPong (position, moveDistance*2) - moveDistance;
		Vector2 newPosition = new Vector2 (this.transform.position.x, (position-10)); 
		Vector2 movement = newPosition - (Vector2)transform.position;
		transform.position = newPosition; 
		for (int index = 0 ; index < collList.Count ; index++) {
			collList[index].position = (collList[index].position + movement);
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.DrawRay(coll.contacts[0].point,coll.contacts[0].normal, Color.red, 1);
		if (coll.contacts[0].normal.y > -0.5) {
			coll.rigidbody.position += Vector2.down * moveSpeed * Time.fixedDeltaTime * moveDistance;
			return;
		}
		collList.Add(coll.rigidbody);
		
	}

	void OnCollisionExit2D(Collision2D coll) {
		collList.Remove(coll.rigidbody);
	}
}

