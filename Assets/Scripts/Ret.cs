using UnityEngine;
using System.Collections;

public class Ret : MonoBehaviour {

	public Camera cam;
	private Vector3 q = new Vector3(-8F,110F,0);
	
	
	void Start()
	{
		JouerSimple.anglais = true;
	}
	
	void Update()
	{
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
		cam.transform.Rotate (q);
	}
}
