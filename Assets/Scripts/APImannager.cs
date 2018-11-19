using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class APImannager : MonoBehaviour {

    private Info info;
    private string api = "http://127.0.0.1:8012/Spy_Game/";
    // Use this for initialization
    void Start () {
        info = GameObject.FindObjectOfType<Info>();
       StartCoroutine(getPlayerData(1));
        //var w = UnityWebRequest.Put();
        //string json = JsonConvert.SerializeObject();
	}

    public IEnumerator getPlayerData(int id)
    {
        api += id.ToString();
        WWW www = new WWW(api);
        yield return www;
        string data = www.text;
        var playerdataList = JsonConvert.DeserializeObject<List<PlayerData>>(data);
        var playerdata = playerdataList[0];
        info.playerData = playerdata;
    }
}
