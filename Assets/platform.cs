using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour {

	public Collider2D collision;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		collision.enabled = false;
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		collision.enabled = true;
	}
}
