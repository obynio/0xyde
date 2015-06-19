using UnityEngine;
using System.Collections;

public class MultiHide : Photon.MonoBehaviour {

	public Camera cam;
	// Use this for initialization
	void Start()
	{
        if (photonView.isMine)
        {
            // TODO
            Debug.Log("hksdjflmgihdsqgdomiudzqhsgklusqhfzqilujghgdfqgijzqgofsqeuhbd");

        }

        /*
		Show ("Player1");
		Show ("Player2");
		Show ("Player3");
		Show ("Player4");
		Show ("Player5");
		Show ("Player6");
		Show ("Player7");
		Show ("Player8");

		switch (NetworkManager.getPlayerNumber()) {
		
		case 1:
			gameObject.layer = 12;
			Hide ("Player1");
			break;
		case 2:
			gameObject.layer = 13;
			Hide ("Player2");
			break;
		case 3:
			gameObject.layer = 14;
			Hide ("Player3");
			break;
		case 4:
			gameObject.layer = 15;
			Hide ("Player4");
			break;
		case 5:
			gameObject.layer = 16;
			Hide ("Player5");
			break;
		case 6:
			gameObject.layer = 17;
			Hide ("Player6");
			break;
		case 7:
			gameObject.layer = 18;
			Hide ("Player7");
			break;
		default:
			gameObject.layer = 19;
			Hide ("Player8");
			break;
		}
         * */
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Turn on the bit using an OR operation:
	private void Show(string layer) {
		cam.cullingMask |= 1 << LayerMask.NameToLayer(layer);
	}
	
	// Turn off the bit using an AND operation with the complement of the shifted int:
	private void Hide(string layer) {
		cam.cullingMask &=  ~(1 << LayerMask.NameToLayer(layer));
	}
	
	// Toggle the bit using a XOR operation:
	private void Toggle(string layer) {
		cam.cullingMask ^= 1 << LayerMask.NameToLayer(layer);
	}
}
