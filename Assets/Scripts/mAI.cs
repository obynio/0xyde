using UnityEngine;
using System.Collections;

public class mAI : MonoBehaviour {

	public Transform leader;
	private Transform Rot;
	public float maxDistance = 7;
	public float minDistance = 3;
	private Animator anim;
	private float attackRepeatTime = 1;
	private float attackTime = 1;
	public Renderer eyes;
	public bool kick;
	public bool firstATK;

	

	//private SphereCollider col;
	public float fieldOfViewAngle = 110f;
	private bool playerDetected = false;
	private GameObject player2;
	
	private GameObject Health;

	private int life = 1;


	// Use this for initialization
	void Start () 
	{
		Health = GameObject.Find("_Game");
		firstATK = false;
		kick = false;
		anim = GetComponent<Animator> ();
		//col = GetComponent<SphereCollider> ();
		attackTime = Time.time;
		Rot = leader;
	}

	IEnumerator KickT()
	{
		yield return new WaitForSeconds(0.1f);
		kick = true;
		yield return new WaitForSeconds(0.25f);
		kick = false;
	}

	public void Kick()
	{
		StartCoroutine(KickT());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (kick)
		{
			float translation = Time.deltaTime * -10;
			transform.Translate(0, 0, translation);
		}

		player2 = GameObject.FindGameObjectWithTag("Player");
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
				firstATK = false;
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
	/// </summary>qqqq
	private void walk()
	{
		// Initiate NavMesh agent
		GetComponent<NavMeshAgent> ().destination = leader.position;

		// Start walk motion
		anim.SetBool ("attack", false);
		anim.SetBool ("walk", true);
		GetComponent<NavMeshAgent> ().Resume ();
		
	}

	/// <summary>
	/// Attack behaviour function
	/// </summary>
	private void attack()
	{
		Quaternion targetRotation = Quaternion.LookRotation(leader.transform.position - transform.position);
		targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
		if (Time.time > attackTime)
		{
			//Stop NavMesh agent
			//transform.LookAt(leader);
			//Start attack motion
			GetComponent<NavMeshAgent> ().Stop();
			anim.SetBool ("attack", true);
			if (firstATK)
			{
				try
				{
					PlayerStats other = (PlayerStats)Health.GetComponent (typeof(PlayerStats));
					other.ApplyDamage(20);
				}
				catch
				{
					PlayerStatsVR other = (PlayerStatsVR)Health.GetComponent (typeof(PlayerStatsVR));
					other.ApplyDamage(20);
				}
			}

			attackTime = Time.time + attackRepeatTime;
			firstATK = true;
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
		try
		{
			GetComponent<NavMeshAgent> ().Stop();
		}
		catch {}

		// Start dead motion
		anim.SetBool ("alive", false);
		(gameObject.GetComponent(typeof(CapsuleCollider)) as CapsuleCollider).isTrigger = true;
		eyes.enabled = false;
		//GetComponent<NavMeshAgent> ().enabled = false;
		Destroy(gameObject.GetComponent<NavMeshAgent> ());
		//down zombies nb
	}

	void OnTriggerEnter (Collider c)
	{
		if (c.tag == "Player") 
		{

		}
	}

	void OnTriggerStay (Collider other)
	{
		// If the player has entered the trigger sphere...
		if(other.gameObject == player2)
		{

			Vector3 direction = player2.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);

			if(angle < fieldOfViewAngle * 0.5f )
			{
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
			try
			{
				GetComponent<NavMeshAgent> ().ResetPath();
			}
			catch {}
			anim.SetBool ("walk", false);

		}
	}

}
