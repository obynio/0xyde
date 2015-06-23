using UnityEngine;
using System.Collections;

public class stop_musico : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void stopmusic()
	{
		audio.Stop ();
	}
}
