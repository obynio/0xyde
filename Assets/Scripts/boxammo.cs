using UnityEngine;
using System.Collections;

public class boxammo : MonoBehaviour 
{
	public GameObject player;
	public GameObject go;
	public int addAmmo = 10;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider c)
	{
		
		if(c.gameObject == player)
		{
			audio.Play();
			try
			{
				ShootingFPC other = (ShootingFPC)go.GetComponent (typeof(ShootingFPC));
				other.AddAmmo(addAmmo);
			}
			catch
			{
				ShootingFPCVR other = (ShootingFPCVR)go.GetComponent (typeof(ShootingFPCVR));
				other.AddAmmo(addAmmo);
			}
			
			Destroy (gameObject, 0.3f);
		}
	}
}
