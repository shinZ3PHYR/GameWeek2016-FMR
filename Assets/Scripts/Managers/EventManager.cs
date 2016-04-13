using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public delegate void MenuAction();
    public static event MenuAction OnMenu;

    public delegate void UIAction(float vertAxis);
    public static event UIAction OnUI;

    public delegate void CharAction();
    public static event CharAction OnNewFlirt;
    public static event CharAction OnQuestion;
    public static event CharAction OnResponse;

    public delegate void CharActionParam(string chosenOne);
    public static event CharActionParam OnArgument;
    public static event CharActionParam OnRetour;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            OnMenu();
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            OnUI(Input.GetAxis("Vertical"));
        }
	}
}
