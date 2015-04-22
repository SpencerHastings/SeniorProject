using UnityEngine;
using System.Collections;

public class dialog_trigger : MonoBehaviour {

	public int dialog_id;

	public GameObject dialog_box;
	private dialog_box d;
	private bool enabled = true;

	// Use this for initialization
	void Start () {

		d = dialog_box.GetComponent<dialog_box> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D triggering)
	{
		if (enabled)
		{
			d.StartDialog(dialog_storage.GetDialog(dialog_id));
			enabled = false;
		}

	}
}
