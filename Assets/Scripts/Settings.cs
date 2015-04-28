using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	
	public Camera cam;
	//public Quaternion Debut = new Quaternion (cam.transform.rotation.x, cam.transform.rotation.y, cam.transform.rotation.z,cam.transform.rotation.w);
	//public Quaternion Fin = new Quaternion(cam.transform.rotation.x, (cam.transform.rotation.y-100), cam.transform.rotation.z,cam.transform.rotation.w)	;

	void Update () {
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

		cam.transform.rotation = Quaternion.Slerp (cam.transform.rotation, Quaternion.Euler (0, 100F, 0), 1F);
						//cam.transform.rotation = Quaternion.Euler (0, 100F, 0);
				
	}
}
