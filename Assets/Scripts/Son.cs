using UnityEngine;
using System.Collections;

public class Son : MonoBehaviour {

	bool mute;
	
	void Start()
	{
		JouerSimple.anglais = true;
		mute = false;
	}
	
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
		if (mute == false)
			AudioListener.volume = 0;
		if (mute == true)
			AudioListener.volume = 1;
		
		mute = !mute;
	}
}
