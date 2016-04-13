using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random=UnityEngine.Random;
using System.Linq;

public class CharacterManager : MonoBehaviour {

	public enum Type
	{
		Shy,
		Haughty,
		Tomboy,
		HungUp,
		Seductive,
		Bipolar
	}

	public enum Race
	{
		Human,
		Vampire,
		Animal
	}
	public Transform charaPos;

	public GameObject genericCharacterPrefab;

	public List<Sprite> facePool = new List<Sprite>();
	public List<Sprite> eyesPool = new List<Sprite>();
	public List<Sprite> mouthesPool = new List<Sprite>();
	public List<Sprite> hairCutPool = new List<Sprite>();
	public List<Sprite> dressPool = new List<Sprite>();
	// public List<Sprite> accessoryPool = new List<Sprite>();
	public List<Sprite> foreArmsPool = new List<Sprite>();
	public List<string> namePool = new List<string>();

	public List<Sprite> moodPool = new List<Sprite>();

	public List<Character> charaList = new List<Character>();

	// public Character customCharacter;

	public void CreateRandomChar()
	{

		GameObject EmptyChar = GameObject.Instantiate(genericCharacterPrefab, charaPos.position, Quaternion.identity) as GameObject;
		EmptyChar.transform.parent = GameObject.Find("Canvas").transform;
		Character customCharacter = EmptyChar.GetComponent<Character>();
		//TODO Manage Race
		customCharacter.race = (Race)Random.Range(0,2);
		// customCharacter.faceShape = facePool[Random.Range(0, facePool.Count-1)];
		customCharacter.neutralSet.Add(eyesPool[Random.Range(0, eyesPool.Count-1)]); //eyes
		customCharacter.neutralSet.Add(mouthesPool[Random.Range(0, mouthesPool.Count-1)]);
		customCharacter.neutralSet.Add(hairCutPool[Random.Range(0, hairCutPool.Count-1)]);
		customCharacter.neutralSet.Add(dressPool[Random.Range(0, dressPool.Count-1)]);
		customCharacter.neutralSet.Add(foreArmsPool[Random.Range(0, foreArmsPool.Count-1)]);

		customCharacter.name = namePool[Random.Range(0, namePool.Count-1)];
		customCharacter.type = (Type)Random.Range(0, 5);

		// Debug.Log("race: "+customCharacter.race+"; eyes: "+customCharacter.neutralSet[0]+"; mouth: "+customCharacter.neutralSet[1]+"; haircut: "+customCharacterHairCut+"; dress: "+customCharacterDress+"; name: "+customCharacterName+"; type: "+customCharacter.type);

		charaList.Add(customCharacter);
		
		GetAssociatedSet(customCharacter.type, )

		customCharacter.DrawNeutralChar();
	}

	public void CheckCharaList()
	{

	}

	public void GetAssociatedSet(Type type, List<Sprite> spriteList)
	{
		switch(type)
		{
			case Type.Shy: 
				GetShyHappySet(spriteList);
				GetShyVeryHappySet(spriteList);
				GetShyAngrySet(spriteList);
				GetShyVeryAngrySet(spriteList);
				break;
			case Type.Haughty:
				GetHaughtyHappySet(spriteList);
				GetHaughtyVeryHappySet(spriteList);
				GetHaughtyAngrySet(spriteList);
				GetHaughtyVeryAngrySet(spriteList);
				break;
			case Type.Tomboy: break;
			case Type.HungUp: break;
			case Type.Seductive:break;
			case Type.Bipolar:break;
		}
	}

//ShySet
	public void GetShyHappySet(spriteList)
	{
		for(int i = 0; i<spriteList; i++)
		{
			Debug.Log(spriteList[i]);
			Sprites happyShyEyes = moodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
		}

	}

	public void GetShyAngrySet()
	{

	}

	public void GetShyVeryHappySet()
	{

	}

	public void GetShyVeryAngrySet()
	{

	}
//Haughty Set
	public void GetHaughtyHappySet()
	{

	}

	public void GetHaughtyAngrySet()
	{

	}

	public void GetHaughtyVeryHappySet()
	{

	}

	public void GetHaughtyVeryAngrySet()
	{

	}

//HungUp Set
	public void GetHungUpHappySet()
	{

	}

	public void GetHungUpAngrySet()
	{

	}

	public void GetHungUpVeryHappySet()
	{

	}

	public void GetHungUpVeryAngrySet()
	{

	}

//Tomboy Set
	public void GetTomboyHappySet()
	{

	}

	public void GetTomboyAngrySet()
	{

	}

	public void GetTomboyVeryHappySet()
	{

	}

	public void GetTomboyVeryAngrySet()
	{

	}

//Seductive Set
	public void GetSeductiveHappySet()
	{

	}

	public void GetSeductiveAngrySet()
	{

	}

	public void GetSeductiveVeryHappySet()
	{

	}

	public void GetSeductiveVeryAngrySet()
	{

	}

//Bipolar Set
	public void GetBipolarHappySet()
	{

	}

	public void GetBipolarAngrySet()
	{

	}

	public void GetBipolarVeryHappySet()
	{

	}

	public void GetBipolarVeryAngrySet()
	{

	}


	// Use this for initialization
	void Start () 
	{
		CreateRandomChar();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
