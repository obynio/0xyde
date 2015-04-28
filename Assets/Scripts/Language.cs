using UnityEngine;
using System.Collections;

public class Language : MonoBehaviour {

	void Update()
	{
		transform.renderer.enabled = JouerSimple.anglais;
		transform.collider.enabled = JouerSimple.anglais;
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
		JouerSimple.anglais = !JouerSimple.anglais;
		PlayerPrefs.SetInt ("anglais", (PlayerPrefs.GetInt ("anglais") + 1) % 2);
		PlayerPrefs.Save ();
	}
}
