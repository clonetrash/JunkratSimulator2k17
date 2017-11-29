using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

	bool playerOnGold = false;
	public FloatProperty gold;
	public CountdownProperty countdown;

	// Use this for initialization
	void Start () {
		countdown.Stop();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Gold") && playerOnGold) 
		{
		gold.value += Time.deltaTime * 100;
		print ("HOLLA HOLLA GET $$$");
		countdown.CountTime(100);
		}
	}

	void OnTriggerExit2D (Collider2D coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
		playerOnGold = false;
	} 

	void OnTriggerEnter2D (Collider2D coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Player"))
		playerOnGold = true;
	} 
}
