using UnityEngine;
using System.Collections;

 [RequireComponent (typeof (AudioSource))]
public class ShootingFPC : MonoBehaviour
{
	public float rpm;
	public int ammo;

	private float secondsInterval;
	private float nextShootTime;
	public bool shooted;
	public GUISkin theSkin;
	

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
			Rigidbody clone = Instantiate(theBullet, spawn.transform.position, turner.transform.rotation) as Rigidbody;
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

	void OnGUI()
	{
		GUI.skin = theSkin;
		GUI.Box(new Rect(11 * (Screen.width/12) -40, 11 *(Screen.height/12), 100, 55),  " " + ammo.ToString());
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