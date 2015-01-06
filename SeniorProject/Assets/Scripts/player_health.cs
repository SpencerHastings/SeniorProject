using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class player_health : MonoBehaviour {

	public float health = 100f;
	public float maxhealth = 100f;
	public statusbar hpbar;  
	//private float oldhealth;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		
	}

	void Damage(float damage)
	{
		health -= damage;

		UpdateBar ();
	}

	void Heal(float healing)
	{
		health += healing;
		
		UpdateBar ();
	}

	void ChangeHP(float newHealth)
	{
		health = newHealth;
		
		UpdateBar ();
	}

	void UpdateBar()
	{
		hpbar.Change (health / maxhealth);
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Damage (.2f);
		}



	}

	public void BulletHit(float damage)
	{
		Damage (damage);
	}
	
}
