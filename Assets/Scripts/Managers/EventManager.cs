using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

    public delegate void MenuAction();
    public static event MenuAction OnMenu;

    public delegate void UIAction(float vertAxis);
    public static event UIAction OnUI;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
        {
            OnMenu();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            
            Debug.Log("event!");
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            OnUI(Input.GetAxis("Vertical"));
        }
	}
}
