using UnityEngine;
using System.Collections;

public class item_btn : MonoBehaviour {

	private GameObject Player;
	private character_attack char_attack;
	private GameObject inv;
	private CanvasGroup canvas_grp;
	private character_items item;
	public string tag;

	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag ("Player");
		char_attack = Player.GetComponent<character_attack> ();
		inv = GameObject.FindGameObjectWithTag ("Inventory");
		canvas_grp = inv.GetComponent<CanvasGroup> ();

		character_items[] ch_items = Player.GetComponents<character_items>();
		
		foreach (character_items ch_item in ch_items)
		{
			if (ch_item.item_tag == tag)
			{
				item = ch_item;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click()
	{
		if (canvas_grp.alpha == 1)
		{
			char_attack.activeItem = item;
		}
	}
}
