using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour 
{
    static ArrayList playerStats;

	// Use this for initialization
	void Start () 
    {
	     playerStats = new ArrayList();
	}

    public static void playerConnected(string playerName)
    {
        Stats currentPlayerStats = null;

        // search player in list
        foreach (Stats stat in playerStats)
        {
            if (stat.getPlayerName().Equals(playerName))
            {
                currentPlayerStats = stat;
                break;
            }
        }

        // in case the player is not in the list
        if (currentPlayerStats == null)
        {
            currentPlayerStats = new Stats(playerName);
            playerStats.Add(currentPlayerStats);
        }
    }

    public static void incrementZombieKilled(string playerName)
    {
        Stats currentPlayerStats = null;

        // search player in list
        foreach (Stats stat in playerStats)
        {
            if (stat.getPlayerName().Equals(playerName))
            {
                currentPlayerStats = stat;
                break;
            }
        }

        Debug.Log(playerStats.Count);

        // increment stats
        currentPlayerStats.incrementZombieKilled();

        
    }

    public static int getZombieKilled(string playerName)
    {
        Stats currentPlayerStats = null;

        // search player in list
        foreach (Stats stat in playerStats)
        {
            if (stat.getPlayerName().Equals(playerName))
            {
                currentPlayerStats = stat;
                break;
            }
        }

        return currentPlayerStats.getZombieKilled();
    }
}
