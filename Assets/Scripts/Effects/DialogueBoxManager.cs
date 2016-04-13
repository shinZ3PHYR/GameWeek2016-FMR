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

	// Use this for initialization
	void Start () {
		
		uiText = GetComponent<Text>();
		text = dialList[dialogueIndex];
       
     	StartCoroutine(LetterPop(text, textSpeed));
     
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
