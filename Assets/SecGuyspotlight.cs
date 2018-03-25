using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecGuyspotlight : MonoBehaviour {

	public float controlAngle = 30f;
	public float controlRange = 10f;
	public LayerMask seeMask;
	public Transform eye;
	public float moveDistance = 30f;
	public float moveSpeed = 1f;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () 
	{
		startPosition = (transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{ 
		Move();
		CheckVision();
	}

	void Move()
	{
        float position = Time.time * moveSpeed;
        position = Mathf.PingPong (position, moveDistance*2) - moveDistance;
        transform.position = startPosition + new Vector3 (position,0,0);
        float directionCheck = (Time.time * moveSpeed) % (moveDistance*4);
        bool lookingRight = eye.eulerAngles.z < 180;
        if (directionCheck > moveDistance * 2 && lookingRight)
        {
            eye.eulerAngles = new Vector3 (0,0, -eye.eulerAngles.z);
        }
        else if (directionCheck < moveDistance*2 && !lookingRight)
        {
             eye.eulerAngles = new Vector3 (0,0, -eye.eulerAngles.z);
        } 
       
	}

	void CheckVision()
	{
		Vector2 viewDirection = -eye.up;
		Vector2 toPlayerDirection = PlayerControl.instance.transform.position - eye.position;
		float angle = Vector2.Angle (viewDirection, toPlayerDirection);
		float distance = toPlayerDirection.magnitude;
		 
		if (angle < controlAngle && distance < controlRange) 
		{
			RaycastHit2D hit = Physics2D.Raycast(eye.position, toPlayerDirection, toPlayerDirection.magnitude, seeMask);
			if ( hit.collider ==null)
			{
				
				LevelLoader.ResetLevel();
			}
			else{		
				Debug.DrawRay (hit.point, hit.normal);
			}
		}
	}

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		Vector2 controlEdges = -eye.up * controlRange;
		Gizmos.DrawLine (eye.position, (Vector2)eye.position + controlEdges.Rotate (controlAngle));
		Gizmos.DrawLine (eye.position, (Vector2)eye.position + controlEdges.Rotate (-controlAngle));
		Gizmos.DrawLine (eye.position, (Vector2)eye.position + controlEdges);
	}
}
