using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Populate : MonoBehaviour {

    List<string> temp = new List<string>();
    List<GameObject> instances = new List<GameObject>();

	public void populate(int nr, List<string> hints)
    {
        for (int i = 0; i < hints.Count; i++)
            temp.Add(hints[i]);

        int r = Random.Range(0, hints.Count);
        gameObject.GetComponent<Text>().text = hints[r];
        instances.Add(gameObject);
        temp.RemoveAt(r);
        for (int i = 1; i < nr; i++)
        {
            r = Random.Range(0, temp.Count);
            GameObject go = Instantiate(gameObject, transform.parent) as GameObject;
            go.GetComponent<Text>().text = temp[r];
            instances.Add(go);
            temp.RemoveAt(r);
        }
    }

    public void populateNotRandom(int nr, List<string> message)
    {
        temp = new List<string>();
        for (int i = 0; i < message.Count; i++)
            temp.Add(message[i]);

        gameObject.GetComponent<Text>().text = message[0];
        instances.Add(gameObject);
        for (int i = 1; i < nr; i++)
        {
            GameObject go = Instantiate(gameObject, transform.parent) as GameObject;
            go.GetComponent<Text>().text = temp[i];
            instances.Add(go);
        }
    }

    public void remove()
    {
        instances[0].GetComponent<Text>().text = "";
        for (int i = 1; i < instances.Count; i++)
        {
                instances[i].SetActive(false);
        }
    }
}
