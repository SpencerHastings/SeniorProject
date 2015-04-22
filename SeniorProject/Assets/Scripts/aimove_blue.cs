using UnityEngine;
using System.Collections;

public class aimove_blue : MonoBehaviour {

	private GameObject Player;
	private float speed = 10f;
	private float maxrange = 1f;


	private Animator ani;
	private Vector3 velocity;
	private float dist;


	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");

		ani = this.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = Vector3.Distance (Player.transform.position, transform.position);

		if ((dist < maxrange))
		{
			ani.SetInteger("attack", 1);
			// Get a direction vector from us to the target
			Vector3 dir = Player.transform.position - transform.position;
			dir.z = 0;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize();
			
			// Move ourselves in that direction
			velocity = dir * speed;
		}
		else
		{
			ani.SetInteger("attack", 0);
			velocity *= 0;
		}

		if (velocity.x > 0)
		{
			ani.SetInteger("direction", 0);
		}
		if (velocity.x < 0)
		{
			ani.SetInteger("direction", 1);
		}
	
	}



	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = velocity * Time.deltaTime;
	}
}
