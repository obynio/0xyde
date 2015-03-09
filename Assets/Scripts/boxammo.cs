using UnityEngine;
using System.Collections;

public class boxammo : MonoBehaviour 
{
	public GameObject player;
	public GameObject go;
	
	// Update is called once per frame
	void OnTriggerEnter (Collider c)
	{
		Debug.Log ("working");
		
		if(c.gameObject == player)
		{
			ShootingFPC other = (ShootingFPC)go.GetComponent (typeof(ShootingFPC));
			other.AddAmmo(20);
			
			Destroy (gameObject, 0.3f);
		}
	}
}
