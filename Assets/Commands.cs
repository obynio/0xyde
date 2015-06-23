using UnityEngine;
using System.Collections;

public class Commands : MonoBehaviour {

	public Texture Im;
	private bool ison = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
		if (!ison)
			GUI.DrawTexture (new Rect(0,0,Im.width,Im.height), Im);
		ison = !ison;
	}

}
