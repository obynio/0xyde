using UnityEngine;
using System.Collections;

public class ShereMode : MonoBehaviour {
	bool done = false;

	public GameObject go;
	//public GameObject fetch;


	// Use this for initialization
	void Start () 
	{

	}

	void Update ()
	{

	}

	void OnTriggerStay (Collider c)
	{

		if(c.gameObject.tag == "Player" && done == false)
		{
			ModeSelect other = (ModeSelect)go.GetComponent (typeof(ModeSelect));
			other.Set_mode();
			done = true;
		}
		//Destroy (gameObject, 0.3f);
	}
	// Update is called once per frame
	void OnTriggerExit ()
	{
		done = false;
	}
}
