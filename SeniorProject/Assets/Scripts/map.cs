using UnityEngine;
using System.Collections;

public class map : MonoBehaviour {



	// Use this for initialization
	void Start () 
	{
		this.gameObject.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		this.gameObject.SetActive (true);
	}
	public void Hide()
	{
		this.gameObject.SetActive (false);
	}
}
