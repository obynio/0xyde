using UnityEngine;
using System.Collections;

public class EndLevel1 : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider c)
	{
		
		if(c.gameObject == player1 || c.gameObject == player2)
		{
			Application.LoadLevel("0xyde lvl fantom town");
		}
	}
}
