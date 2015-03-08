using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	
	public Camera cam;

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
		cam.transform.rotation = Quaternion.Euler (0,100,0);

	}
}
