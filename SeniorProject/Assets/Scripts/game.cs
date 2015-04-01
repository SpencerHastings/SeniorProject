using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

	public GameObject dialog;
	public GameObject pausemenu;
	private pause p;
	private dialog_box dlg;
	public GameObject dim;
	private SpriteRenderer dimmer;

	private charactermovement char_move;
	private GameObject player;


	// Use this for initialization
	void Start () 
	{
		dlg = dialog.GetComponent<dialog_box> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		char_move = player.GetComponent<charactermovement> ();
		dimmer = dim.GetComponent<SpriteRenderer> ();
		p = pausemenu.GetComponent<pause> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			dlg.StartDialog(dialog_storage.GetDialog(1));
		}

	}

	public void Pause()
	{
		char_move.Movable (false);
		dimmer.color = new Color (0, 0, 0, 100);
		p.Show ();
	}

	public void Unpause()
	{
		char_move.Movable (true);
		dimmer.color = new Color (0, 0, 0, 0);
		p.Hide ();
	}


}
