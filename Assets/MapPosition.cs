using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPosition : MonoBehaviour {

	public Vector2 posOffset;
	public Vector2 posScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Scale (PlayerControl.instance.transform.position , posScale) + posOffset;
	}
}
