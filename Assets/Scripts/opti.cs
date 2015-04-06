using UnityEngine;
using System.Collections;

public class opti : MonoBehaviour {
	void Start()
	{
		JouerSimple.anglais = true;
	}
	void Update () {
		transform.renderer.enabled = !JouerSimple.anglais;	
		transform.collider.enabled = !JouerSimple.anglais;
	}
}
