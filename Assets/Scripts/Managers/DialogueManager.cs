using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

    private GameObject currentChar;
    private string currentType;
    private int rdmValue;
    private int rdmChance;

    public List<string> accroches;
    private string accroche;
    //private Dictionary<int, string> questions;
    public List<string> Questions;
    //private Dictionary<int, string> reponses;
    public List<string> Reponses;
    //private Dictionary<int, string> arguments;
    public List<string> Arguments;

   

	// Use this for initialization
	void Start () {
        currentChar = GameManager.singleton.currentChar;
        EventManager.OnNewFlirt += NewFlirt;
        //EventManager.OnQuestion += NewFlirt;
        //EventManager.OnResponse += NewFlirt;
        //EventManager.OnArgument += NewFlirt;
        //
        //EventManager.OnAccroche();
        //EventManager.OnReturnQuestion();
        //EventManager.OnReturnResponse();
        //EventManager.OnReturnArgument();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void NewFlirt()
    {
        currentChar = GameManager.singleton.currentChar;
        //currentType = currentChar.GetComponent<Character>().type;
        rdmValue = Random.Range(0, 10);
        rdmChance = Random.Range(0, 1);
        accroche = accroches[rdmValue];
        //switch (currentType)
        //{
        //    case 0:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[0];
        //        }
        //        break;
        //    case 1:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[1];
        //        }
        //        break;
        //    case 2:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[2];
        //        }
        //        break;
        //    case 3:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[3];
        //        }
        //        break;
        //    case 4:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[4];
        //        }
        //        break;
        //    case 5:
        //        if (rdmChance == 0)
        //        {
        //          accroche = accroches[5];
        //        }
        //        break;
        //}
    }
}
