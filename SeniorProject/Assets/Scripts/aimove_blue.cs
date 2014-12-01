using UnityEngine;
using System.Collections;

public class aimove_blue : MonoBehaviour {

	private GameObject Player;
	private float speed = .3f;
	private float range = 4f;
	private Animator ani;
	private Vector3 velocity;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Vector3.Distance(Player.transform.position, transform.position) < range)
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
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Vector3 dir = collision.gameObject.transform.position - transform.position;
			dir.Normalize();
			dir.z = 0;
			collision.gameObject.transform.position += dir * 100f;
		}
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = velocity;
	}
}
