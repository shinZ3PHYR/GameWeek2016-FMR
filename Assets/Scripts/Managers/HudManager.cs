// using UnityEngine;
// using System.Collections;
// using UnityEngine.UI;

// public class HudManager : MonoBehaviour {

//     public Transform menu;
//     public Image hud;

//     private Vector3 hudPosition;

// 	// Use this for initialization
// 	void Start () {
//         EventManager.OnMenu += ShowMenu;
//         EventManager.OnUI += ShowHud;

//         menu.gameObject.SetActive(false);

//         hudPosition = hud.transform.position;
//         hudPosition.y -= Screen.height;
//         hud.transform.position = hudPosition;
// 	}
	
// 	// Update is called once per frame
// 	void Update () {
	    
// 	}


//     void ShowMenu()
//     {
//         menu.gameObject.SetActive(true);
//         EventManager.OnMenu -= ShowMenu;
//     }

//     void ShowHud(float vertAxis)
//     {
//         hudPosition = hud.transform.position;
//         if (vertAxis > 0)
//         {
//             hudPosition.y += Screen.height;
//         }
//         else
//         {
//             hudPosition.y -= Screen.height;
//         }
//         hud.transform.position = hudPosition;
//     }
    
//     public void ResumePress()
//     {
//         menu.gameObject.SetActive(false);
//         EventManager.OnMenu += ShowMenu;
//     }

//     public void RestartPress()
//     {
//         // reload lvl
//     }

//     public void MainMenuPress()
//     {
//         Application.LoadLevel(0);
//     }

//     public void ExitPress()
//     {
//         Application.Quit();
//     }
// }
