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
			audio.Play();
			GetComponent<PhotonView>().RPC ("45_Bullet", PhotonTargets.All);
			Rigidbody clone = Shoot ();
			clone.velocity = transform.TransformDirection(Vector3.forward * speed);
			nextShootTime = Time.time + secondsInterval;

			ammo = ammo-1;
			Destroy (clone.gameObject, 2);
			shooted = true;

		}
		else
		{
			shooted = false;
		}
	}

	[RPC]
	private Rigidbody Shoot()
	{
		Rigidbody clone = Instantiate(theBullet, spawn.transform.position, turner.transform.rotation) as Rigidbody;
		//PhotonNetwork.Instantiate ("smoke", turner.transform.position, spawn.transform.rotation, 0);
		return clone;


		
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