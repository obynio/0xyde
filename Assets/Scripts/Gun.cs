using UnityEngine;
using System.Collections;

 [RequireComponent (typeof (AudioSource))]
public class Gun : MonoBehaviour {

	public float rpm;
	public GameObject blood;

	//composentes
	public Transform spawn;
	public Transform smokespawn;
	private LineRenderer tracer;
	public GameObject smoke;


	private float secondsInterval;
	private float nextShootTime;
	
	void Start()
	{
		secondsInterval = 60 / rpm;
		tracer = GetComponent<LineRenderer>();
	}
	
	public void Shoot()
	{
		if(CanShoot() && !Pause.pause)
		{
			Ray ray = new Ray(spawn.position,spawn.forward);
			RaycastHit hit;
			Instantiate (smoke, smokespawn.transform.position, spawn.transform.rotation);
			float shotDistance = 20;

			if (Physics.Raycast(ray,out hit, shotDistance))
			{
				shotDistance = hit.distance;
				
				if (hit.collider.tag == "Zombie")
				{
					GameObject go = hit.collider.gameObject;
					mAI other = (mAI)go.GetComponent (typeof(mAI));
					other.hurt();
					Instantiate (blood, hit.transform.position, transform.rotation);
				}
			}

			nextShootTime = Time.time + secondsInterval;

			audio.Play();

			StartCoroutine("RenderTracer", ray.direction * shotDistance);
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

	IEnumerator RenderTracer(Vector3 hitPoint)
	{
		tracer.enabled = true;
		tracer.SetPosition(0,spawn.position);
		tracer.SetPosition(1,spawn.position + hitPoint);
		
		yield return new WaitForSeconds(0.05f);
		tracer.enabled = false;
	}
}
