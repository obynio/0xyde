using UnityEngine;
using System.Collections;

public class mAIboss : MonoBehaviour {
	
	public Transform leader;
	public Transform Rot;
	public float maxDistance = 8;
	public float minDistance = 3;
	private Animator anim;
	private float attackRepeatTime = 1;
	private float attackTime = 1;
	public Renderer eyes;
	public bool kick;
	
	
	//private SphereCollider col;
	public float fieldOfViewAngle = 110f;
	private bool playerDetected = false;
	private GameObject player2;
	
	public GameObject player;
	
	private int life = 200;
	
	
	// Use this for initialization
	void Start () 
	{
		kick = false;
		anim = GetComponent<Animator> ();
		//col = GetComponent<SphereCollider> ();
		attackTime = Time.time;
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
				if (playerDetected)
				{
					walk();
				}
			}
			else
			{
				Quaternion targetRotation = Quaternion.LookRotation(leader.transform.position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 3f * Time.deltaTime);
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
		if (Time.time > attackTime)
		{
			//Stop NavMesh agent
			//transform.LookAt(leader);
			//Start attack motion
			GetComponent<NavMeshAgent> ().Stop();
			anim.SetBool ("attack", true);
			
			PlayerStats other = (PlayerStats)player.GetComponent (typeof(PlayerStats));
			other.ApplyDamage(10);
			
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
		GetComponent<NavMeshAgent> ().Stop();
		
		// Start dead motion
		anim.SetBool ("alive", false);
		(gameObject.GetComponent(typeof(CapsuleCollider)) as CapsuleCollider).isTrigger = true;
		eyes.enabled = false;

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
			
			if(angle < fieldOfViewAngle * 0.5f)
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
			GetComponent<NavMeshAgent> ().ResetPath();
			anim.SetBool ("walk", false);

		}
	}
	
}
