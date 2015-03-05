using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public GameObject dialog;
	private dialog_box dlg;


	// Use this for initialization
	void Start () 
	{
		dlg = dialog.GetComponent<dialog_box> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			dlg.StartDialog(dialog_storage.GetDialog(1));
		}

	}
}
