using UnityEngine;
using System.Collections;

public class aimove_purple_bullet : MonoBehaviour {

	private GameObject Player;
	private float speed = 20f;
	private Vector3 velocity;
	private float lifetime = 8f;
	private float life = 0f;
	private float damage = 3f;
	private player_health playershealth;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		playershealth = Player.GetComponent<player_health> ();
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 dir = Player.transform.position - transform.position;
		dir.z = 0;
		dir.Normalize();
		velocity = dir * speed;

		life += Time.deltaTime;

		if (life >= lifetime)
		{
			Destroy (gameObject);
		}
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject == Player)
		{
			playershealth.Damage(damage);
		}

		Destroy (gameObject);
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = velocity * Time.deltaTime;
	}
}
