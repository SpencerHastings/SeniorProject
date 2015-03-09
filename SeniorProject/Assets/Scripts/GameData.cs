using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadLevel(int scene, int entrance)
	{
		Application.LoadLevel ("scene_03");
	}
}
