using UnityEngine;
using System.Collections;

public class Animator0 : MonoBehaviour {

	protected Animator animator;

	void Start () 
	{
		animator = this.GetComponent<Animator>();;
	}

	void Update ()
	{
		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			animator.SetBool("Run", true);
		}
		else
		{
			animator.SetBool("Run", false);
		}

		if (Input.GetButtonDown ("Fire1"))
		{
			animator.SetBool("Shoot", true);
		}
		else
		{
			animator.SetBool("Shoot", false);
		}
	}
}