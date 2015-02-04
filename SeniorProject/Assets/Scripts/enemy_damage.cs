using UnityEngine;
using System.Collections;

public class enemy_damage : MonoBehaviour {

	private GameObject Player;
	private player_health playershealth;
	public float damage;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		playershealth = Player.GetComponent<player_health> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject == Player)
		{
			playershealth.Damage(damage);
		}

	}
}
