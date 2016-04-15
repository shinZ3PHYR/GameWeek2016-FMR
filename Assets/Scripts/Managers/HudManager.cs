using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public delegate void CharActionParamA(string chosenOne, int buttonNb);
    public static event CharActionParamA OnArgument;

    public delegate void CharActionParam(string chosenOne);
    public static event CharActionParam OnRetour;

    public delegate void CharActionParamB();
    public static event CharActionParamB OnNext;

    public AnimationCurve scaleCurve;

    public Transform menu;
    public Image hud;
    public Text button1;
    public Text button2;
    public Text button3;
    public Text button4;
    public Text button5;
    public Text button6;

    private Vector3 hudPosition;
    private List<string> ResponsesList;
    private List<string> ArgumentsList;
    private GameObject ButtonZone;
    private GameObject ButtonZone2;
    private GameObject ButtonZone3;

	// Use this for initialization
	void Start () {
        EventManager.OnMenu += ShowMenu;
        EventManager.OnUI += ShowHud;

        DialogueManager.OnReturnResponses += NewResponses;
        DialogueManager.OnReturnArguments += NewArguments;
        DialogueManager.OnReturnAccroche += NewAccroche;
        Character.OnFinishQuestion += changeButtons;

        menu.gameObject.SetActive(false);

        hudPosition = hud.transform.position;
        hudPosition.y -= Screen.height;
        hud.transform.position = hudPosition;

        ButtonZone = GameObject.Find("ButtonZone");
        ButtonZone2 = GameObject.Find("ButtonZone2");
        ButtonZone3 = GameObject.Find("ButtonZone3");

        StartCoroutine(TweenTranslate(1.2f));
	}
	void changeButtons()
    {
        ButtonZone.SetActive(false);
        ButtonZone2.SetActive(false);
        ButtonZone3.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
        if (ResponsesList != null)
        {
            button1.text = ResponsesList[0];
            button2.text = ResponsesList[1];
            button3.text = ResponsesList[2];
            button4.text = ResponsesList[3];
        }
        if (ArgumentsList != null)
        {
            button5.text = ArgumentsList[0];
            button6.text = ArgumentsList[1];
        }
	}


    void ShowMenu()
    {
        menu.gameObject.SetActive(true);
        EventManager.OnMenu -= ShowMenu;
    }

    void ShowHud(float vertAxis)
    {
        hudPosition = hud.transform.position;
        if (vertAxis > 0)
        {
            hudPosition.y += Screen.height;
        }
        else
        {
            hudPosition.y -= Screen.height;
        }
        hud.transform.position = hudPosition;

        
    }
    
    public void ResumePress()
    {
        menu.gameObject.SetActive(false);
        EventManager.OnMenu += ShowMenu;
    }

    public void RestartPress()
    {
        // reload lvl
    }

    public void MainMenuPress()
    {
        Application.LoadLevel(0);
    }

    public void ExitPress()
    {
        Application.Quit();
    }

    public void Button1Press()
    {
        OnArgument(button1.text, 0);
    }
    public void Button2Press()
    {
        OnArgument(button2.text, 1);
    }
    public void Button3Press()
    {
        OnArgument(button3.text, 2);
    }
    public void Button4Press()
    {
        OnArgument(button4.text, 3);
    }
    public void NewResponses(List<string> responsesList)
    {
        ButtonZone.SetActive(true);
        ButtonZone2.SetActive(false);
        ButtonZone3.SetActive(false);
        ResponsesList = responsesList;
        
    }

    public void Button5Press()
    {
        OnRetour(button5.text);
        // Debug.Log(GameManager.singleton.currentChar.type);
        if(GameManager.singleton.currentChar.type == CharacterManager.Type.Shy){
            GameManager.singleton.currentLoveMetre -= 2;
        }
        else    
        {
            GameManager.singleton.currentLoveMetre += 2;
        }
    }
    public void Button6Press()
    {
        OnRetour(button6.text);
        GameManager.singleton.currentLoveMetre += 2;
    }
    public void Button7Press()
    {
        OnNext();
    }
    public void NewArguments(List<string> argumentsList)
    {
        ButtonZone.SetActive(false);
        ButtonZone2.SetActive(true);
        ButtonZone3.SetActive(false);
        ArgumentsList = argumentsList;
    }

    public void NewAccroche(string accroche)
    {
        ButtonZone.SetActive(false);
        ButtonZone2.SetActive(false);
        ButtonZone3.SetActive(true);
    }

    IEnumerator TweenTranslate(float scaleTime)
    {
        float elapsedTime = 0;
        while(elapsedTime < scaleTime )// && AllowFX
        {
            // Debug.Log("dayum");
            float scaleRatio = scaleCurve.Evaluate(elapsedTime /scaleTime);
            transform.Translate(0, scaleRatio * 20f, 0);
            elapsedTime+= Time.deltaTime;
            yield return null;
        }
    }

}
