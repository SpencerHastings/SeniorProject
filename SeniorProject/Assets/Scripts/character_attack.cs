using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class character_attack : MonoBehaviour {

	public GameObject fire;
	public GameObject lightning;
	public GameObject bomb;
	public GameObject water;
	charactermovement char_move;
	player_health play_hlth;
	SpriteRenderer char_sprt;
	character_items bombs;
	character_items potions;
	character_items nones;
	character_items mask;
	character_items boots;
	character_items shield;
	character_items staff;
	character_items book;

	public character_items activeItem;
	public float potion_healing;
	public float fire_cost;
	public float lightning_cost;
	public float earth_cost;
	public float water_cost;
	public Image activeItemImage;
	public Text activeItemText;
	private GameObject dialog_box;
	private dialog_box d;
	private soundmanager sound;



	// Use this for initialization
	void Start () 
	{

		dialog_box = GameObject.FindGameObjectWithTag ("Dialog");
		d = dialog_box.GetComponent<dialog_box> ();
		sound = this.GetComponent<soundmanager> ();
		play_hlth = gameObject.GetComponent<player_health> ();
		char_move = gameObject.GetComponent<charactermovement> ();
		char_sprt = gameObject.GetComponent<SpriteRenderer> ();


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

			if (ch_item.item_tag == "None")
			{
				nones = ch_item;
			}

			if (ch_item.item_tag == "Mask")
			{
				mask = ch_item;
			}

			if (ch_item.item_tag == "Boots")
			{
				boots = ch_item;
			}

			if (ch_item.item_tag == "Shield")
			{
				shield = ch_item;
			}

			if (ch_item.item_tag == "Staff")
			{
				staff = ch_item;
			}

			if (ch_item.item_tag == "Book")
			{
				book = ch_item;
			}

		}

		activeItem = nones;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (activeItem != null && !d.isActive && char_move.canMove)
		{
			if (Input.GetButtonDown("Item") && activeItem.items > 0)
			{
				if (activeItem == bombs)
				{
					Bomb ();
				}
				if (activeItem == potions)
				{
					Potion ();
				}
				if (activeItem == mask)
				{
					d.StartDialog(dialog_storage.GetDialog(13));
				}
				if (activeItem == boots)
				{
					d.StartDialog(dialog_storage.GetDialog(14));
				}
				if (activeItem == shield)
				{
					d.StartDialog(dialog_storage.GetDialog(16));
				}
				if (activeItem == staff)
				{
					d.StartDialog(dialog_storage.GetDialog(15));
				}
				if (activeItem == book)
				{
					d.StartDialog(dialog_storage.GetDialog(17));
				}

				activeItemText.text = activeItem.items.ToString();
			}
		}

		if (char_move.canMove)
		{

			if (Input.GetButtonDown("Fire"))
			{
				Fire(char_move.GetDirection());
				sound.PlaySound(1);
			}

			if (Input.GetButtonDown("Lightning"))
			{
				Lightning(char_move.GetDirection());
				sound.PlaySound(2);
			}

			if (Input.GetButtonDown("Water"))
			{
				Water(char_move.GetDirection());
				sound.PlaySound(3);
			}

			if (Input.GetButtonDown("Earth"))
			{
				play_hlth.Damage(earth_cost * 2);
				play_hlth.ChangeDefense(.5f);
				sound.PlaySound(4);
			}

			if (Input.GetButton("Earth"))
			{
				Earth();
			}
		}

		if (Input.GetButtonUp("Earth"))
		{
			char_sprt.color = Color.white;
			play_hlth.ChangeDefense(1f);
		}

		if (Input.GetButton("Pause"))
		{
			Application.Quit();
		}

		


	
	}

	void Potion()
	{
		play_hlth.Heal(potion_healing);
		potions.RemoveItem(1);
	}

	void Bomb()
	{
		GameObject newbomb = (GameObject)Instantiate(bomb, transform.position, new Quaternion(0,0,0,0));
		bombs.RemoveItem(1);
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

	void Earth()
	{
		char_sprt.color = new Color32(150,75,0,255);
		play_hlth.Damage(earth_cost * Time.deltaTime);
	}

	void Water(int direction)
	{
		GameObject newwater = (GameObject)Instantiate(water, transform.position, new Quaternion(0,0,0,0));
		newwater.transform.Rotate(new Vector3(0, 0, (direction - 1) * 90));
		
		switch (direction)
		{
		case 1:
			newwater.transform.position += new Vector3(0,.15f,0);
			break;
		case 2:
			newwater.transform.position += new Vector3(-.15f,0,0);
			break;
		case 3:
			newwater.transform.position += new Vector3(0,-.15f,0);
			break;
		case 4:
			newwater.transform.position += new Vector3(.15f,0,0);
			break;
		}
		play_hlth.Damage(water_cost);
		char_move.Pause (.3f);


	}

	public void SetItem(Sprite image)
	{
		activeItemImage.sprite = image;
		activeItemText.text = activeItem.items.ToString();
	}

}
