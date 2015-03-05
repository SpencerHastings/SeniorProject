using UnityEngine;
using System.Collections;

public class aimove_purple : MonoBehaviour {

	private GameObject Player;
	private Animator ani;
	private float dist;
	public GameObject bullet;
	private float cooldown;
	private float bulletTimer;
	private int bullets;
	private Vector3 velocity;

	private float speed = 1f;
	private readonly float bulletRefresh = 2f;
	private readonly float cooldownTime = .5f;
	private readonly float maxrange = .8f;
	private readonly int magazine = 4;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		ani = this.GetComponent<Animator>();
		bullets = magazine;
	
	}
	
	// Update is called once per frame
	void Update () {

		dist = Vector3.Distance (Player.transform.position, transform.position);
		
		if (dist < maxrange)
		{
			if (cooldown == 0f & bullets > 0)
			{
				Shoot ();
				cooldown = cooldownTime;
			}

			Vector3 dir = Player.transform.position - transform.position;
			dir.z = 0;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize();
			
			// Move ourselves in that direction
			velocity = dir * speed;

		}
		else
		{
			velocity *= 0;
		}

		if (cooldown > 0f)
		{
			cooldown -= Time.deltaTime;
		}

		if (cooldown < 0f)
		{
			cooldown = 0f;
		}

		if (bulletTimer > 0f)
		{
			bulletTimer -= Time.deltaTime;
		}
		
		if (bulletTimer < 0f)
		{
			bulletTimer = 0f;
			bullets += 1;
		}

		if (bulletTimer == 0 & bullets < magazine)
		{
			bulletTimer = bulletRefresh;
		}
	
	}

	void Shoot()
	{
		GameObject newbullet = (GameObject)Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
		bullets -= 1;
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().velocity = velocity * Time.deltaTime;
	}


}
