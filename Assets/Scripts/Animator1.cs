using UnityEngine;
using System.Collections;

public class Animator1 : MonoBehaviour
{
	public GameObject game;
	//protected Animator animator;
	
	void Start () 
	{
		//animator = this.GetComponent<Animator>();;
		animation["Shoot"].wrapMode = WrapMode.Once;
		animation["Shoot"].layer = 1;
	}
	
	void Update ()
	{
		ShootingFPC shootingFPC = game.GetComponent<ShootingFPC>();

		if (shootingFPC.shooted)
		{
			animation.CrossFade("Shoot", 0.1f);
		}
		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			animation.CrossFade("Walk", 0.1f);
		}
		else
		{
			animation.CrossFade("Idle");
		}
	}
}