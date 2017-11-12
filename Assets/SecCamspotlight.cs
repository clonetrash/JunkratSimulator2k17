using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecCamspotlight : MonoBehaviour {

	public float controlAngle = 30f;
	public float controlRange = 10f;
	public LayerMask seeMask;
	float baseRotation;
	public float rotationAngle = 30f;
	public float sweepSpeed = 1f;

	// Use this for initialization
	void Start () 
	{
		baseRotation = transform.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		Sweep();
		CheckVision();
	}

	void Sweep()
	{
		float rotation = Time.time * sweepSpeed * 360;
		rotation  = Mathf.PingPong (rotation, rotationAngle*2) - rotationAngle;
		rotation += baseRotation; 
		transform.eulerAngles = new Vector3 (0,0, rotation);
	}

	void CheckVision()
	{
		Vector2 viewDirection = -transform.up;
		Vector2 toPlayerDirection = PlayerControl.instance.transform.position - transform.position;
		float angle = Vector2.Angle (viewDirection, toPlayerDirection);
		float distance = toPlayerDirection.magnitude;
		 
		if (angle < controlAngle && distance < controlRange) 
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, toPlayerDirection, toPlayerDirection.magnitude, seeMask);
			if ( hit.collider ==null)
			{
				Debug.Log ("found u");
				levelLoader.ResetLevel();
			}
			else{		
				Debug.DrawRay (hit.point, hit.normal);
			}
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.cyan;
		Vector2 controlEdges = -transform.up * controlRange;
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + controlEdges.Rotate (controlAngle));
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + controlEdges.Rotate (-controlAngle));
		Gizmos.DrawLine (transform.position, (Vector2)transform.position + controlEdges);
	}
}
