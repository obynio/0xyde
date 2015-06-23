using UnityEngine;
using System.Collections;

public class AnimCut : MonoBehaviour {
	

	void Start () 
	{
		//animator = this.GetComponent<Animator>();;
		animation["BayonetAttack"].wrapMode = WrapMode.Once;
		animation["BayonetStart"].wrapMode = WrapMode.Once;
		animation["BayonetAttack"].layer = 1;
		animation["BayonetStart"].layer = 2;
		animation["BayonetStart"].speed = 2;
		//StartAnim();
	}
	
	void Update ()
	{
		
		if (Input.GetButtonDown ("Fire1") && !animation.IsPlaying("BayonetStart") && !Pause.pause)
		{
			animation.CrossFade("BayonetAttack", 0.1f);
		}
		if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
		{
			animation.CrossFade("BayonetWalk", 0.05f);
		}
		else
		{
			animation.CrossFade("BayonetIdle");
		}
	}
	public void StartAnim()
	{
		animation.CrossFade("BayonetStart", 0f);
	}
}
