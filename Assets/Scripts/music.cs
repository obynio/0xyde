using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class music : MonoBehaviour 
{
	public int getmusic;
	public int nbzombi;
	// Use this for initialization
	void Start () 
	{
		getmusic = 0;
		nbzombi = 6;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (getmusic == 1 && nbzombi != 0) 
		{
			audio.Play();
			getmusic = getmusic + 1;
		}
		if (getmusic == 0 || nbzombi == 0) 
		{
			audio.Stop();
		}
	}
	
	public void up_music()
	{
		getmusic = getmusic+1;
	}
	
	public void down_music()
	{
		if (getmusic == 2) 
		{
			getmusic = getmusic - 2;
		} 
		else
		{
			getmusic = getmusic - 1;
		}
	}
	
	public void down_zombie()
	{
		nbzombi = nbzombi - 1;
	}
}