using UnityEngine;
using System.Collections;

public class SingleP : MonoBehaviour {

	public Texture2D cursor;
	private Vector2 mouse;
	private int w = 32;
	private int h = 32;

	void Start()
	{
		Screen.showCursor = false;
		QualitySettings.antiAliasing = 8;
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
		Application.LoadLevel("0xyde");
	}
}
