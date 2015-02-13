using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	static int MaxHealth = 100;
	public static int Health = 50;
	//var Banyan : GameObject;
	public Texture hurtEffect;	
	bool displayHurtEffect = false;
	bool displayHurtEffect1 = false;
	//var playerhit : AudioClip;
	
	float Alpha;

	
	public void ApplyDamage (int TheDammage)
	{
		displayHurtEffect = true;
		//audio.PlayClipAtPoint(playerhit, transform.position);
		//Banyan.animation.Play("Hit");
		Health -= TheDammage;
		
		if(Health <= 0)
		{
			//Dead();
		}
	}
	/*
function Dead()
{
	RespawnMenuV2.playerIsDead = true;
	Debug.Log("Player Died"); 
}
	*/
	
	void RespawnStats ()
	{
		Health = MaxHealth;
	}
	
	void OnGUI ()
	{
		if(displayHurtEffect == true)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hurtEffect);
			displayHurtEffect1 = true;
		}
	}

	IEnumerator StopDisplayingEffect() 
	{
		//if (RespawnMenuV2.playerIsDead == false)
		yield return new WaitForSeconds(0.1f);

		displayHurtEffect = false;
		displayHurtEffect1 = false;
	}
	// Use this for initialization
	void Start ()
	{
		Health = MaxHealth;
		//Time.timeScale = 0;
		displayHurtEffect = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Health >100)
		{
			Health = 100;
		}
		if (Health <0)
		{
			Health = 0;
		}
		if(Health <= 0)
		{
			//Dead();
		}
		if(displayHurtEffect == true || displayHurtEffect1 == true)
		{
			StartCoroutine(StopDisplayingEffect());
		}
	}
}
