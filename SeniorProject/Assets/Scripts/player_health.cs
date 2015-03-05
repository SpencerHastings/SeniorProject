using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class player_health : MonoBehaviour {

	public float health = 100f;
	public float maxhealth = 100f;
	public statusbar hpbar;
	float defense_modifier = 1f;
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
		health -= damage * defense_modifier;

		UpdateBar ();
	}

	public void Heal(float healing)
	{
		health += healing;

		if (health > maxhealth)
		{
			health = maxhealth;
		}

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

	public void ChangeDefense(float newDM)
	{
		defense_modifier = newDM;
	}


	
}
