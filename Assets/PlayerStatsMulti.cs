using UnityEngine;
using System.Collections;

class PlayerStatsMulti : Photon.MonoBehaviour {
	
	public int MaxHealth = 100;
	private int Health;
	//var Banyan : GameObject;
	public Texture hurtEffect;
	private bool displayHurtEffect = false;
	public Transform SpawnPoint;
	public Transform Player1;
	private bool displayHurtEffect1 = false;
	public Texture2D HpBarTexture;
	private float hpBarLength;
	private float percentOfHp;
	
	//var playerhit : AudioClip;
	
	public void ApplyDamage ()
	{
		if (photonView.isMine)
		{
			Debug.Log (gameObject.name);
			audio.Play();
			displayHurtEffect = true;
			Health -= 20;
		}
	}


	void OnGUI ()
	{
		if (photonView.isMine)
		{
			GUI.DrawTexture(new Rect((Screen.width/2) - 100, 10, hpBarLength, 10), HpBarTexture);

			if(this.displayHurtEffect == true)
			{
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), hurtEffect);
				this.displayHurtEffect1 = true;
			}
		}
	}
	
	IEnumerator StopDisplayingEffect() 
	{
		//if (RespawnMenuV2.playerIsDead == false)
		yield return new WaitForSeconds(0.1f);
		
		this.displayHurtEffect = false;
		this.displayHurtEffect1 = false;
	}
	// Use this for initialization
	void Start ()
	{
		this.Health = MaxHealth;
		//Time.timeScale = 0;
		this.displayHurtEffect = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (photonView.isMine)
		{
			hpBarLength = this.Health*2f;
		
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
			if(this.Health <= 0)
			{
				Player1.transform.position = new Vector3(0.5f, -0.5f, 0);
				this.Health = 100;
			}
			if(displayHurtEffect == true || displayHurtEffect1 == true)
			{
				StartCoroutine(StopDisplayingEffect());
			}
		}
	}
}
