using UnityEngine;
using System.Collections;

public class aimove_yellow : MonoBehaviour {

	private GameObject Player;
	private Vector3 velocity;
	private float jumptime = .7f;
	private float jumpspeed = 70f;
	private Animator ani;
	private float dist;
	private float maxrange = .8f;
	private float time;

	// Use this for initialization
	void Start () {
	
		Player = GameObject.FindGameObjectWithTag ("Player");
		ani = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = Vector3.Distance (Player.transform.position, transform.position);
		
		if (dist < maxrange)
		{
			ani.SetInteger("attack", 1);

		}
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = velocity * Time.deltaTime;
	}

	IEnumerator Jump()
	{
		Vector3 dir = Player.transform.position - transform.position;
		dir.Normalize ();

		time = 0;
		while (time < jumptime)
		{
			time += Time.deltaTime;
			velocity = dir * jumpspeed;

			yield return null;
		}

		velocity = Vector3.zero;
		ani.SetInteger("attack", 0);


	}


}
