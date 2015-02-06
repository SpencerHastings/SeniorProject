using UnityEngine;
using System.Collections;

public class character_attack : MonoBehaviour {

	public GameObject fire;
	public GameObject lightning;
	public GameObject Bomb;
	charactermovement char_move;
	player_health play_hlth;
	character_items bombs;
	character_items potions;
	public float potion_healing;
	public float fire_cost;
	public float lightning_cost;

	// Use this for initialization
	void Start () {

		play_hlth = gameObject.GetComponent<player_health> ();
		char_move = gameObject.GetComponent<charactermovement> ();



		character_items[] ch_items = gameObject.GetComponents<character_items>();

		foreach (character_items ch_item in ch_items)
		{
			if (ch_item.item_tag == "Bomb")
			{
				bombs = ch_item;
			}

			if (ch_item.item_tag == "Potion")
			{
				potions = ch_item;
			}

		}
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.Space) && bombs.items > 0)
		{
			GameObject newbomb = (GameObject)Instantiate(Bomb, transform.position, new Quaternion(0,0,0,0));
			bombs.RemoveItem(1);
		}

		if (Input.GetKeyDown(KeyCode.LeftControl) && potions.items > 0)
		{
			play_hlth.Heal(potion_healing);
			potions.RemoveItem(1);
		}

		if (Input.GetKeyDown(KeyCode.Z))
		{
			Fire(char_move.GetDirection());

		}

		if (Input.GetKeyDown(KeyCode.X))
		{
			Lightning(char_move.GetDirection());
			
		}

		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}


	
	}


	void Fire(int direction)
	{
		Vector3 newvelocity = Vector3.zero;
		GameObject newfire = (GameObject)Instantiate(fire, transform.position, new Quaternion(0,0,0,0));
		newfire.transform.Rotate(new Vector3(0, 0, (direction) * 90));

		switch (direction)
		{
		case 1:
			newvelocity = new Vector3(0,1,0);
			break;
		case 2:
			newvelocity = new Vector3(-1,0,0);
			break;
		case 3:
			newvelocity = new Vector3(0,-1,0);
			break;
		case 4:
			newvelocity = new Vector3(1,0,0);
			break;
		}
		newfire.GetComponent<attack_bullet> ().velocity = newvelocity;
		play_hlth.Damage(fire_cost);
		char_move.Pause (.1f);
	}

	void Lightning(int direction)
	{

		GameObject newlightning = (GameObject)Instantiate(lightning, transform.position, new Quaternion(0,0,0,0));
		newlightning.transform.Rotate(new Vector3(0, 0, (direction - 1) * 90));

		switch (direction)
		{
		case 1:
			newlightning.transform.position += new Vector3(0,.15f,0);
			break;
		case 2:
			newlightning.transform.position += new Vector3(-.15f,0,0);
			break;
		case 3:
			newlightning.transform.position += new Vector3(0,-.15f,0);
			break;
		case 4:
			newlightning.transform.position += new Vector3(.15f,0,0);
			break;
		}
		play_hlth.Damage(lightning_cost);
		char_move.Pause (.3f);


	}
}
