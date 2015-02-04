﻿using UnityEngine;
using System.Collections;

public class charactermovement : MonoBehaviour {

	Vector3 velocity;
	private float moveSpeed = 30f;
	private Animator ani;
	private float time = 0f;
	private bool canMove = true;
	private int direction = 3;


	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//Move Character
		float vert = Input.GetAxisRaw ("Vertical") * moveSpeed;
		float hort = Input.GetAxisRaw ("Horizontal") * moveSpeed;

		if (!canMove)
		{
			vert = 0;
			hort = 0;
		}

		velocity = new Vector3 (hort, vert, 0);

		if (hort == 0 & vert == 0)
		{
			ani.SetInteger("direction", 0);
		}
		if (hort == 0 & vert > 0)
		{
			ani.SetInteger("direction", 1);
			direction = 1;
		}
		if (hort == 0 & vert < 0)
		{
			ani.SetInteger("direction", 3);
			direction = 3;
		}
		if (hort > 0 & vert == 0)
		{
			ani.SetInteger("direction", 4);
			direction = 4;
		}
		if (hort < 0 & vert == 0)
		{
			ani.SetInteger("direction", 2);
			direction = 2;
		}

		
	}

	public void Movable(bool boolean)
	{
		canMove = boolean;
	}

	public int GetDirection()
	{
		return direction;
	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = velocity * Time.deltaTime;
	}


}
