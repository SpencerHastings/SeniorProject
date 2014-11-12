using UnityEngine;
using System.Collections;

public class characterattack : MonoBehaviour {

	public Sprite standing;
	public Sprite attacking;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space"))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = attacking;

		}
		if (Input.GetKeyUp("space"))
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = standing;
			
		}
	
	}
}
