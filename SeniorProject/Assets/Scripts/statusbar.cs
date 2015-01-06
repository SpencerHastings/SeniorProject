using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statusbar : MonoBehaviour {

	private RectTransform rect;
	
	// Use this for initialization
	void Start () {

		rect = this.GetComponent<RectTransform>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void Change(float percent)
	{
		rect.localScale = new Vector3 (percent * 8, 4, 4);



	}

}
