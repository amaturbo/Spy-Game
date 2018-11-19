using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateClick : MonoBehaviour {

    public int id;
    public GameMannager gm;
    public ScoreMannager sm;
    int current;
    int spy;

    int SpyPoints = 1;
    int Points = 3;

    List<string> temp = new List<string>();

    void Start()
    {
        sm = FindObjectOfType<ScoreMannager>();
        current = gm.current;
        spy = gm.spy;
    }

    public void populate(int nr, List<string> hints)
    {
        List<int> ids = new List<int>();
        for (int i = 0; i < hints.Count; i++)
        {
            ids.Add(i);
            temp.Add(hints[i]);
        }

        int r = Random.Range(0, hints.Count);
        gameObject.GetComponentInChildren<Text>().text = hints[r];
        temp.RemoveAt(r);
        ids.RemoveAt(r);
        id = r;
        for (int i = 1; i < nr; i++)
        {
            r = Random.Range(0, temp.Count);

            GameObject go = Instantiate(gameObject, transform.parent) as GameObject;
            go.GetComponentInChildren<Text>().text = temp[r];
            go.GetComponent<PopulateClick>().id = ids[r];
            temp.RemoveAt(r);
            ids.RemoveAt(r);
        }
    }

    public void OnClick()
    {
        Debug.Log("id " + id + " current" + current + " gm.current " + gm.current + " spy " + spy + " gm.spy " + gm.spy);
        if (id == gm.spy)
            sm.addPoints(gm.cnt, Points);
        else
            sm.addPoints(gm.spy, SpyPoints);
        gm.Turn();
    }
}
