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
		Debug.Log ("working");
		
		if(c.gameObject == player)
		{
			audio.Play();
			ShootingFPC other = (ShootingFPC)go.GetComponent (typeof(ShootingFPC));
			other.AddAmmo(addAmmo);
			
			Destroy (gameObject, 0.3f);
		}
	}
}
