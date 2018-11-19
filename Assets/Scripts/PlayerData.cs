using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class PlayerData : MonoBehaviour {

    [JsonProperty("ID")]
    public int ID;

    [JsonProperty("username")]
    public string username;

    [JsonProperty("password")]
    public string password;

    [JsonProperty("TotalScore")]
    public int TotalScore;

    [JsonProperty("CurrentScore")]
    public int CurrentScore;

    public PlayerData(string user, string pass, int total, int current)
    {
        username = user;
        password = pass;
        TotalScore = total;
        CurrentScore = current;
    }

    public void updateScore(int gained)
    {
        TotalScore += gained;
        CurrentScore += gained;
    }
}
