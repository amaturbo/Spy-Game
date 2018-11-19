using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    public Info info;
    public Text text;
    public Text maintext;
    int i;

    private void Start()
    {
        i = 0;
    }

    public void play()
    {
        bool successfullyParsed = int.TryParse(text.text, out i);
        if (successfullyParsed && i > 2)
        {
            info.PlayerCount(i);
            SceneManager.LoadScene(3);
        }
        else
        {
            maintext.text = "Bad number / not a number";
        }
    }
}
