using UnityEngine;
using System.Collections;

public class SloMo : MonoBehaviour
{

	public float currentSlowMo = 0.0f;
	public float slowTimeAllowed = 2.0f;
	
	void Update ()
	{
		if(Input.GetButtonDown ("Fire2"))
		{
			if(Time.timeScale == 1.0f)
				Time.timeScale = 0.3f;
			
			else
				
				Time.timeScale = 1.0f;
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
		}
		
		if(Time.timeScale == 0.3f)
		{
			currentSlowMo += Time.deltaTime;
		}

		GameObject game = GameObject.Find("_Game");
		ModeSelect modeselect = game.GetComponent<ModeSelect>();

		if(currentSlowMo > slowTimeAllowed || modeselect.upMode == true)
		{
			currentSlowMo = 0f;
			Time.timeScale = 1.0f;
		}
	}
}

