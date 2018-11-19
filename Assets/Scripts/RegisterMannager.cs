using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterMannager : MonoBehaviour {

    public Text username;
    public Text password;
    public Text password2;
    public Text errorUsername;
    public Text errorPassword;

    private APImannager api;

    void Start()
    {
        api = new APImannager();
    }

    public void RegisterComplete()
    {

    }

    public void checkUsername()
    {

    }

    public void checkPassword()
    {

    }
}
