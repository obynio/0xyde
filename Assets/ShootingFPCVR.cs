using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class ShootingFPCVR : MonoBehaviour
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

	public Text txt;

	
	
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
			Instantiate (smoke, turner.transform.position, spawn.transform.rotation);
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
		if (ammo < 10)
				txt.text = "0" + ammo.ToString();		//WARNING : EXPLICIT CONTENT
		else
				txt.text = ammo.ToString ();
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