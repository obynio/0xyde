using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class music : MonoBehaviour 
{
	public int getmusic;
	private bool bullshit;

	// Use this for initialization
	void Start () 
	{
		getmusic = 0;
		bullshit = true;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if (getmusic >= 0 && bullshit) 
		{
			//audio.Play();
			bullshit = false;
		}
		if (getmusic == 0)
		{
			//audio.Stop();
			bullshit = true;
		}
	}

	public void up_music()
	{
		getmusic++;
	}

	public void down_music()
	{
		getmusic--;
	}
}
