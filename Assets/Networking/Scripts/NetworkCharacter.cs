using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

    public string playerName = null;
	public GameObject dpc;

    Animator anim;
	
    void Start()
    {
        anim = GetComponent<Animator>();
        playerName = DataUpDown.getUser();
    }
	
	void Update () 
	{
		if (!photonView.isMine)
		{
			// Smooth movement like water !
			transform.position = Vector3.Lerp(transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp(transform.rotation, realRotation, 0.1f);
		} 
	}


	void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) 
		{
			// Sending position
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
            stream.SendNext(anim.GetFloat("speed"));
		}
		else
		{
			// Receiving position
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
            anim.SetFloat("speed", (float)stream.ReceiveNext());
		}
	}
}
