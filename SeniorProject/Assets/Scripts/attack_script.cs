using UnityEngine;
using System.Collections;

public class attack_script : MonoBehaviour {

	public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



	
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.GetComponent<enemy_health>().Damage(damage);
		}

	}

	public void Remove()
	{
		Destroy (this.gameObject);
	}

}
