using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ambiance_music : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void playmusic()
	{
		audio.Play ();
	}

	public void stopmusic()
	{
		audio.Stop ();
	}
}
