using UnityEngine;
using System.Collections;

public class dialog_image : MonoBehaviour {

	private static bool isVisible = false;


	// Use this for initialization
	void Start () {



		if (!isVisible)
		{
			gameObject.SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
