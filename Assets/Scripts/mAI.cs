using UnityEngine;
using System.Collections;

public class mAI : MonoBehaviour {

	public Transform leader;
	public float maxDistance = 8;
	public float minDistance = 2;
	private Animator anim;
	private float attackRepeatTime = 1;
	private float attackTime = 1;
	public Renderer eyes;

	//private SphereCollider col;
	public float fieldOfViewAngle = 110f;
	private bool playerDetected = false;
	private GameObject player2;
	
	public GameObject player;

	private int life = 1;

	// Use this for initialization
	void Start () 
	{
		player2 = GameObject.FindGameObjectWithTag("Player");
		anim = GetComponent<Animator> ();
		//col = GetComponent<SphereCollider> ();
		attackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Freeze Y axis
		transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
		AI ();
	}

	private void AI () 
	{
		if (life > 0) 
		{
			if (Vector3.Distance (transform.position, leader.position) >= minDistance) 
			{
				if (playerDetected)
				{
					walk();
				}
			}
			else
			{
				attack();
			}
		}
	}

	/// <summary>
	/// Walk behaviour function
	/// </summary>
	private void walk()
	{
		// Initiate NavMesh agent
		GetComponent<NavMeshAgent> ().destination = leader.position;

		// Start walk motion
		anim.SetBool ("attack", false);
		anim.SetBool ("walk", true);

	}

	/// <summary>
	/// Attack behaviour function
	/// </summary>
	private void attack()
	{
		if (Time.time > attackTime)
		{
			// Stop NavMesh agent
			//transform.LookAt(leader);
			// Start attack motion
			GetComponent<NavMeshAgent> ().ResetPath();
			anim.SetBool ("attack", true);

			PlayerStats other = (PlayerStats)player.GetComponent (typeof(PlayerStats));
			other.ApplyDamage(10);

			Debug.Log("Attack");
			attackTime = Time.time + attackRepeatTime;
		}
	}

	/// <summary>
	/// Remove 1 point of life to the zombie
	/// </summary>
	public void hurt()
	{
		life--;

		if (life <= 0) 
		{
			die ();
		}
		else
		{
			Debug.Log("Hurt");
		}
	}

	/// <summary>
	/// Remove the given point of live in parameter
	/// </summary>
	/// <param name="hurtPoint">Hurt point.</param>
	public void hurt(int hurtPoint)
	{
		life -= hurtPoint;

		if (life <= 0) 
		{
			die ();
		}
		else
		{
			Debug.Log("Hurt");
		}
	}

	/// <summary>
	/// Kill the zombie
	/// </summary>
	private void die()
	{
		// Stop NavMesh agent (unless you want self-moving bodies..)
		GetComponent<NavMeshAgent> ().ResetPath();

		// Start dead motion
		anim.SetBool ("alive", false);
		(gameObject.GetComponent(typeof(CapsuleCollider)) as CapsuleCollider).isTrigger = true;
		eyes.enabled = false;
		Debug.Log("You've been targeted for termination");
	}

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player2)
		{
			Debug.Log("sight");

			Vector3 direction = player2.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f)
			{
				Debug.Log("seen");
				
				playerDetected = true;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		// If the player leaves the trigger zone...
		if(other.gameObject == player2)
		{
			// ... the player is not in sight.
			playerDetected = false;
			GetComponent<NavMeshAgent> ().ResetPath();
			anim.SetBool ("walk", false);
			Debug.Log("out");
		}
	}

}
