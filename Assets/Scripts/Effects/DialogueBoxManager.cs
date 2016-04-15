using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class DialogueBoxManager : MonoBehaviour {

	public string text;
	public bool textLock = false;

	public List<string> dialList= new List<string>();
	public int dialogueIndex = 0;

	public float textSpeed;

	public Text uiText;

    public delegate void CharActionQ();
    public static event CharActionQ OnQuestion;

    public delegate void CharActionR();
    public static event CharActionR OnResponse;

    public delegate void CharActionRF();
    public static event CharActionRF OnRetourFinish;

	// Use this for initialization
	void Start () {
        DialogueManager.OnReturnAccroche += SetCurrentAccroche;
        DialogueManager.OnReturnQuestion += SetCurrentQuestion;
        DialogueManager.OnReturnRetour += SetCurrentRetour;
        HudManager.OnNext += NextIntel;
        Character.OnFinishQuestion += NewQuestion;

		uiText = GetComponent<Text>();
		//text = dialList[dialogueIndex];
        //StopCoroutine("LetterPop");
     	//StartCoroutine(LetterPop(text, textSpeed));
     
	}
    void NewQuestion()
    {
        OnQuestion();
    }
        void SetCurrentAccroche(string dialString)
    {
        
        StopCoroutine("LetterPop");
        StopAllCoroutines();
        EraseText();
        StartCoroutine(LetterPop(dialString, textSpeed));
        //dialList.Add(dialString);
        //dialList.Add("Je m'appel" + GameManager.singleton.currentChar.name);
        //dialList.Add("alors...");
        //EraseText();
        //StartCoroutine(LetterPop(dialList[0], textSpeed));
        
    }
    void NextIntel()
    {
        OnQuestion();
        //StartCoroutine(LetterPop("alors...", textSpeed));
    }

    void SetCurrentQuestion(string dialString)
    {
        
        StopCoroutine("LetterPop");
        StopAllCoroutines();
        EraseText();
        StartCoroutine(LetterPop(dialString, textSpeed));
        //dialList.Add(dialString);
        OnResponse();
    }

    void SetCurrentRetour(string dialString)
    {
        
        StopCoroutine("LetterPop");
        StopAllCoroutines();
        EraseText();
        StartCoroutine(LetterPop(dialString, textSpeed));
        //dialList.Add(dialString);
        OnRetourFinish();
    }

	public void NextDialogue()
	{
		if(!textLock)
		{
			if(dialogueIndex < dialList.Count-1){
				dialogueIndex++;
			}
			EraseText();

			SwitchText(dialList[dialogueIndex]);
			LaunchRoutine();

		}
	}
	

	public void LaunchRoutine(){
		if(!textLock)
		{
			textLock = true;
			StartCoroutine(LetterPop(text, textSpeed));
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator LetterPop(string text, float delay){

		for(int i = 0; i < text.Length; i++){
			uiText.text += text[i];
			// if(Input.GetKey(KeyCode.Mouse0)) TODO FIX !
			// {
			// 	uiText.text = text;
				
			// 	textLock = false;
			// 	yield break;
			// }
			yield return new WaitForSeconds(delay);
		}
		textLock = false;
		yield return null;
	}

	public void EraseText()
	{
		text = "";
		uiText.text = text;
	}

	public void SwitchText(string text)
	{
		this.text = text;
	}

	void fadeText(){}

	void skipText(){}

	void nextText(){}
}
