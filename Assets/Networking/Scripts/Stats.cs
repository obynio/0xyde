using UnityEngine;
using System.Collections;

public class Stats
{
    private string playerName;
    private int zombieKilled = 0;

    public Stats (string playerName)
    {
        this.playerName = playerName;
    }

    public string getPlayerName()
    {
        return playerName;
    }

    public void incrementZombieKilled()
    {
        this.zombieKilled++;
    }

    public int getZombieKilled()
    {
        return zombieKilled;
    }
}
