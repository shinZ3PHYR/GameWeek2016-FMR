using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Character : MonoBehaviour {

	public enum Mood
	{
		Happy,
		VeryHappy,
		Neutral,
		Angry,
		VeryAngry
	}

	public Mood currentMood = Mood.Neutral;


	public Sprite faceShape;
	public Sprite eyes;
	public Sprite mouth;
	public Sprite nose;
	public Sprite hairCut;
	public Sprite accessory;

	public List<Sprite> neutralSet = new List<Sprite>();
	public List<Sprite> happySet = new List<Sprite>();
	public List<Sprite> veryHappySet = new List<Sprite>();
	public List<Sprite> angrySet = new List<Sprite>();
	public List<Sprite> veryAngrySet = new List<Sprite>();

	public List<Sprite> currentSet = new List<Sprite>();

	public List<string> likeList = new List<string>();
	public List<string> dislikeList = new List<string>();

	public CharacterManager.Type type;
	public CharacterManager.Gender gender;
	public CharacterManager.Race race;


	void Start ()
	{
		Debug.Log(type);
		// Debug.Log(neutralSet[0]);
		// currentSet[1] = GetChild(1);
	}
	public void DrawNeutralChar()
	{

		if (!faceShape) {
			Debug.LogError("no faceshape");
			Debug.Log(gameObject);
		}
		transform.GetChild(0).GetComponent<Image>().sprite = faceShape;
		transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes
		transform.GetChild(2).GetComponent<Image>().sprite = neutralSet[1]; //mouth
		transform.GetChild(3).GetComponent<Image>().sprite = nose;
		transform.GetChild(4).GetComponent<Image>().sprite = neutralSet[2]; //hairCut
		transform.GetChild(5).GetComponent<Image>().sprite = neutralSet[3]; //Dress
		transform.GetChild(6).GetComponent<Image>().sprite = neutralSet[4]; //ForeArm
	}

	public void changeMood(Mood mood)
	{
		switch(mood)
		{
			case Mood.Neutral:
				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = neutralSet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = neutralSet[4]; //ForeArm
				break;
			case Mood.VeryHappy:
				transform.GetChild(1).GetComponent<Image>().sprite = veryHappySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = veryHappySet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = veryHappySet[2]; //ForeArm
				break;
			case Mood.Happy:
				transform.GetChild(1).GetComponent<Image>().sprite = happySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = happySet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = happySet[2]; //ForeArm
				break;
			case Mood.VeryAngry:
				transform.GetChild(1).GetComponent<Image>().sprite = veryAngrySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = veryAngrySet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = veryAngrySet[2]; //ForeArm
				break;
			case Mood.Angry:
				transform.GetChild(1).GetComponent<Image>().sprite = angrySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = angrySet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = angrySet[2]; //ForeArm
				break;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
