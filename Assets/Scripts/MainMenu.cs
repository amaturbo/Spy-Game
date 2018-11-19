using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour {

    public GameObject settings;
    public Slider slider;
    public Text sliderText;
    public Text sliderInputText;
    public Text errorText;

    public void Start()
    {
        settings.SetActive(false);
    }

    public void Update()
    {
        sliderText.text = slider.value.ToString();
    }

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        settings.SetActive(true);
        slider.value = PlayerPrefs.GetInt("ImageCount");
    }

    public void Save()
    {
        PlayerPrefs.SetInt("ImageCount", (int)slider.value);
        PlayerPrefs.SetInt("Music", 0);
        
        settings.SetActive(false);
    }

    public void reset()
    {
        slider.value = 8;
    }

    public void onInput()
    {
        int x = 0;
        if (int.TryParse(sliderInputText.text, out x))
            if (x < 2 || x > 20)
                errorText.text = "Value must be between 2 and 20";
            else
            {
                slider.value = x;
                errorText.text = "";
            }
    }
}
