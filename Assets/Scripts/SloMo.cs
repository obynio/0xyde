using UnityEngine;
using System.Collections;

public class SloMo : MonoBehaviour
{
	public float currentSlowMo = 2.0f;

	public Texture2D RlBarTexture;
	float rlBarLength;
	float percentOfHp;

	void Start()
	{
		currentSlowMo = 2.0f;
	}

	void OnGUI ()
	{
		
		GUI.depth = 1;
		
		if (currentSlowMo > 0)
		{
			GUI.DrawTexture(new Rect((Screen.width/2) - 100, Screen.height - 20, rlBarLength, 10), RlBarTexture);
		}
	}
	
	void Update ()
	{
		rlBarLength = currentSlowMo *100f;
		if (currentSlowMo <= 1.99f && Time.timeScale > 0.7f)
		{
			currentSlowMo += 0.002f;
			if (currentSlowMo > 1.99)
			{
				currentSlowMo = 2.0f;
			}
		}

		if(Input.GetButtonDown ("Fire2"))
		{
			if(Time.timeScale == 1.0f && currentSlowMo > 0.3f)
			{
				Time.timeScale = 0.3f;			
			}
			
			else
				
				Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		
		if(Time.timeScale == 0.3f)
		{
			currentSlowMo -= Time.deltaTime;
		}

		//GameObject game = GameObject.Find("_Game");
		//ModeSelect modeselect = game.GetComponent<ModeSelect>();

		if(currentSlowMo <= 0)
		{
			currentSlowMo = 0f;
			Time.timeScale = 1.0f;
		}
	}
}

