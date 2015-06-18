using UnityEngine;
using System.Collections;

public class BulletMulti : MonoBehaviour {
	public GameObject blood;
	
    // Fucking bullet move now by itself !
    void Start()
    {
        this.rigidbody.velocity = transform.TransformDirection(Vector3.left * 25);
        Destroy(this.gameObject, 2);
    }

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
