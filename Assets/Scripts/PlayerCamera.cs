using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
	
	public Vector3 cameraTarget;
	public Transform target;

	void Start ()
	{
		//recupération de la position de Player
		target = GameObject.FindGameObjectWithTag("Player").transform;
		
	}

	void Update ()
	{
		//suivi du joueur par la caméra
		cameraTarget = new Vector3 (target.position.x, transform.position.y, target.position.z);
		transform.position = Vector3.Lerp(transform.position,cameraTarget,Time.deltaTime * 8);
	}
}
