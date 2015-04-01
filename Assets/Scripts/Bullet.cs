using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public GameObject blood;
	

	void OnCollisionEnter(Collision c)
	{
		rigidbody.isKinematic = true;
		renderer.enabled = false;


		if (c.collider.gameObject.CompareTag("Zombie"))
		{
			GameObject go = c.collider.gameObject;
			mAI other = (mAI)go.GetComponent (typeof(mAI));
			other.hurt();
			Instantiate (blood, transform.position, transform.rotation);
		}
		Destroy (gameObject, 0.3f);
	}
}
