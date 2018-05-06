using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BombThrow : MonoBehaviour {

	public Transform startPoint ;
	public Vector2 throwDirection ;
	public Rigidbody2D bomb ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetButtonDown ("Bomb")) {
			Rigidbody2D newBomb = Instantiate(bomb, startPoint.position, Quaternion.identity);
			Vector2 worldThrow = startPoint.TransformVector(throwDirection);
			newBomb.AddForce(worldThrow, ForceMode2D.Impulse);
		}

	}
}
