using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {
	public Camera cam;

	// Update is called once per frame
	void Start()
	{
		JouerSimple.anglais = true;
	}

	void Update () {
		transform.renderer.enabled = !JouerSimple.anglais;
		transform.collider.enabled = !JouerSimple.anglais;
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
