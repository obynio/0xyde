using UnityEngine;
using System.Collections;

public class Retour : MonoBehaviour {

	public Texture2D cursor;
	private Vector2 mouse;
	private int w = 32;
	private int h = 32;
	public Camera cam;
	private Vector3 q = new Vector3(-8F,110F,0);


	void Start()
	{
		Screen.showCursor = false;

	}
	
	void Update()
	{
		mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor);
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
