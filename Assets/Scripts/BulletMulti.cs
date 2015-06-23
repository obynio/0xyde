using UnityEngine;
using System.Collections;

public class BulletMulti : MonoBehaviour {
	public GameObject blood;
    private static string shooter;
	
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
			bool isDead = other.hurt();
			Instantiate (blood, transform.position, transform.rotation);

            if (isDead && shooter.Equals(DataUpDown.getUser()))
            {
                // increment kill
                Scores.incScoreEnemy();
            }
		}
		Destroy (gameObject, 0.3f);
	}

    public void setShooter(string user)
    {
        shooter = user;
    }

    public string getShooter()
    {
        return shooter;
    }
}
