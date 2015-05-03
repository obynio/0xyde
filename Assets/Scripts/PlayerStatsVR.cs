using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatsVR : MonoBehaviour {
	
	static int MaxHealth = 100;
	public static int Health = 50;
	//var Banyan : GameObject;
	public Texture hurtEffect;	
	bool displayHurtEffect = false;
	public Transform SpawnPoint;
	public Transform Player1;
	public Transform Player2;
	bool displayHurtEffect1 = false;
	
	public Text txt;
	//var playerhit : AudioClip;
	
	float Alpha;
	
	public void ApplyDamage (int TheDammage)
	{
		audio.Play();
		displayHurtEffect = true;
		//audio.PlayClipAtPoint(playerhit, transform.position);
		//Banyan.animation.Play("Hit");
		Health -= TheDammage;
		
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
		txt.text="Health : " + Health;
		Health = MaxHealth;
		//Time.timeScale = 0;
		displayHurtEffect = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		txt.text="Health : " + Health;  
		
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
			Player1.transform.position = SpawnPoint.transform.position;
			Player2.transform.position = SpawnPoint.transform.position;
			Health = 100;
		}
		if(displayHurtEffect == true || displayHurtEffect1 == true)
		{
			StartCoroutine(StopDisplayingEffect());
		}
	}
}
