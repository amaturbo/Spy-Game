using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageButton : MonoBehaviour {
    public int id;
    public GameMannager gm;
    public ScoreMannager sm;
    int current;
    int spy;

    int SpyGuessPoints = 5;
    int SpyPoints = 1;
    int Points = 3;

    // Use this for initialization
    void Start () {
        sm = FindObjectOfType<ScoreMannager>();
        current = gm.current;
        spy = gm.spy;
	}
	
	public void onClickSpy()
    {
        if (id == gm.current)
            sm.addPoints(gm.spy, SpyGuessPoints);
        gm.Turn();
    }

    public void setId(int i)
    {
        id = i;
    }
}
