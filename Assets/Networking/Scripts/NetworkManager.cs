using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    public Camera standbyCamera;
    SpawnSpot[] spots;

	void Start () 
    {
        spots = GameObject.FindObjectsOfType<SpawnSpot>();
        Connect();
	}

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings("0xyde_v01");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (spots == null)
        {
            Debug.LogError("fatal error");
            return;
        }

        SpawnSpot mySpot = spots[Random.Range(0, spots.Length)];

        GameObject dpc = PhotonNetwork.Instantiate("dpc", mySpot.transform.position, mySpot.transform.rotation, 0);
        //((MonoBehaviour)dpc.GetComponent("FPSInputController")).enabled = true;
        //((MonoBehaviour)dpc.GetComponent("MouseLook")).enabled = true;
        dpc.GetComponent<FPSInputController>().enabled = true;
        dpc.GetComponent<MouseLook>().enabled = true;

        dpc.transform.FindChild("Main Camera").gameObject.SetActive(true);

        standbyCamera.enabled = false; 
    }
}
