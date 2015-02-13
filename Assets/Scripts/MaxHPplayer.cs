using UnityEngine;
using System.Collections;

public class MaxHPplayer : MonoBehaviour {
	
	public Texture2D HpMaxBarTexture;
	
	void OnGUI ()
	{		
		GUI.depth = 2;
		GUI.DrawTexture(new Rect((Screen.width/2) - 100, 10, 200, 10), HpMaxBarTexture);
	}

}
