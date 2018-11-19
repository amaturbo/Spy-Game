using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMannager : MonoBehaviour {
    public Info info;
    public ScoreMannager scoreMannager;
    List<string> ob = new List<string>();
    List<Sprite> pic = new List<Sprite>();
    public List<string> objects = new List<string>();
    public List<string> names = new List<string>();
    public List<string> hints = new List<string>();
    public List<Sprite> pictures = new List<Sprite>();
    public int current;
    public int spy;
    public int cnt;
    bool guessing;
    bool populated;

    public GameObject PanelNext;
    public GameObject PanelSpyGuess;
    public GameObject PanelSpyHint;
    public GameObject PanelHint;
    public GameObject PanelGuess;
    public GameObject PanelEnd;
    public GameObject PanelScore;
    public Text NextPlayer;

    public List<Image> answerImages = new List<Image>();
    public List<Image> spyImages = new List<Image>();
    public List<Image> spyImagesHint = new List<Image>();

    GameObject ActivePanel;

    public Text SpyHintText;
    public InputField HintText;
    public Text spyText;
    public Text AnswerText;
    public Text AnswerText1;

    public Populate POPspyGuess;
    public Populate POPend;
    public PopulateClick POPguess;
    public Text AnswerName;

    private List<string> message = new List<string>();
    private int imageCount;

    private void Awake()
    {
        DontDestroyOnLoad(info);
    }

    // Use this for initialization
    void Start () {
        PanelSpyGuess.SetActive(false);
        PanelSpyHint.SetActive(false);
        PanelHint.SetActive(false);
        PanelGuess.SetActive(false);
        PanelEnd.SetActive(false);
        PanelScore.SetActive(false);

        if (!PlayerPrefs.HasKey("ImageCount"))
            PlayerPrefs.SetInt("ImageCount", 8);
        imageCount = PlayerPrefs.GetInt("ImageCount");

        scoreMannager = FindObjectOfType<ScoreMannager>();
        ob = info.TakeStrings();
        pic = info.TakeSprites();
        names = info.TakeNames();
        for (int i = 0; i < imageCount; i++)
        {
            int r = Random.Range(0, ob.Count);
            objects.Add(ob[r]);
            pictures.Add(pic[r]);
            ob.RemoveAt(r);
            pic.RemoveAt(r);
        }

        current = Random.Range(0, objects.Count);
        spy = Random.Range(0, info.TakeCount());
        cnt = 0;

        for (int j = 0; j < answerImages.Count; j++)
            answerImages[j].sprite = pictures[current];
        for (int k = 0; k < imageCount; k++)
        {
            spyImages[k].sprite = pictures[k];
            spyImagesHint[k].sprite = pictures[k];
        }
        for (int k = imageCount; k < 8; k++)
        {
            spyImages[k].gameObject.SetActive(false);
            spyImagesHint[k].gameObject.SetActive(false);
        }


        NextPlayer.text = "Player " + names[cnt] + " press the button";
        guessing = false;
        populated = false;
    }
	
    public void Next()
    {
        PanelNext.SetActive(false);
        if (cnt == spy && !guessing)
        {
            PanelSpyHint.SetActive(true);
            ActivePanel = PanelSpyHint;
        }
        else if (cnt == spy && guessing)
        {
            PanelSpyGuess.SetActive(true);
            POPspyGuess.populate(info.TakeCount(), hints);
            ActivePanel = PanelSpyGuess;
        }
        else if(cnt != spy && !guessing)
        {
            PanelHint.SetActive(true);
            ActivePanel = PanelHint;
            AnswerText.text = objects[current];
        }
        else if (cnt != spy && guessing)
        {
            PanelGuess.SetActive(true);
            ActivePanel = PanelGuess;
            AnswerText1.text = "The solution was:\n" + objects[current];
            if (!populated)
            {
                POPguess.populate(info.TakeCount(), hints);
                populated = true;
            }
        }
    }

    public void Turn()
    {
        if (cnt == spy && !guessing)
        {
            takeString(SpyHintText);
            SpyHintText.text = "";
        }
        else if (cnt != spy && !guessing)
        { 
            takeString(HintText.text);
            HintText.text = "";
        }

    cnt++;
        if (cnt == names.Count && !guessing)
        {
            guessing = !guessing;
            cnt = 0;
        }
        else if ( cnt == names.Count && guessing)
        {
            cnt = 0;
            PanelEnd.SetActive(true);
            ActivePanel.SetActive(false);
            ActivePanel = PanelEnd;
            AnswerName.text += objects[current]; 
            return;
        }

        PanelNext.SetActive(true);
        ActivePanel.SetActive(false);
        NextPlayer.text = "Player " + names[cnt] + " press the button";
    }

    void takeString(Text text)
    {
        hints.Add(text.text);
    }

    void takeString(string text)
    {
        hints.Add(text);
    }

    public void Scores()
    {      
        PanelEnd.SetActive(false);
        PanelScore.SetActive(true);
        for (int i = 0; i < info.TakeCount(); i++)
        {
            message.Add(names[i]);
            message[i] += " - " + scoreMannager.score[i];
        }
        POPend.populateNotRandom(info.TakeCount(), message);
    }
   
    public void reset()
    {
        message = new List<string>();
        scoreMannager.reset();
    }
}
