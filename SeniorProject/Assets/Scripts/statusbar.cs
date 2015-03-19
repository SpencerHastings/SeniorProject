﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class statusbar : MonoBehaviour {

	private RectTransform rect;
	private Vector3 position;
	
	// Use this for initialization
	void Start () {

		rect = this.GetComponent<RectTransform>();
		position = rect.position;
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void Change(float percent)
	{
		rect.localScale = new Vector3 (percent * 6, 3, 3);



	}

}
