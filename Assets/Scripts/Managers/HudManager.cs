using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    public Image menu;
    public Image hud;

    private Vector3 menuPosition;
    private Vector3 hudPosition;

	// Use this for initialization
	void Start () {
        EventManager.OnMenu += ShowMenu;
        EventManager.OnUI += ShowHud;

        menuPosition = menu.transform.position;
        menuPosition.y -= Screen.height;
        menu.transform.position = menuPosition;

        hudPosition = hud.transform.position;
        hudPosition.y -= Screen.height;
        hud.transform.position = hudPosition;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    void ShowMenu()
    {
        menuPosition = menu.transform.position;
        menuPosition.y += Screen.height;
        menu.transform.position = menuPosition;
        EventManager.OnMenu -= ShowMenu;
    }

    void ShowHud(float vertAxis)
    {
        hudPosition = hud.transform.position;
        if (vertAxis > 0)
            hudPosition.y += Screen.height;
        else
            hudPosition.y -= Screen.height;
        hud.transform.position = hudPosition;
        //EventManager.OnMenu -= ShowMenu;
    }
}
