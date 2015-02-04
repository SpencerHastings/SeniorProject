using UnityEngine;
using System.Collections;

public class attack_bullet : MonoBehaviour {

	private float lifetime = .5f;
	private float life = 0f;
	public float damage;
	public float speed;
	public Vector3 velocity;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		
		life += Time.deltaTime;
		
		if (life >= lifetime)
		{
			Remove ();
		}
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			collision.gameObject.GetComponent<enemy_health>().Damage(damage);
		}

		Remove ();
	}
	
	public void Remove()
	{
		Destroy (this.gameObject);
	}

	
	void FixedUpdate()
	{
		rigidbody2D.velocity = velocity * speed * Time.deltaTime;
	}
}
