using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]

public class MoneyTextPlacement : MonoBehaviour {

	public Transform player;
	private Camera cam;
	public Vector2 offset;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector2 playerInViewport = cam.WorldToScreenPoint(player.position);
		transform.position = playerInViewport + offset;
	}
}
