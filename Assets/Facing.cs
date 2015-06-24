using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Facing : MonoBehaviour {
	public Text txt;
	public GameObject dpc;
	// Use this for initialization
	void Start ()
	{
		txt.text = dpc.GetComponent<PhotonView>().owner.name;
		//mainCam = GameObject.FindGameObjectsWithTag("Finish")[1].transform;
	}
	
	// Update is called once per frame
	void Update () {
		try
		{
			transform.LookAt(Camera.main.transform);
		}
		catch{}
	}
}
