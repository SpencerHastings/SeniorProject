using UnityEngine;
using System.Collections;

public class inventory_bar : MonoBehaviour {

	private CanvasGroup canvas_grp;

	// Use this for initialization
	void Start () {
		canvas_grp = gameObject.GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		canvas_grp.alpha = 1;
	}
	
	public void Hide()
	{
		canvas_grp.alpha = 0;
	}

	public void Toggle()
	{
		if (canvas_grp.alpha == 1)
		{
			Hide ();

		}
		else if (canvas_grp.alpha == 0)
		{
			Show ();

		}
	}

}
