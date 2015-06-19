using UnityEngine;
using System.Collections;
using System;

public class NetworkManager : MonoBehaviour {

    public Camera standbyCamera;
    public GameObject land;
    SpawnSpot[] spots;

    // For popup notifications
    private int notifId = 0;
    private int timeStamp;

    // FUCKING MONOBEHAVIOUR WARNING !
    private DataUpDown data = new DataUpDown();

    private PhotonPlayer[] playerList;
    private PhotonPlayer playerDiff;

    public GUISkin Skin;

    bool offlineMode = false;

    /// <summary>
    /// Return the number of players currently in game
    /// </summary>
    /// <returns></returns>
    public static int getPlayerNumber()
    {
        return PhotonNetwork.playerList.Length;
    }

    // Use this for initialization
    void Start()
    {
		Screen.showCursor = false;
        spots = GameObject.FindObjectsOfType<SpawnSpot>();
        ConnectToServer();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
            Application.LoadLevel("0xyde Menu");
        }
    }

    void ConnectToServer()
    {
        if (offlineMode)
        {
            PhotonNetwork.offlineMode = true;
            OnJoinedLobby();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings("0xyde_v01");
        }
    }

    // Run as client ?
    void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby");
        PhotonNetwork.JoinRandomRoom();
    }

    // When you are in a lobby and you manage to join a room
    void OnJoinedRoom()
    {
        Debug.Log("Connected to room");

        // Let's spawn you !
        PhotonNetwork.playerName = data.getUser();

        playerList = PhotonNetwork.playerList;
        SpawnPlayer();
    }

    // Run as server ?
    void OnPhotonRandomJoinFailed()
    {
        Debug.LogWarning("Can't join room");
        Debug.Log("Creating a room..");

        // GUID created if null in parameters
        PhotonNetwork.CreateRoom(null);
    }

    void OnPhotonPlayerConnected()
    {
        playerDiff = getPlayerDiff(playerList);
        Debug.Log(playerDiff + " has join the game");

        notifId = 2;
        timeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(2015, 1, 1))).TotalSeconds + 6;
    }

    void OnPhotonPlayerDisconnected()
    {
        playerDiff = getPlayerDiff(playerList);
        Debug.Log(playerDiff + " has left the game");

        notifId = 1;
        timeStamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(2015, 1, 1))).TotalSeconds + 6;
    }

    void SpawnPlayer()
    {
        Debug.Log("Spawn you..");

        if (spots == null)
        {
            Debug.LogError("fatal error");
            return;
        }

        SpawnSpot mySpot = spots[playerList.Length % 2];

        GameObject dpc = PhotonNetwork.Instantiate("dpc", mySpot.transform.position, mySpot.transform.rotation, 0);
        //((MonoBehaviour)dpc.GetComponent("FPSInputController")).enabled = true;
        //((MonoBehaviour)dpc.GetComponent("MouseLook")).enabled = true;
        dpc.GetComponent<PlayerMovement>().enabled = true;
        dpc.GetComponent<MouseLook>().enabled = true;

        dpc.transform.FindChild("Main Camera").gameObject.SetActive(true);

        standbyCamera.enabled = false; 
    }

    PhotonPlayer getPlayerDiff(PhotonPlayer[] oldPlayers)
    {
        PhotonPlayer[] newPlayers = PhotonNetwork.playerList;
        playerList = PhotonNetwork.playerList;

        if (newPlayers.Length < oldPlayers.Length)
        {
            for (int i = 0; i < newPlayers.Length; i++)
            {
                if (newPlayers[i] != oldPlayers[i])
                {
                    return oldPlayers[i];
                }
            }

            return oldPlayers[oldPlayers.Length - 1];
        }
        else if (newPlayers.Length > oldPlayers.Length)
        {
            for (int i = 0; i < oldPlayers.Length; i++)
            {
                if (oldPlayers[i] != newPlayers[i])
                {
                    return newPlayers[i];
                }
            }

            return newPlayers[newPlayers.Length - 1];
        }

        return null;
    }


    // GUI

    void OnGUI()
    {
        // Hey, time lord !
        int currentTime = (Int32)(DateTime.UtcNow.Subtract(new DateTime(2015, 1, 1))).TotalSeconds;

        if (Skin != null)
        {
            GUI.skin = Skin;
        }

        // Cool GUI ^^ ?

        if (PhotonNetwork.connectionStateDetailed != PeerState.Joined)
        {
            Rect centeredRect = new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 400, 100);

            GUILayout.BeginArea(centeredRect, GUI.skin.box);
            {
                GUILayout.Label("Connecting" + GetConnectingDots(), GUI.skin.customStyles[0]);
                GUILayout.Label("Status: " + PhotonNetwork.connectionStateDetailed);
            }
            GUILayout.EndArea();
        }

        // Cool system of notification

        if (notifId == 1 && currentTime < timeStamp)
        {
            string sentence = playerDiff.ToString().Substring(1, playerDiff.ToString().Length - 2) + " has left the game";

            Rect infoRect = new Rect(10, 10, sentence.Length * 12, 80);

            GUILayout.BeginArea(infoRect, GUI.skin.box);
            {
                GUILayout.Label("Migee", GUI.skin.customStyles[0]);
                GUILayout.Label(sentence);
            }
            GUILayout.EndArea();
        }
        else if (notifId == 2 && currentTime < timeStamp)
        {
            string sentence = playerDiff.ToString().Substring(1, playerDiff.ToString().Length - 2) + " has join the game";
            Rect infoRect = new Rect(10, 10, sentence.Length * 12, 80);

            GUILayout.BeginArea(infoRect, GUI.skin.box);
            {
                GUILayout.Label("Migee", GUI.skin.customStyles[0]);
                GUILayout.Label(sentence);
            }
            GUILayout.EndArea();
        }

        if (currentTime >= timeStamp)
        {
            notifId = 0;
        }
    }

    // Let's make cool loading dots !
    string GetConnectingDots()
    {
        string str = "";
        int numberOfDots = Mathf.FloorToInt(Time.timeSinceLevelLoad * 3f % 4);

        for (int i = 0; i < numberOfDots; ++i)
        {
            str += " .";
        }

        return str;
    }
}
