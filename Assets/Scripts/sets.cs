using UnityEngine;
using System.Collections;

public class sets : MonoBehaviour {
	

	void Start()
	{
		JouerSimple.anglais = true;
	}
	void Update () {
		transform.renderer.enabled = JouerSimple.anglais;
		transform.collider.enabled = JouerSimple.anglais;
	}
}
