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

	public CharacterManager.Type archetype;

	public CharacterManager.Race race;


	void Start ()
	{
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
		// transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0];
	}
	// Update is called once per frame
	void Update () {
	
	}
}
