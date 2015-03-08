using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {

	public GameObject Weapon01;
	public GameObject Weapon02;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Switch"))
		{
			SwapWeapons();
		}
	}

	void SwapWeapons()
	{
		if (Weapon01.activeSelf == true)
		{
			Weapon01.SetActive(false);
			Weapon02.SetActive(true);
			Animator1 other = (Animator1)Weapon02.GetComponent (typeof(Animator1));
			other.StartAnim();
		}
		else 
		{
			Weapon01.SetActive(true);
			Weapon02.SetActive(false);
			AnimCut other = (AnimCut)Weapon01.GetComponent (typeof(AnimCut));
			other.StartAnim();
		}
	}
}
