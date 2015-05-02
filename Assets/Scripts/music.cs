using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class music : MonoBehaviour 
{
	public int getmusic;
	public int nbzombi;
	public int ambiance_count;
	public GameObject go;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (getmusic == 1 && nbzombi != 0) 
		{

			ambiance_music other2 = (ambiance_music)go.GetComponent (typeof(ambiance_music));
			other2.stopmusic ();
			ambiance_count = 0; 
			audio.Play();
			getmusic = getmusic + 1;
		}
		if (ambiance_count == 0 && (nbzombi == 0 || getmusic == 0)) 
		{
			audio.Stop();

			ambiance_music other3 = (ambiance_music)go.GetComponent (typeof(ambiance_music));
			other3.playmusic ();
			ambiance_count = 1;
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