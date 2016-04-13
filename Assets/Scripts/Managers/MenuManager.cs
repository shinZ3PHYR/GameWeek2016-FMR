using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public Transform MainMenu;
    public Transform OptionsMenu;
    public Transform CreditsMenu;
    public Transform ModeMenu;

    void Start()
    {
        OptionsMenu.gameObject.SetActive(false);
        CreditsMenu.gameObject.SetActive(false);
        ModeMenu.gameObject.SetActive(false);
        //MainMenu = MainMenu.GetComponent<Canvas>();
    }




    public void PlayPress()
    {
        MainMenu.gameObject.SetActive(false);
        ModeMenu.gameObject.SetActive(true);
    }

    public void FacilePress()
    {
        Application.LoadLevel(1);
    }

    public void NormalPress()
    {
        Application.LoadLevel(2);
    }

    public void DifficilePress()
    {
        Application.LoadLevel(3);
    }

    public void OptionsPress()
    {
        // Options à enregistré dans le gameManager
        MainMenu.gameObject.SetActive(false);
        OptionsMenu.gameObject.SetActive(true);
    }

    public void CreditsPress()
    {
        MainMenu.gameObject.SetActive(false);
        CreditsMenu.gameObject.SetActive(true);
    }

    public void RetourPress()
    {
        OptionsMenu.gameObject.SetActive(false);
        CreditsMenu.gameObject.SetActive(false);
        ModeMenu.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }

    public void ExitPress()
    {
        Application.Quit();
    }

}
