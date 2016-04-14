using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour {

    public delegate void AccrocheAction(string accroche);
    public static event AccrocheAction OnReturnAccroche;

    public delegate void QuestionAction(string question);
    public static event QuestionAction OnReturnQuestion;

    public delegate void ResponseAction(List<string> responses);
    public static event ResponseAction OnReturnResponses;

    public delegate void ArgAction(List<string> arguments);
    public static event ArgAction OnReturnArguments;

    public delegate void RetourAction(string retour);
    public static event RetourAction OnReturnRetour;

    private GameObject currentChar;
    private int currentType;
    public List<string> likeList;
    public List<string> dislikeList;

    private int rdmValue;
    private int rdmChance;

    public List<string> Categories;
    private string categorie;
    public List<string> accroches;
    private string accroche;

    public List<string> Questions;
    private Dictionary<string, string> questionsCategories = new Dictionary<string, string>();
    private string question;

    private Dictionary<string, string> questionsResponses = new Dictionary<string, string>();
    public List<string> Responses;
    private List<string> responses;
    private string chosenResponse;

    private Dictionary<string, string> responsesArguments = new Dictionary<string, string>();
    public List<string> Arguments;
    private List<string> arguments;
    private string chosenArgument;

    private Dictionary<string, string> argumentsRetours = new Dictionary<string, string>();
    public List<string> Retours;
    private List<string> retours;

   

	// Use this for initialization
	void Start () {

        for (int i = 0; i < Categories.Count; i++)
        {
            questionsCategories.Add(Categories[i], Questions[i * 2]);
            questionsCategories.Add(Categories[i] + "2", Questions[i * 2 + 1]);
        }
        for (int i = 0; i < Questions.Count; i++)
        {
            questionsResponses.Add(Questions[i] + "0", Responses[i * 4]);
            questionsResponses.Add(Questions[i] + "1", Responses[i * 4 + 1]);
            questionsResponses.Add(Questions[i] + "2", Responses[i * 4 + 2]);
            questionsResponses.Add(Questions[i] + "3", Responses[i * 4 + 3]);
        }
        for (int i = 0; i < Responses.Count; i++)
        {
            responsesArguments.Add(Responses[i] + "0", Arguments[i * 2]);
            responsesArguments.Add(Responses[i] + "1", Arguments[i * 2 + 1]);
        }
        for (int i = 0; i < Arguments.Count; i++)
        {
            argumentsRetours.Add(Arguments[i] + "0", Retours[i * 2]);
            argumentsRetours.Add(Arguments[i] + "1", Retours[i * 2 + 1]);
        }

        currentChar = GameManager.singleton.currentChar;
        EventManager.OnNewFlirt += NewAccroche;
        DialogueBoxManager.OnQuestion += NewQuestion;
        DialogueBoxManager.OnResponse += NewResponses;
        HudManager.OnArgument += NewArguments;
        HudManager.OnRetour += NewRetours;
        
        

        
        //EventManager.OnReturnResponse(responses);
        //EventManager.OnReturnArgument(arguments);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void NewAccroche()
    {
        currentChar = GameManager.singleton.currentChar;
        //currentType = currentChar.GetComponent<Character>().type;
        currentType = 0;
        //likeList = currentChar.GetComponent<Character>().likeList;
        //dislikeList = currentChar.GetComponent<Character>().dislikeList;

        rdmValue = Random.Range(0, 10);
        rdmChance = Random.Range(0, 1);
        accroche = accroches[rdmValue];
        switch (currentType)
        {
            case 0:
                if (rdmChance == 0)
                {
                  accroche = accroches[0];
                }
                break;
            case 1:
                if (rdmChance == 0)
                {
                  accroche = accroches[1];
                }
                break;
            case 2:
                if (rdmChance == 0)
                {
                  accroche = accroches[2];
                }
                break;
            case 3:
                if (rdmChance == 0)
                {
                  accroche = accroches[3];
                }
                break;
            case 4:
                if (rdmChance == 0)
                {
                  accroche = accroches[4];
                }
                break;
            case 5:
                if (rdmChance == 0)
                {
                  accroche = accroches[5];
                }
                break;
        }
        OnReturnAccroche(accroche);
    }

    void NewQuestion()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                categorie = likeList[0];
                break;
            case 1:
                categorie = likeList[1];
                break;
            case 2:
                categorie = dislikeList[0];
                break;
            case 3:
                categorie = dislikeList[1];
                break;
        }
        question = questionsCategories[categorie];
        OnReturnQuestion(question);
    }

    void NewResponses()
    {
        responses = new List<string>();
        for (int i = 0; i < 4; i++)
        {
        responses.Add(questionsResponses[question + i]);
        }
        OnReturnResponses(responses);
    }

    void NewArguments(string chosenResponse)
    {
        arguments = new List<string>();
        for (int i = 0; i < 2; i++)
        {
            arguments.Add(responsesArguments[chosenResponse + i]);
        }
        OnReturnArguments(arguments);
    }
    void NewRetours(string chosenArgument)
    {
        retours = new List<string>();
        for (int i = 0; i < 2; i++)
        {
            retours.Add(argumentsRetours[chosenArgument + i]);
        }
        OnReturnRetour(retours[0]);
    }
}
