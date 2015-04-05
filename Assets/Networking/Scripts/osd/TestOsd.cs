using UnityEngine;
using System.Collections;

public class TestOsd : MonoBehaviour {

	public AudioClip dialogueClip;
	
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.O))
		{
			OsdManager.Instance.BeginDialogue(dialogueClip);
		}
	}
}
