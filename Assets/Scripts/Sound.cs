using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	
	void Start()
	{
		AudioListener.volume = PlayerPrefs.GetInt("Volume",1); //1 is the default value of the volume
	}

	void Update()
	{
		transform.collider.enabled = JouerSimple.anglais;
		transform.renderer.enabled = JouerSimple.anglais;
	}
	void OnMouseEnter()
	{
		transform.localScale *= 1.1f;
	}
	
	void OnMouseExit()
	{
		transform.localScale *= 0.909090f;
	}
	

	void OnMouseUp()
	{
		PlayerPrefs.SetInt ("Volume", (PlayerPrefs.GetInt ("Volume") + 1) % 2); // renvoie 1 quand volume est à 0, et renvoie 0 quand volume est à 1
		AudioListener.volume = PlayerPrefs.GetInt ("Volume");
		PlayerPrefs.Save ();
	}
}
