using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIOculus : MonoBehaviour {

	public Text txt;
	private int currentscore=0;
	
	// Use this for initialization
	void Start () {
		txt.text="Health : " + currentscore;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text="Health : " + currentscore;  
	}
}
