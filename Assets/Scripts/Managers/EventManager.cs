using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void MenuAction();
    public static event MenuAction OnMenu;

    public delegate void UIAction(float vertAxis);
    public static event UIAction OnUI;

    public delegate void CharAction();
    public static event CharAction OnNewFlirt;

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
