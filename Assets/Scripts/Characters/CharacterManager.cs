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

	public enum Gender
	{
		Male,
		Female
	}

	public Transform charaPos;

	public GameObject genericCharacterPrefab;

	public List<Sprite> femaleFacePool = new List<Sprite>();
	public List<Sprite> femaleEyesPool = new List<Sprite>();
	public List<Sprite> femaleMouthesPool = new List<Sprite>();
	public List<Sprite> femaleHairCutPool = new List<Sprite>();
	public List<Sprite> femaleDressPool = new List<Sprite>();
	// public List<Sprite> accessoryPool = new List<Sprite>();
	public List<Sprite> femaleForeArmsPool = new List<Sprite>();
	public List<string> femaleNamePool = new List<string>();

	public List<Sprite> femaleMoodPool = new List<Sprite>();

	public List<Character> charaList = new List<Character>();

	public Character customCharacter;

	public void CreateRandomChar()
	{

		GameObject EmptyChar = GameObject.Instantiate(genericCharacterPrefab, charaPos.position, Quaternion.identity) as GameObject;
		EmptyChar.transform.parent = GameObject.Find("Canvas").transform;
		customCharacter = EmptyChar.GetComponent<Character>();
		//TODO Manage Race
		customCharacter.race = (Race)Random.Range(0,2);
		customCharacter.gender = (Gender)Random.Range(1, 1); //TODO ADD MALES

		if(customCharacter.gender == Gender.Female)
		{
			customCharacter.neutralSet.Add(femaleEyesPool[Random.Range(0, femaleEyesPool.Count-1)]); //eyes
			customCharacter.neutralSet.Add(femaleMouthesPool[Random.Range(0, femaleMouthesPool.Count-1)]);
			customCharacter.neutralSet.Add(femaleHairCutPool[Random.Range(0, femaleHairCutPool.Count-1)]);
			customCharacter.neutralSet.Add(femaleDressPool[Random.Range(0, femaleDressPool.Count-1)]);
			customCharacter.neutralSet.Add(femaleForeArmsPool[Random.Range(0, femaleForeArmsPool.Count-1)]);

			customCharacter.name = femaleNamePool[Random.Range(0, femaleNamePool.Count-1)];
			customCharacter.type = (Type)Random.Range(0, 5);

			// Debug.Log("race: "+customCharacter.race+"; eyes: "+customCharacter.neutralSet[0]+"; mouth: "+customCharacter.neutralSet[1]+"; haircut: "+customCharacterHairCut+"; dress: "+customCharacterDress+"; name: "+customCharacterName+"; type: "+customCharacter.type);

			charaList.Add(customCharacter);
			
			GetAssociatedSet(customCharacter.type, customCharacter.neutralSet);

			customCharacter.DrawNeutralChar();
		}
		else
		{
			Debug.Log("it's a male");
		}
		// customCharacter.faceShape = facePool[Random.Range(0, facePool.Count-1)];
	}

	public void CheckCharaList()
	{

	}

	public void GetAssociatedSet(Type type, List<Sprite> spriteList)
	{
		switch(type)
		{
			case Type.Shy: 
				// GetShyHappySet(spriteList);
				// GetShyVeryHappySet(spriteList);
				// GetShyAngrySet(spriteList);
				// GetShyVeryAngrySet(spriteList);
				break;
			case Type.Haughty:
				// GetHaughtyHappySet(spriteList);
				// GetHaughtyVeryHappySet(spriteList);
				// GetHaughtyAngrySet(spriteList);
				// GetHaughtyVeryAngrySet(spriteList);
				break;
			case Type.Tomboy: break;
			case Type.HungUp: break;
			case Type.Seductive:break;
			case Type.Bipolar:break;
		}
	}

//ShySet
	public void GetShyHappySet(List<Sprite> spriteList)
	{
		// for(int i = 0; i<spriteList.Count; i++)
		// {
		// 	Debug.Log(spriteList[i]);
		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
		// 	// Sprite happyShyForeArms = 
		// }

		customCharacter.happySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("Happy")));

	}

// 	public void GetShyAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.angrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("Angry")));
// 	}

// 	public void GetShyVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryHappySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("VeryHappy")));
// 	}

// 	public void GetShyVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryAngrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("VeryAngry")));
// 	}
// //Haughty Set
// 	public void GetHaughtyHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.happySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 	}

// 	public void GetHaughtyAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.angrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains("Mouth")&&item.name.Contains("Angry")));
// 	}

// 	public void GetHaughtyVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryHappySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryHappy")));
// 	}

// 	public void GetHaughtyVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryAngrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryAngry")));
// 	}

// //HungUp Set
// 	public void GetHungUpHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.happySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 	}

// 	public void GetHungUpAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.angrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Angry")));
// 	}

// 	public void GetHungUpVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryHappySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryHappy")));
// 	}

// 	public void GetHungUpVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryAngrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryAngry")));
// 	}	

// //Tomboy Set
// 	public void GetTomboyHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.happySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 	}

// 	public void GetTomboyAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.angrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Angry")));
// 	}

// 	public void GetTomboyVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryHappySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryHappy")));
// 	}

// 	public void GetTomboyVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 		customCharacter.veryAngrySet[1] = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("VeryAngry")));
// 	}

// //Seductive Set
// 	public void GetSeductiveHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetSeductiveAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetSeductiveVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetSeductiveVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// //Bipolar Set
// 	public void GetBipolarHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetBipolarAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetBipolarVeryHappySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}

// 	public void GetBipolarVeryAngrySet(List<Sprite> spriteList)
// 	{
// 		// for(int i = 0; i<spriteList.Count; i++)
// 		// {
// 		// 	Debug.Log(spriteList[i]);
// 		// 	// Sprite happyShyEyes = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Eyes")&&item.name.Contains("Happy")));
// 		// 	// Sprite happyShyMouth = femaleMoodPool.Find(item=>(item.name.Contains(spriteList[i])&&item.name.Contains("Mouth")&&item.name.Contains("Happy")));
// 		// }
// 	}


	// Use this for initialization
	void Start () 
	{
		CreateRandomChar();
		customCharacter = null;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
