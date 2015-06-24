using UnityEngine;
using System.Collections;

public class Click_de_la_vie : MonoBehaviour {

	public GameObject go;
	// Use this for initialization
	void Start () {
		go.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp () {
		go.SetActive (!go.GetActive ());
		}
}
