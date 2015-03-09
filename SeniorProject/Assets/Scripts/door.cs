using UnityEngine;
using System.Collections;

public class door : MonoBehaviour 
{
	public door partner;
	public bool isDoorFacingUp;	

	public void OnTriggerEnter2D(Collider2D triggering)
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (partner.isDoorFacingUp)
		{
			player.transform.position = partner.transform.position + new Vector3(0f,.1f,0f);
		}
		if (!partner.isDoorFacingUp)
		{
			player.transform.position = partner.transform.position - new Vector3(0f,.1f,0f);
		}

	}

}
