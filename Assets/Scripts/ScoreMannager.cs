using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMannager : MonoBehaviour {

    public GameMannager gm;
    public Info info;
    public List<string> names;
    public List<int> score;
    private static ScoreMannager scoreMannager;

    private void Awake()
    {
        if (scoreMannager == null)
        {
            DontDestroyOnLoad(this);
            scoreMannager = this;
        }
        else DestroyObject(gameObject);
    }

    // Use this for initialization
    void Start () {
        names = info.TakeNames();

        for (int i = 0; i < names.Count; i++)
        {
            int j = 0;
            score.Add(j);
        }
    }
	
    public void addPoints(int nr, int pt)
    {
        Debug.Log(names[nr] + " " + pt);
        score[nr] += pt;
    }

    public void reset()
    {
        gm = FindObjectOfType<GameMannager>();
        bool isReset = true;
        // if it is already reset it's not going to try to reset again
        for (int i = 0; i < score.Count; i++)
            if (score[i] != 0) isReset = false;
        if (isReset) return;
        
        for (int i = 0; i < score.Count; i++)
            score[i] = 0;
        gm.POPend.remove();
        gm.Scores();
    }
}
