using UnityEngine;
using System.Collections;

public class charactermovement : MonoBehaviour {

	Vector3 velocity;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Point to Mouse
		//Vector3 mousePos = Input.mousePosition;
		//mousePos.z = 0f;
		//Vector3 objectPos = Camera.main.WorldToScreenPoint (transform.position);
		//
		//float angle = Mathf.Atan2(mousePos.y - objectPos.y, 
		//                          mousePos.x - objectPos.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


		//Move Character
		float vert = Input.GetAxis ("Vertical") * moveSpeed;
		float hort = Input.GetAxis ("Horizontal") * moveSpeed;
		velocity = new Vector3 (hort, vert, 0);

		if ((hort > 0) & (vert > 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 315));
		if ((hort == 0) & (vert > 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		if ((hort < 0) & (vert > 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));

		if ((hort > 0) & (vert == 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
		//if ((hort == 0) & (vert == 0))
		//	transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		if ((hort < 0) & (vert == 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

		if ((hort > 0) & (vert < 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 215));
		if ((hort == 0) & (vert < 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
		if ((hort < 0) & (vert < 0))
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
		
	}

	void FixedUpdate ()
	{
		rigidbody2D.velocity = velocity;
	}
}
