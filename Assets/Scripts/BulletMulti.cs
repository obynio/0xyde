using UnityEngine;
using System.Collections;

public class BulletMulti : MonoBehaviour {
	public GameObject blood;
	

	void OnCollisionEnter(Collision c)
	{
		rigidbody.isKinematic = true;
		renderer.enabled = false;


		if (c.collider.gameObject.CompareTag("Zombie"))
		{
			GameObject go = c.collider.gameObject;
			mAIMulti other = (mAIMulti)go.GetComponent (typeof(mAIMulti));
			other.hurt();
			Instantiate (blood, transform.position, transform.rotation);
		}
		Destroy (gameObject, 0.3f);
	}
}
