using UnityEngine;
using System.Collections;

public class PlayerStatsMulti : MonoBehaviour {
	
	static int MaxHealth = 100;
	public int Health = 100;
	//var Banyan : GameObject;
	public Texture hurtEffect;	
	bool displayHurtEffect = false;
	public Transform SpawnPoint;
	public Transform Player1;
	bool displayHurtEffect1 = false;
	public Texture2D HpBarTexture;
	float hpBarLength;
	float percentOfHp;
	
	//var playerhit : AudioClip;
	
	float Alpha;
	
	public void ApplyDamage (int TheDammage)
	{
		audio.Play();
		displayHurtEffect = true;
		//audio.PlayClipAtPoint(playerhit, transform.position);
		//Banyan.animation.Play("Hit");
		Health -= 20;
		
		if(Health <= 0)
		{
			//Dead();
		}
	}
	
	
	void RespawnStats ()
	{
		Health = MaxHealth;
	}
	
	void OnGUI ()
	{
		GUI.depth = 1;
		
		if (Health > 0)
		{
			GUI.DrawTexture(new Rect((Screen.width/2) - 100, 10, hpBarLength, 10), HpBarTexture);
		}
		

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
		hpBarLength = Health*2f;
		
		if(Input.GetKeyDown("h"))
		{
			gameObject.BroadcastMessage("ApplyDamage", 10);		
		}
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
			Player1.transform.position = new Vector3(0.5f, -0.5f, 0);
			Health = 100;
		}
		if(displayHurtEffect == true || displayHurtEffect1 == true)
		{
			StartCoroutine(StopDisplayingEffect());
		}
	}
}
