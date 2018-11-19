using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour {

	public void back()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void again()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}
