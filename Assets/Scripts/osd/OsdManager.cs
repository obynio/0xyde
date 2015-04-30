using UnityEngine;
using System.Collections;
using System.Collections.Generic; //Needed for Lists
using System.Text.RegularExpressions; //Needed for some string parsing

public class OsdManager : MonoBehaviour {
	
	private AudioClip dialogueAudio;
	private const float _RATE = 44100.0f;

	private string[] fileLines;

	//Subtitle variables
	private List<string> subtitleLines = new List<string>();

	private List<string> subtitleTimingStrings = new List<string>();
	public List<float> subtitleTimings = new List<float>();

	public List<string> subtitleText = new List<string>();

	private int nextSubtitle = 0;
	private string displaySubtitle;

    public GUISkin Skin;

	//GUI
	private GUIStyle subtitleStyle = new GUIStyle();

	//Static singleton
	public static OsdManager Instance { get; private set; }
	
	void Awake()
	{
		if(Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;

		gameObject.AddComponent<AudioSource>();
	}
	
	public void BeginDialogue (AudioClip passedClip, string langage) {
		
		dialogueAudio = passedClip;


        Debug.Log(dialogueAudio.name);


		//Reset all lists
		subtitleLines = new List<string>();
		subtitleTimingStrings = new List<string>();
		subtitleTimings = new List<float>();
        subtitleText = new List<string>();


		nextSubtitle = 0;

		//Get everything from the text file
        TextAsset temp;

        temp = Resources.Load("osd." + langage + "/" + dialogueAudio.name) as TextAsset;

        fileLines = temp.text.Split('\n');

		//Split subtitle related lines into different lists
		foreach(string line in fileLines)
		{
            subtitleLines.Add(line);
		}

		//Split out our subtitle elements
		for(int cnt = 0; cnt < subtitleLines.Count; cnt++)
		{

			string[] splitTemp = subtitleLines[cnt].Split('|');
			subtitleTimingStrings.Add(splitTemp[0]);
			subtitleTimings.Add(float.Parse(CleanTimeString(subtitleTimingStrings[cnt])));
			subtitleText.Add(splitTemp[1]);
		}

		//Set initial subtitle text
		if(subtitleText[0] != null)
		{
			displaySubtitle = subtitleText[0];
		}


		//Set and play the audio clip
		audio.clip = dialogueAudio;
		audio.Play();

	}

	//Remove all characters that are not part of the timing float
	private string CleanTimeString(string timeString)
	{

		Regex digitsOnly = new Regex(@"[^\d+(\.\d+)*$]");
		return digitsOnly.Replace(timeString, "");
	}
	
	void OnGUI () {

        //Debug.Log(dialogueAudio.name);
        //Debug.Log(audio.clip.name);

		//Make sure we are using a proper dialogueAudio file
        if (audio.isPlaying && audio.clip.name == dialogueAudio.name)
		{
            if (Skin != null)
            {
                GUI.skin = Skin;
            }

            Rect infoRect = new Rect(10, 10, 180, 50);

            GUILayout.BeginArea(infoRect, GUI.skin.box);
            {
                GUILayout.Label("Transmitting" + GetConnectingDots(), GUI.skin.customStyles[0]);
                GUILayout.Label("DECRYPT_KEY_" + RandomString(10));
               // GUILayout.Label();
            }
            GUILayout.EndArea();
            
			//Check for <break/> or negative nextSubtitle
			if((nextSubtitle > 0) && (!subtitleText[nextSubtitle - 1].Contains("<break/>")))
			{
				//Create GUI
				GUI.depth = -1001;
				subtitleStyle.fixedWidth = Screen.width/1.5f;
				subtitleStyle.wordWrap = true;
				subtitleStyle.alignment = TextAnchor.MiddleCenter;
				subtitleStyle.normal.textColor = Color.white;
				subtitleStyle.fontSize = Mathf.FloorToInt(Screen.height * 0.0225f);
				
				Vector2 size = subtitleStyle.CalcSize (new GUIContent ());
				GUI.contentColor = Color.black;
				GUI.Label(new Rect(Screen.width/2 - size.x/2 + 1, Screen.height/1.25f - size.y + 1, size.x, size.y), displaySubtitle, subtitleStyle);
				GUI.contentColor = Color.white;
				GUI.Label(new Rect(Screen.width/2 - size.x/2, Screen.height/1.25f - size.y, size.x, size.y), displaySubtitle, subtitleStyle);
			}


			//Increment nextSubtitle when we hit the associated time point
			if(nextSubtitle < subtitleText.Count)
			{
				if(audio.timeSamples/_RATE > subtitleTimings[nextSubtitle])
				{
					displaySubtitle = subtitleText[nextSubtitle];
					nextSubtitle++;
				}
			}
		}
	}

    // Let's make cool loading dots ! (copy/paste from NetworkManager.cs)
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

    

    private string RandomString(int size)
    {
        Random rng = new Random();
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_:";

        char[] buffer = new char[size];

        for (int i = 0; i < size; i++)
        {
            buffer[i] = chars[Random.Range(0, chars.Length)];
        }
        return new string(buffer);
    }

}

