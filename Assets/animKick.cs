using UnityEngine;
using System.Collections;

public class animKick : MonoBehaviour {
	
	public Transform center;
	public float hitdistance;

	void Start ()
	{
		animation["Kick"].wrapMode = WrapMode.Once;
		animation["Kick"].layer = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetButtonDown ("Kick")&& !animation.IsPlaying("Kick"))
		{
			animation.CrossFade("Kick");
			RaycastHit hit;
			Ray ray = new Ray(center.position, center.transform.forward);
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
						other.Kick();
					}
				}
			}
		}
	}
}
