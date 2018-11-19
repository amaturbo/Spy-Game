using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    public static List<string> objects;
    public static List<Sprite> pictures;
    public static int playerCount;
    public static List<string> names;
    public PlayerData playerData;

    private void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        Object.DontDestroyOnLoad(gameObject);
        names = new List<string>();
        objects = new List<string>();
        pictures = new List<Sprite>();
	}

    public List<string> TakeStrings()
    {
        List<string> ob = new List<string>();
        for (int i = 0; i < objects.Count; i++)
            ob.Add(objects[i]);
        return ob;
    }

    public List<string> TakeNames()
    {
        List<string> ob = new List<string>();
        for (int i = 0; i < names.Count; i++)
            ob.Add(names[i]);
        return ob;
    }

    public List<Sprite> TakeSprites()
    {
        List<Sprite> ob = new List<Sprite>();
        for (int i = 0; i < pictures.Count; i++)
            ob.Add(pictures[i]);
        return ob;
    }

    public int TakeCount()
    {
        return playerCount;
    }

    public void AddName(string name)
    {
        names.Add(name);
    }

    public void SetUp(List<string> n, List<Sprite> s)
    {
        for (int i = 0; i < n.Count; i++)
            objects.Add(n[i]);
        for (int i = 0; i < s.Count; i++)
            pictures.Add(s[i]);
    }

    public void PlayerCount(int pc)
    {
        playerCount = pc;
    }
}
