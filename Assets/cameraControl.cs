using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class cameraControl : MonoBehaviour {

	public Vector2 camBoxSize;
	public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		Vector3 posPosition = transform.position;
		Vector3 minPosition = player.position - (Vector3)camBoxSize;
		Vector3 maxPosition = player.position + (Vector3)camBoxSize;
		minPosition.z = float.MinValue;
		maxPosition.z = float.MaxValue;

		posPosition = Vector3.Max(minPosition,posPosition);
		posPosition = Vector3.Min(maxPosition,posPosition);

		transform.position = posPosition;
	}
}
