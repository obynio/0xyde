using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

	public Renderer muzzleFlash;
	public Light muzzleLight;

	void Start ()
	{
		muzzleFlash.enabled = false;
		muzzleLight.enabled = false;
	}


	void Update ()
	{
		GameObject game = GameObject.Find("Spawn1");
		try
		{
			ShootingFPC shootingFPC = game.GetComponent<ShootingFPC>();
			if (shootingFPC.shooted)
			{
				StartCoroutine(Muzzle());
			}
		}
		catch
		{
			ShootingFPCVR shootingFPC = game.GetComponent<ShootingFPCVR>();
			if (shootingFPC.shooted)
			{
				StartCoroutine(Muzzle());
			}
		}


	}

	IEnumerator Muzzle ()
	{
		muzzleFlash.renderer.enabled = true;
		muzzleLight.enabled = true;
		yield return new WaitForSeconds (0.04f);
		muzzleFlash.renderer.enabled = false;
		muzzleLight.enabled = false;
	}
}
