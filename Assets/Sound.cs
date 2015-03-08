using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

	public Texture2D cursor;
	private Vector2 mouse;
	private int w = 32;
	private int h = 32;
	bool mute;
	
	void Start()
	{
		Screen.showCursor = false;
		mute = false;
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
		if (mute == false)
						AudioListener.volume = 0;
		if (mute == true)
						AudioListener.volume = 1;
		mute = !mute;
	}
}
