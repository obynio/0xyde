﻿using UnityEngine;
using System.Collections;

public class FullScreen : MonoBehaviour {
	
	void Start()
	{
		JouerSimple.anglais = true;
		Screen.showCursor = false;
	}

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
		Screen.fullScreen = !Screen.fullScreen;
	}
}
