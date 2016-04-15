using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    public Character currentChar;
    public int charIndex = 0;

    public delegate void CharAction();
    public static event CharAction OnNewFlirt;

    public bool MEC = false;
    public bool MEUF;

    public List<Character> charList = new List<Character>();

    public int currentLoveMetre;
    public Image loveMeterFill;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public Difficulty difficulty = Difficulty.Normal;

    void Awake()
    {
        if (singleton != null)
            Destroy(singleton.gameObject);

        singleton = this as GameManager;
    }

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this);
        CharacterManager.OnCreatedCharaList += getFirstChar;
        Character.OnFinishChar += getCurrentChar;
	}
	
    public void getFirstChar()
    {
        currentChar = charList[charIndex];
        for(int i=0; i<charList.Count; i++)
        {
            charList[i].gameObject.SetActive(false);
        }
        currentChar.gameObject.SetActive(true);
        OnNewFlirt();
    }
    public void getCurrentChar()
    {
        currentChar.gameObject.SetActive(false);
        currentChar = charList[charIndex];
        currentChar.gameObject.SetActive(true);
        OnNewFlirt();
    }
	// Update is called once per frame
	void Update () {
	   if(loveMeterFill == null)
            return;

        loveMeterFill.fillAmount = currentLoveMetre * (1f/8f); 

	}
}
