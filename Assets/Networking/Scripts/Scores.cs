using UnityEngine;
using System.Collections;
using System.Net;
using LitJson;

public class Scores : MonoBehaviour 
{
    private static int enemy;
    private static int death;
    private static int shoot;
    private static int snap;

    // gamePlayed

	// Use this for initialization
	void Start () 
    {
        enemy = 0;
        death = 0;
        shoot = 0;
        snap = 0;
	}

    public static void incScoreEnemy()
    {
        enemy++;
        Debug.Log("enemy");
    }
    public static void incScoreDeath()
    {
        death++;
        Debug.Log("death");
    }

    public static void incScoreShoot()
    {
        shoot++;
        Debug.Log("shoot");
    }

    public static void incScoreSnap()
    {
        snap++;
        Debug.Log("snap");
    }

    void OnApplicationQuit()
    {
        GameObject.Find("Scores").GetComponent<Scores>().StartCoroutine(sendInfo());
    }

    public static IEnumerator sendInfo()
    {
        var data = "null";

        try
        {
            // Get json webpage on 0xyde website
            WebClient web = new WebClient();
            data = web.DownloadString("http://0xyde.sybiload.com/json/score.php?login=" + DataUpDown.getUser() + "&enemy=" + enemy + "&death=" + death + "&shoot=" + shoot + "&snap=" + snap);

            // Let's check that result
            checkResult(data);
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
