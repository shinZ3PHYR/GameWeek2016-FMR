using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public delegate void CharActionParamA(string chosenOne);
    public static event CharActionParamA OnArgument;

    public delegate void CharActionParam(string chosenOne);
    public static event CharActionParam OnRetour;

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

	// Use this for initialization
	void Start () {
        EventManager.OnMenu += ShowMenu;
        EventManager.OnUI += ShowHud;

        DialogueManager.OnReturnResponses += NewResponses;
        DialogueManager.OnReturnArguments += NewArguments;

        menu.gameObject.SetActive(false);

        hudPosition = hud.transform.position;
        hudPosition.y -= Screen.height;
        hud.transform.position = hudPosition;
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
        OnArgument(button1.text);
    }
    public void Button2Press()
    {
        OnArgument(button2.text);
    }
    public void Button3Press()
    {
        OnArgument(button3.text);
    }
    public void Button4Press()
    {
        OnArgument(button4.text);
    }
    public void NewResponses(List<string> responsesList)
    {
        ResponsesList = responsesList;
    }

    public void Button5Press()
    {
        OnRetour(button5.text);
    }
    public void Button6Press()
    {
        OnRetour(button6.text);
    }
    public void NewArguments(List<string> argumentsList)
    {
        ArgumentsList = argumentsList;
    }
}
