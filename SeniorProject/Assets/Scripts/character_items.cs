using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class character_items : MonoBehaviour {

	public string item_tag;

	public Text item_number;
	public int items = 0;
	public int item_limit;

	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{


		if (collision.gameObject.tag == item_tag)
		{
			AddItem (1);
			Destroy(collision.gameObject);
		}
	} 

	void AddItem (int number)
	{
		items += number;

		if (items > item_limit)
		{
			items = item_limit;
		}

		item_number.text = items.ToString ();

	}

	public void RemoveItem (int number) 
	{
		items -= number;
		
		if (items < 0)
		{
			items = 0;
		}
		
		item_number.text = items.ToString ();
	}
}
