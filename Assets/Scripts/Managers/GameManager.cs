﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    public Character currentChar;
    private int charIndex = 0;

    public delegate void CharAction();
    public static event CharAction OnNewFlirt;

    public bool MEC = false;
    public bool MEUF;

    public List<Character> charList = new List<Character>();
    public int currentLoveMetre;

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
    }
    public void getCurrentChar()
    {

        for(int i=0; i<charList.Count; i++)
        {
            charList[i].gameObject.SetActive(false);
        }
        currentChar.gameObject.SetActive(true);
        

        OnNewFlirt();
    }
	// Update is called once per frame
	void Update () {
	
	}
}
