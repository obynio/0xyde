using UnityEngine;
using System.Collections;

public class BlastKill : MonoBehaviour {

	void OnTriggerEnter (Collider c)
	{
		Debug.Log ("Trigger ?");
		Debug.Log (c);
		
		if(c.gameObject.tag == "Zombie")
		{
			GameObject go = c.collider.gameObject;
			mAI other = (mAI)go.GetComponent (typeof(mAI));
			other.hurt();
		}
		//Destroy (gameObject, 0.3f);
	}
}
