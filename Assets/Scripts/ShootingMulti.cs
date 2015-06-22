using UnityEngine;
using System.Collections;

 [RequireComponent (typeof (AudioSource))]
public class ShootingMulti : MonoBehaviour
{
	public float rpm;
	public int ammo;

	private float secondsInterval;
	private float nextShootTime;
	public bool shooted;
	public GUISkin theSkin;
	
	public GameObject smoke;
	public Rigidbody theBullet;
	public int speed;
	public Transform spawn;
	public Transform turner;
	

	void Start()
	{
		secondsInterval = 60 / rpm;
	}
	void Update ()
	{
		if (Input.GetButtonDown ("Fire1") && CanShoot())
		{
			Debug.Log("test");
			audio.Play();

            // Awesome, no need RPC neither to sync pos as the fucking bullet move itself !
            GameObject bull = PhotonNetwork.Instantiate("45_Bullet", spawn.transform.position, turner.transform.rotation, 0);
            bull.SendMessage("setShooter", DataUpDown.getUser());

			PhotonNetwork.Instantiate("smoke04", turner.transform.position, spawn.transform.rotation, 0);

            nextShootTime = Time.time + secondsInterval;
            ammo = ammo - 1;
            shooted = true;

            // score system
            Scores.incScoreShoot();
		}
		else
		{
			shooted = false;
		}
	}

	void OnGUI()
	{
		GUI.skin = theSkin;
		if (ammo < 10)
			GUI.Box(new Rect(20 * (Screen.width/21) -40, Screen.height - 63, 100, 55),  " " + "0" + ammo.ToString());
		else	
			GUI.Box(new Rect(20 * (Screen.width/21) -40, Screen.height - 63, 100, 55),  " " + ammo.ToString());
	}

	public void AddAmmo(int n)
	{
		ammo += n;
	}

	private bool CanShoot()
	{
		bool canShoot = true;
		
		if(Time.time < nextShootTime || ammo==0)
		{
			canShoot = false;
		}
		else
		{
			canShoot = true;
		}
		
		return canShoot;
	}
}