using UnityEngine;
using System.Collections;

public class chest : MonoBehaviour {

	public int dialog_id;
	public string item_name;
	private character_items items;
	private GameObject Player;
	private character_attack char_attack;
	private GameObject dialog_box;
	private dialog_box d;
	private bool enabled = true;
	private sprite_storage spr;
	private SpriteRenderer render;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		char_attack = Player.GetComponent<character_attack> ();
		dialog_box = GameObject.FindGameObjectWithTag ("Dialog");
		d = dialog_box.GetComponent<dialog_box> ();
		spr = dialog_box.GetComponent<sprite_storage> ();
		render = this.GetComponent<SpriteRenderer> ();

		character_items[] ch_items = char_attack.gameObject.GetComponents<character_items>();
		foreach (character_items ch_item in ch_items)
		{
			if (ch_item.item_tag == item_name)
			{
				items = ch_item;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (enabled)
		{
			d.StartDialog(dialog_storage.GetDialog(dialog_id));
			enabled = false;
			render.sprite = spr.GetImage (11);
			items.AddItem (1);
		}


		
	}
}
