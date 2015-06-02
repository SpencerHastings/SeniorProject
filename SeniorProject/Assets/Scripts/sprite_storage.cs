using UnityEngine;
using System.Collections;

public class sprite_storage : MonoBehaviour {

	public Sprite potion;
	public Sprite character;
	public Sprite bomb;
	public Sprite lightning;
	public Sprite water;
	public Sprite fire;
	public Sprite blue_enemy;
	public Sprite purple_enemy;
	public Sprite yellow_enemy;
	public Sprite chest;
	public Sprite chest_open;
	public Sprite question;
	public Sprite staff;
	public Sprite mask;
	public Sprite boots;
	public Sprite shield;
	public Sprite book;

	public Sprite GetImage(int image_id)
	{
		switch (image_id)
		{
		case 1:
			return potion;
		case 2:
			return character;
		case 3:
			return bomb;
		case 4:
			return lightning;
		case 5:
			return water;
		case 6:
			return fire;
		case 7:
			return blue_enemy;
		case 8:
			return purple_enemy;
		case 9:
			return yellow_enemy;
		case 10:
			return chest;
		case 11:
			return chest_open;
		case 12:
			return question;
		case 13:
			return staff;
		case 14:
			return mask;
		case 15:
			return boots;
		case 16:
			return shield;
		case 17:
			return book;

		default:
			return null;
		}
		
		//return null;
	}
}
