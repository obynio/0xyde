using UnityEngine;
using System.Collections;

public class Son : MonoBehaviour {
	

	void Update()
	{
		transform.collider.enabled = !JouerSimple.anglais;
		transform.renderer.enabled = !JouerSimple.anglais;
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
		PlayerPrefs.SetInt ("Volume", (PlayerPrefs.GetInt ("Volume") + 1) % 2);
		AudioListener.volume = PlayerPrefs.GetInt ("Volume");
		PlayerPrefs.Save ();
	}
}
