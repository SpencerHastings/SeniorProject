﻿using UnityEngine;
using System.Collections;

public class change_scene : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OpenScene()
	{
		Application.LoadLevel (scene);
	}

}


