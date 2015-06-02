using UnityEngine;
using System.Collections;

public class soundmanager : MonoBehaviour {

	public AudioClip fire;
	public AudioClip lightning;
	public AudioClip water;
	public AudioClip stone;

	private AudioSource play;

	// Use this for initialization
	void Start () {

		play = this.GetComponent<AudioSource> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySound(int id)
	{
		switch (id)
		{
		case 1:
			play.PlayOneShot(fire);
			break;
		case 2:
			play.PlayOneShot(lightning);
			break;
		case 3:
			play.PlayOneShot(water);
			break;
		case 4:
			play.PlayOneShot(stone);
			break;
		
		}
	}
}
