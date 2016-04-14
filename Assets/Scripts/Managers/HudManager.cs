using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public Transform menu;
    public Image hud;
    public Text button1;
    public Text button2;
    public Text button3;
    public Text button4;

    private Vector3 hudPosition;
    private List<string> ResponsesList;
    private List<string> ArgumentsList;

	// Use this for initialization
	void Start () {
        EventManager.OnMenu += ShowMenu;
        EventManager.OnUI += ShowHud;

        DialogueManager.OnReturnResponses += NewResponses;
        //DialogueManager.OnReturnArguments += NewArguments;

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

    }
    public void Button2Press()
    {

    }
    public void Button3Press()
    {

    }
    public void Button4Press()
    {

    }
    public void NewResponses(List<string> responsesList)
    {
        ResponsesList = responsesList;
    }

    public void Button5Press()
    {

    }
    public void Button6Press()
    {

    }
    public void NewArguments(List<string> argumentsList)
    {
        ArgumentsList = argumentsList;
    }
}
