using UnityEngine;
using System.Collections;
using System.Net;
using LitJson;

public class DataUpDown : MonoBehaviour {

	public GUISkin Skin;

	private string login = "";
	private string password = "";
	private bool showErr = false;
	private string msgErr = "";

	private bool log = false;
	static private string user = "null";
	static private string access = "null";

	// Getters
	public bool getLog() { return log; }
	public string getUser() { return user; }
	public string getAccess() { return access; }

	void Start()
	{
		Screen.showCursor = true;		
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("0xyde Menu");
		}
	}

	private IEnumerator getJsonLogin(string login, string password)
	{
		// http://blog.paultondeur.com/2010/03/23/tutorial-loading-and-parsing-external-xml-and-json-files-with-unity-part-2-json/

		var data = "null";

		try
		{
			// Get json webpage on 0xyde website
			WebClient web = new WebClient();
			 data = web.DownloadString("http://0xyde.sybiload.com/json/login.php?login=" + login + "&password=" + password);
			
			// Let's check that login dude !
			checkLogin (data);
		}
		catch (WebException)
		{
			showErr = true;
			msgErr = "Erreur de connexion";
		}
		catch
		{
			showErr = true;
			msgErr = "Erreur inconnue";
		}

		yield return data;
	}

	private void checkLogin(string jsonString)
	{
		// Serialize the json string into readeable datas
		JsonData jsonData = JsonMapper.ToObject(jsonString);

		// Check if the login is successful
		log = (bool)jsonData["log"];

		if (log) 
		{
			// Get user info if login is successful
			user = (string)jsonData["user"];
			access = (string)jsonData["access"];

			Debug.Log("ok - " + user + " & " + access);

			Application.LoadLevel("alphamap");
		}
		else
		{
			Debug.Log("err");

			showErr = true;
			msgErr = "Erreur d'identification";
		}
	}

	void OnGUI()
	{
        // allow detect enter even in text area
        if (Event.current.keyCode == KeyCode.Return)
        {
            StartCoroutine(getJsonLogin(login, password));
        }

		if( Skin != null )
		{
			GUI.skin = Skin;
		}
		
		// Awesome login menu

		Rect centeredRect = new Rect(-10, (Screen.height - 220) / 2, 520, 220);

		// Absolute bullshit gui ! Must be checked again
		GUILayout.BeginArea(centeredRect, GUI.skin.box);
		{
			GUI.Label(new Rect (60, 10, 500, 40), "0xyde Network", GUI.skin.customStyles[0]);

			GUI.Label(new Rect (60, 70, 300, 24), "Login: ");
			login = GUI.TextField (new Rect (180, 70, 300, 24), login);

			GUI.Label(new Rect (60, 110, 300, 24), "Password: ");
			password = GUI.PasswordField (new Rect (180, 110, 300, 24), password, '•');

			if (GUI.Button (new Rect (340, 150, 140, 36), "Login")) 
			{
				// When pushing login button, check credentials
				StartCoroutine(getJsonLogin(login, password));
			}

			if (showErr)
			{
				// Show red error message
				GUI.contentColor = Color.red;
				GUI.Label(new Rect (60, 150, 260, 36), msgErr);
			}
		}
		GUILayout.EndArea();
	}
}
