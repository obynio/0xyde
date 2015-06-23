using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Commandes : MonoBehaviour {
	
	public GameObject go;
	// Use this for initialization
	void Start () {
		go.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.renderer.enabled = !JouerSimple.anglais;
		transform.collider.enabled = !JouerSimple.anglais;
	}
	
	void OnMouseEnter()
	{
		transform.localScale *= 1.1f;
	}
	
	void OnMouseExit()
	{
		transform.localScale *= 0.909090f;
	}
	
	void OnMouseUp()
	{
		go.SetActive (!go.GetActive ());
	}
}
