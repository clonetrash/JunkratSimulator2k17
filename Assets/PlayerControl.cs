using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public FloatProperty gold;
	public static PlayerControl instance;
	 private Animator animator;



	// Use this for initialization
	void Awake () 
	{
		instance = this;
		 animator = GetComponent<Animator> ();
	}
	
	new void Start ()
	{
		gold.value = 0f; 
		base.Start();
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown("Jump") && grounded)
		{
			velocity.y = jumpTakeOffSpeed;	
		}
		else if (Input.GetButtonUp("Jump")) //abbrechen des sprunges on der Luft
		{
			if (velocity.y > 0)
				velocity.y = velocity.y * 0.5f;
		}

		bool flipSprite = (move.x > 0.0f);
		if (move.x != 0)
		{
			transform.localScale = new Vector3 (flipSprite ? -1 : 1,1,1);
		}

		animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

		
		targetVelocity = move * maxSpeed * (1/(1+gold.value/1000));
	}
}
