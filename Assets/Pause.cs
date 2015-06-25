using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
	public static bool pause;
	public static bool play;

	public GUISkin theSkin;
	public GameObject go;
	public GameObject go2;
	public GameObject osd;
	
	private bool time;
	
	
	
	void Start()
	{
		pause = false;
		play = false;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			pause = !pause;
		}
		if(pause)
		{
			osd.audio.Pause();
			MouseLook other = (MouseLook)go.GetComponent (typeof(MouseLook));
			MouseLook other2 = (MouseLook)go2.GetComponent (typeof(MouseLook));
			other.enabled = false;
			other2.enabled = false;
			Time.timeScale = 0;
			time = false;
			play = false;
		}
		else
		{
			if (!time)
			{
				Time.timeScale = 1;
				time = true;
			}
			MouseLook other = (MouseLook)go.GetComponent (typeof(MouseLook));
			MouseLook other2 = (MouseLook)go2.GetComponent (typeof(MouseLook));
			other2.enabled = true;
			other.enabled = true;
			if (!play)
			{
				if(osd.audio.time != 0)
				{
					osd.audio.Play();
				}
				play = true;
			}
		}
	}
	
	void OnGUI () {
		GUI.skin = theSkin;
		GUI.depth = 1;
		
		if(pause)
		{
			if (PlayerPrefs.GetInt("anglais") != 0)
			{
				GUI.depth = 2;

				GUI.Box(new Rect(Screen.width/2 - (Screen.width/4)/2, Screen.height/2 -(Screen.height/2)/2, Screen.width/4, Screen.height/2.18f), "MENU :");
				
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, (Screen.height/2 - (Screen.height/8)/2) - Screen.height/8, Screen.width/5, Screen.height/8), "Reprendre"))
				{
					pause = false;
				}
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, Screen.height/2 - (Screen.height/8)/2, Screen.width/5, Screen.height/8), "Retour menu"))
				{
					Application.LoadLevel("0xyde Menu");;
				}
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, (Screen.height/2 - (Screen.height/8)/2) + Screen.height/8, Screen.width/5, Screen.height/8), "Quitter"))
				{
					Application.Quit();
				}
			}
			else
			{
				GUI.Box(new Rect(Screen.width/2 - (Screen.width/4)/2, Screen.height/2 -(Screen.height/2)/2, Screen.width/4, Screen.height/2.18f), "MENU :");
				
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, (Screen.height/2 - (Screen.height/8)/2) - Screen.height/8, Screen.width/5, Screen.height/8), "Resume"))
				{
					pause = false;
				}
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, Screen.height/2 - (Screen.height/8)/2, Screen.width/5, Screen.height/8), "Main Menu"))
				{
					Application.LoadLevel("0xyde Menu");;
				}
				if(GUI.Button(new Rect(Screen.width/2 -(Screen.width/5)/2, (Screen.height/2 - (Screen.height/8)/2) + Screen.height/8, Screen.width/5, Screen.height/8), "Quit"))
				{
					Application.Quit();
				}
			}

		}	
	}	
}
