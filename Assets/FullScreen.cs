using UnityEngine;
using System.Collections;

public class FullScreen : MonoBehaviour {

	void Start()
	{
		Screen.showCursor = false;
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
		Screen.fullScreen = !Screen.fullScreen;
	}
}
