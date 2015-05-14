using UnityEngine;
using System.Collections;

public class GrabDrop : MonoBehaviour {
	
	GameObject grabbedObject;
	float grabbedOjectSize;

	GameObject GetMouseHoverObject(float range)
	{
		Vector3 position = gameObject.transform.position;
		RaycastHit ray;
		Vector3 target = position + Camera.main.transform.forward * range;
		if (Physics.Linecast (position, target, out ray))
			return ray.collider.gameObject;
		return null;
	}

	void TryGradObject (GameObject grabOject)
	{
		if (grabOject == null || grabOject.tag != "Shard" || !Cangrab(grabOject))
			return;

		grabbedObject = grabOject;
		grabbedOjectSize = grabOject.renderer.bounds.size.magnitude;

	}

	bool Cangrab (GameObject candidate)
	{
		return (candidate.GetComponent<Rigidbody> () != null);
	}

	void DropObject()
	{
		if (grabbedObject == null)
			return;
		if (grabbedObject.GetComponent<Rigidbody> () != null)
		{
			Vector3 newPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y +0.7f, gameObject.transform.position.z) + Camera.main.transform.forward * grabbedOjectSize * 1.2f;
			grabbedObject.transform.position = newPosition;
			grabbedObject.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0.2f, 0);
		}
		grabbedObject = null;
	}

	void Update ()
	{
		//Debug.Log (GetMouseHoverObject (5));
		if (Input.GetButton ("Grab"))
			TryGradObject (GetMouseHoverObject (5));
		else
			DropObject ();

		if (grabbedObject != null)
		{
			Vector3 newPosition = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y +0.7f, gameObject.transform.position.z) + Camera.main.transform.forward * grabbedOjectSize * 1.2f;
			grabbedObject.transform.position = newPosition;
		}
	}
}
