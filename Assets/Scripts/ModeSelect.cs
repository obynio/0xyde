using UnityEngine;
using System.Collections;

public class ModeSelect : MonoBehaviour
{

	public bool upMode = true;	

	public GameObject fpc;
	public GameObject up;
	public GameObject cam1;
	public Texture HUD;
	public Texture HUDFPS;
	

	private Vector2 mouse;
	private int w = 32;
	private int h = 32;
	public Texture2D cursor;

	void Start()
	{
		Screen.showCursor = false;
		//Screen.lockCursor = true;
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("0xyde Menu");
		}

		if (Input.GetButtonDown ("Mode"))
		{
			upMode = !upMode;
		}

		if (upMode == true)
		{
			Screen.showCursor = false;
			fpc.SetActive(false);
			fpc.transform.position = up.transform.position;
			up.SetActive(true);
			cam1.SetActive(true);
			Time.timeScale = 1.0f;
		}
		else
		{
			up.SetActive(false);
			cam1.SetActive(false);
			up.transform.position = fpc.transform.position;
			cam1.transform.position = new Vector3 (fpc.transform.position.x, cam1.transform.position.y, fpc.transform.position.z);
			fpc.SetActive(true);
			Screen.showCursor = false;
		}

		mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
	}

	public void Set_mode()
	{
		upMode = !upMode;
	}

	void OnGUI()
	{
		if (upMode)
		{
			GUI.DrawTexture(new Rect(mouse.x - (w / 2), mouse.y - (h / 2), w, h), cursor);
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), HUD);
		}
		else
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), HUDFPS);
		}
	}
}
