using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	
	bool mute;
	
	void Start()
	{
		mute = false;
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
