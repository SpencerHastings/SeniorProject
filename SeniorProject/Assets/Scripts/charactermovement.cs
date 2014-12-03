using UnityEngine;
using System.Collections;

public class charactermovement : MonoBehaviour {

	Vector3 velocity;
	private float moveSpeed = 30f;
	private Animator ani;

	// Use this for initialization
	void Start () {
		ani = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		//Move Character
		float vert = Input.GetAxisRaw ("Vertical") * moveSpeed;
		float hort = Input.GetAxisRaw ("Horizontal") * moveSpeed;
		velocity = new Vector3 (hort, vert, 0);

		if (hort == 0 & vert == 0)
		{
			ani.SetInteger("direction", 0);
		}
		if (hort == 0 & vert > 0)
		{
			ani.SetInteger("direction", 1);
		}
		if (hort == 0 & vert < 0)
		{
			ani.SetInteger("direction", 3);
		}
		if (hort > 0 & vert == 0)
		{
			ani.SetInteger("direction", 4);
		}
		if (hort < 0 & vert == 0)
		{
			ani.SetInteger("direction", 2);
		}


		
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = velocity * Time.deltaTime;
	}


}
