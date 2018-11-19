using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginMannager : MonoBehaviour {

    public Text username;
    public Text password;
    public Text error;
    private APImannager api;

    void Start()
    {
        
    }

    public void LogIn()
    {
        SceneManager.LoadScene(1);
    }

    public void Register()
    {

    }
}
