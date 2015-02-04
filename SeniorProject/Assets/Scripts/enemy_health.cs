using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour {

	public float maxHealth;
	float health;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
		{
			Die ();
		}
	}

	public void Damage(float damage)
	{
		health -= damage;
	}
	
	void Heal(float healing)
	{
		health += healing;
	}
	
	void ChangeHP(float newHealth)
	{
		health = newHealth;
	}
	void Die()
	{
		Destroy (this.gameObject);
	}
}
