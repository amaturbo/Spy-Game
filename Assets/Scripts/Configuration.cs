using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Configuration : MonoBehaviour {
    public Info info;
    int i;
    public Text mainText;
    public InputField addText;
    bool added;

	// Use this for initialization
	void Start () {
        i = 1;
        mainText.text = "Enter the name of the player "+ i;
        added = false;
	}
	
	public void next()
    {
        if (i < info.TakeCount() && added)
        {
            info.AddName(addText.text);
            addText.text = "";
            i++;
            mainText.text = "Enter the name of the player " + i;
            added = false;
        }
        else if(i == info.TakeCount() && added)
        {
            info.AddName(addText.text);
            i++;
            added = false;
            SceneManager.LoadScene(4, LoadSceneMode.Single);
        }
    }

    public void Added()
    {
        added = true;
    }

    /*Main textas sako enter pirmo zmogaus varda po to cikliskai keicia i antro t.t. imput fieldas paima reiksme paspaudus next issitrina reiksme pasikeicia main textas pasidaro loopas*/
}
