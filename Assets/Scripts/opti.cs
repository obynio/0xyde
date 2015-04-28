using UnityEngine;
using System.Collections;

public class opti : MonoBehaviour {

	void Update () {
		transform.renderer.enabled = !JouerSimple.anglais;	
		transform.collider.enabled = !JouerSimple.anglais;
	}
}
