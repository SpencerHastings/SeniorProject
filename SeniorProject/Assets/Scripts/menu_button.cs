using UnityEngine;
using System.Collections;

public class menu_button : MonoBehaviour {

	public GameObject pausemenu;
	private CanvasGroup p;
	public string button;
	public GameObject game;
	private game g;

	// Use this for initialization
	void Start () {
		g = game.GetComponent<game> ();
		p = pausemenu.GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click()
	{

		if (button == "Resume")
		{
				g.Unpause();
		}
		if (button == "Save")
		{
				
		}
		if (button == "Load")
		{
				
		}
		if (button == "Title")
		{
			
		}


	}
}
