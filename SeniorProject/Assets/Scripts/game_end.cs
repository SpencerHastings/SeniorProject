using UnityEngine;
using System.Collections;

public class game_end : MonoBehaviour {

	character_items mask;
	character_items boots;
	character_items shield;
	character_items staff;
	private GameObject dialog_box;
	private dialog_box d;
	private GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		dialog_box = GameObject.FindGameObjectWithTag ("Dialog");
		d = dialog_box.GetComponent<dialog_box> ();

		character_items[] ch_items = player.gameObject.GetComponents<character_items>();
		
		foreach (character_items ch_item in ch_items)
		{

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

		}
	
	}

	public void OnTriggerEnter2D(Collider2D triggering)
	{
		if (mask.items > 0 && boots.items > 0 && shield.items > 0 && staff.items > 0)
		{
			d.StartDialog(dialog_storage.GetDialog(19));
		}
		else
		{
			d.StartDialog(dialog_storage.GetDialog(18));
		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
