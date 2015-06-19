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
		animation["Start"].wrapMode = WrapMode.Once;
		animation["Shoot"].layer = 1;
		animation["Start"].layer = 2;

	}
	
	void Update ()
	{
		try
		{
			ShootingFPC shootingFPC = game.GetComponent<ShootingFPC>();
			if (shootingFPC.shooted && !animation.IsPlaying("Start"))
			{
				animation.CrossFade("Shoot", 0.1f);
			}
		}
		catch
		{
			try
			{
				ShootingFPCVR shootingFPC = game.GetComponent<ShootingFPCVR>();
				if (shootingFPC.shooted && !animation.IsPlaying("Start"))
				{
					animation.CrossFade("Shoot", 0.1f);
				}
			}
			catch
			{
				ShootingMulti shootingFPC = game.GetComponent<ShootingMulti>();
				if (shootingFPC.shooted && !animation.IsPlaying("Start"))
				{
					animation.CrossFade("Shoot", 0.1f);
				}
			}
			
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

	public void StartAnim()
	{
		animation.CrossFade("Start", 0f);
	}
}