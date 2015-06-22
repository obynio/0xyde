using UnityEngine;
using System.Collections;
using System.Net;
using LitJson;

public class Scores : MonoBehaviour 
{
    private static int kill;
    private static int die;
    private static int shoot;
    private static int bite;

    enum scr { kill, die, shoot, bite };

    // gamePlayed

	// Use this for initialization
	void Start () 
    {
        kill = 0;
        die = 0;
        shoot = 0;
        bite = 0;
	}

    public static void incScoreKill()
    {
        kill++;
        //GameObject.Find("Scores").GetComponent<Scores>().StartCoroutine(sendInfo(scr.kill));
        Debug.Log("kill");
    }
    public static void incScoreDie()
    {
        die++;
        //GameObject.Find("Scores").GetComponent<Scores>().StartCoroutine(sendInfo(scr.die));
        Debug.Log("die");
    }

    public static void incScoreShoot()
    {
        shoot++;
        //GameObject.Find("Scores").GetComponent<Scores>().StartCoroutine(sendInfo(scr.shoot));
        Debug.Log("shoot");
    }

    public static void incScoreBite()
    {
        bite++;
        //GameObject.Find("Scores").GetComponent<Scores>().StartCoroutine(sendInfo(scr.bite));
        Debug.Log("bite");
    }

    private static IEnumerator sendInfo(scr type)
    {
        var data = "null";

        try
        {
            // Get json webpage on 0xyde website
            WebClient web = new WebClient();

            if (type == scr.kill)
                data = web.DownloadString("http://0xyde.sybiload.com/json/stats.php?login=" + DataUpDown.getUser() + "&kill");
            else if (type == scr.die)
                data = web.DownloadString("http://0xyde.sybiload.com/json/stats.php?login=" + DataUpDown.getUser() + "&die");
            else if (type == scr.shoot)
                data = web.DownloadString("http://0xyde.sybiload.com/json/stats.php?login=" + DataUpDown.getUser() + "&shoot");
            else if (type == scr.bite)
                data = web.DownloadString("http://0xyde.sybiload.com/json/stats.php?login=" + DataUpDown.getUser() + "&bite");

            // Let's check that result
            //checkResult(data);
        }
        catch
        {
            Debug.LogWarning("database exception : unable to connect");
        }

        yield return data;
    }

    private static void checkResult(string jsonString)
    {
        // Serialize the json string into readeable datas
        JsonData jsonData = JsonMapper.ToObject(jsonString);

        // Check if the login is successful
        bool log = (bool)jsonData["log"];

        if (!log)
        {
            Debug.LogWarning("database exception : no such user");
        }
    }
}
