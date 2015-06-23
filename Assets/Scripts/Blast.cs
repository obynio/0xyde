using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {

	// Use this for initialization
	public float rpm;
	
	//composentes
	public Transform spawn;
	public Transform spawnBL;
	
	private LineRenderer tracer;
	public GameObject blast;
	
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
			//Ray ray = new Ray(new Vector3(spawn.position.x + 0.7f, spawn.position.y, spawn.position.z),spawn.forward);
			
			//RaycastHit hit;

			Instantiate (blast, spawnBL.transform.position, spawn.transform.rotation);
			
			/*float shotDistance = 5;
			
			if (Physics.Raycast(ray,out hit, shotDistance))
			{
				shotDistance = hit.distance;
				if (hit.collider.tag == "Zombie")
				{
					Debug.Log("Working bitch");
					GameObject go = hit.collider.gameObject;
					mAI other = (mAI)go.GetComponent (typeof(mAI));
					other.hurt();
				}
			}*/
			
			nextShootTime = Time.time + secondsInterval;
			
			//audio.Play();
			
			//StartCoroutine("RenderTracer", ray.direction * shotDistance);
			
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
