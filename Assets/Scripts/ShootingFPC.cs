using UnityEngine;
using System.Collections;

 [RequireComponent (typeof (AudioSource))]
public class ShootingFPC : MonoBehaviour
{
	public float rpm;

	private float secondsInterval;
	private float nextShootTime;
	public bool shooted;
	

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
			
			Destroy (clone.gameObject, 2);
			shooted = true;
		}
		else
		{
			shooted = false;
		}
	}

	private bool CanShoot()
	{
		bool canShoot = true;
		
		if(Time.time < nextShootTime)
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