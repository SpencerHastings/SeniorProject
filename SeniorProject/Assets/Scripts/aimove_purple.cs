using UnityEngine;
using System.Collections;

public class aimove_purple : MonoBehaviour {

	private GameObject Player;
	private Animator ani;
	private float dist;
	private float maxrange = .8f;
	public GameObject bullet;
	private float cooldown = 1f;
	private float timing;
	private int numofbullets = 4;
	private float bulletrefresh = 0f;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		ani = this.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		dist = Vector3.Distance (Player.transform.position, transform.position);
		
		if (dist < maxrange)
		{
			if (timing == 0f & numofbullets > 0)
			{
				Shoot ();
				timing = cooldown;
			}
		}

		if (timing > 0f)
		{
			timing -= Time.deltaTime;
		}

		if (timing < 0f)
		{
			timing = 0f;
		}
	
	}

	void Shoot()
	{
		GameObject newbullet = (GameObject)Instantiate(bullet, transform.position, new Quaternion(0,0,0,0));
		numofbullets -= 1;
	}
}
