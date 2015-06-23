using UnityEngine;
using System.Collections;

public class change_music : MonoBehaviour 
{
	public GameObject go;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player")
		{
			stop_musico other = (stop_musico)go.GetComponent (typeof(stop_musico));
			other.stopmusic();
			audio.Play();
		}
	}
}
