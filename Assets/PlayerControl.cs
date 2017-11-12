using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : PhysicsObject {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;

	public static PlayerControl instance;

	private SpriteRenderer spriteRenderer;

	private Collider2D coll;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		instance = this;
	}
	
	void Start ()
	{
		coll = GetComponent<Collider2D>();
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

		targetVelocity = move * maxSpeed;

		Physics2D.IgnoreLayerCollision (LayerMask.NameToLayer("Platform") , LayerMask.NameToLayer("Player"), velocity.y > 0);
	}
}
