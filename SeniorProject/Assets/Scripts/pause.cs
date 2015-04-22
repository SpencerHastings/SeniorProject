using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	private CanvasGroup canvas_grp;




	// Use this for initialization
	void Start () {
	
		canvas_grp = gameObject.GetComponent<CanvasGroup> ();
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
