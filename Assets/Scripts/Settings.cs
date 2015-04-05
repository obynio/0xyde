using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	
	public Camera cam;
	//public Quaternion Fin = new Quaternion(1,1,1,1);

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
		//cam.transform.rotation = Quaternion.Slerp (new Quaternion (0, 0, 0, 0), Fin, 0.0000005F);
		cam.transform.rotation = Quaternion.Euler (0, 100, 0);

	}
}
