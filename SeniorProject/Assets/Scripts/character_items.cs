﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class character_items : MonoBehaviour {

	public string item_tag;
	private GameObject Player;
	private character_attack char_attack;
	public int items = 0;
	public int item_limit;
	public Button itm_btn;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		char_attack = Player.GetComponent<character_attack> ();
		if (items <= 0)
		{
			itm_btn.gameObject.SetActive (false);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{


		if (collision. gameObject.tag == item_tag)
		{
			AddItem (1);
			Destroy(collision.gameObject);
			if (char_attack.activeItem == this)
			{
				char_attack.activeItemText.text = items.ToString(); 
			}
		}
	} 

	public void AddItem (int number)
	{
		items += number;

		if (items > item_limit)
		{
			items = item_limit;
		}

		if (itm_btn.gameObject.active == false)
		{
			itm_btn.gameObject.SetActive (true);
		}
		
	}

	public void RemoveItem (int number) 
	{
		items -= number;
		
		if (items < 0)
		{
			items = 0;
		}

		if (items == 0)
		{
			itm_btn.gameObject.SetActive (false);
		}
		

	}
}
