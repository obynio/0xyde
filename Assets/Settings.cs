﻿using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

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
		//settings
	}
}
