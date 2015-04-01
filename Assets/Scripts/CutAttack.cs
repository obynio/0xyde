using UnityEngine;
using System.Collections;

public class CutAttack : MonoBehaviour {

	public float rpm;

	private float secondsInterval;
	private float nextShootTime;
	public bool shooted;
	public float hitdistance;
	public Transform center;
	public GameObject blood;
	public Transform blo;

	void Start()
	{
		secondsInterval = 60 / rpm;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetButtonDown ("Fire1")&& CanShoot())
		{
			StartCoroutine("ATK");
		}
	}

	IEnumerator ATK()
	{
		yield return new WaitForSeconds(0.2f);
		RaycastHit hit;
		Ray ray = new Ray(center.position, transform.forward);
		//Debug.DrawLine(transform.position, out hit, Color.red);
		if(Physics.Raycast(ray, out hit))
		{
			if (hit.collider.tag == "Zombie")
			{
				hitdistance = hit.distance;
				//Debug.DrawLine (center.position, hit.point, Color.cyan);
				if(hit.distance < 2.5f)
				{
					Debug.Log("Working bitch");
					GameObject go = hit.collider.gameObject;
					mAI other = (mAI)go.GetComponent (typeof(mAI));
					other.hurt();
					Instantiate (blood, blo.transform.position, blo.transform.rotation);
					
					
					nextShootTime = Time.time + secondsInterval;
					shooted = true;
				}
				else
				{
					shooted = false;
				}
			}
			else
			{
				shooted = false;
			}
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
