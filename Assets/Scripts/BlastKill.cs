using UnityEngine;
using System.Collections;

public class BlastKill : MonoBehaviour {
	public Transform Prefab;
	
	void OnTriggerEnter (Collider coll)
	{
		if (coll.name == "Zombie" && coll.GetType() == typeof(CapsuleCollider))
		{
			GameObject go = coll.collider.gameObject;
			mAI other = (mAI)go.GetComponent (typeof(mAI));
			other.hurt();
		}
		//Destroy (gameObject, 0.3f);
	}
}
