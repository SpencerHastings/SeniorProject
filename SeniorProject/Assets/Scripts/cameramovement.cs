﻿using UnityEngine;
using System.Collections;

public class cameramovement : MonoBehaviour {

	public GameObject following;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (following.transform.position.x, 
		                                  following.transform.position.y, 
		                                  -10);

	}
}
