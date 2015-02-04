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
		if (health <= 0)
		{
			Die ();
		}


	}

	public void Damage(float damage)
	{
		health -= damage;

		UpdateBar ();
	}

	public void Heal(float healing)
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

	void Die()
	{
		Application.LoadLevel(Application.loadedLevelName);
	}


	
}
