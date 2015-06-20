using UnityEngine;
using System.Collections;

public class HPMulti : MonoBehaviour {
	
	//static float curMana = 50.0f;
	//static float maxMana = 50.0f;
	public Texture2D HpBarTexture;
	float hpBarLength;
	float percentOfHp;
	//float manaBarLength;
	//float percentOfMana;
	float health;
	
	void OnGUI ()
	{
		
		GUI.depth = 1;
		
		if (PlayerStatsMulti.Health > 0)
		{
			GUI.DrawTexture(new Rect((Screen.width/2) - 100, 10, hpBarLength, 10), HpBarTexture);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		hpBarLength = PlayerStatsMulti.Health*2f;
		
		if(Input.GetKeyDown("h"))
		{
			gameObject.BroadcastMessage("ApplyDamage", 10);		
		}
	}
}
