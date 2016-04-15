using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using Random=UnityEngine.Random;
using System.Linq;

public class CharacterManager : MonoBehaviour {

	public delegate void ListAction();
    public static event ListAction OnCreatedCharaList;

	public enum Type
	{
		Shy,
		Seductive,
		Tomboy,
		HungUp,
		Haughty,
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

	public List<string> wayOfLifePool = new List<string>();
	public List<string> hobbiesPool = new List<string>();

	public List<string> bodyColorPool = new List<string>();

	public List<Sprite> femaleEyesPool = new List<Sprite>();
	public List<Sprite> femaleMouthesPool = new List<Sprite>();
	public List<Sprite> femaleHairCutPool = new List<Sprite>();
	public List<Sprite> femaleHairCutFrontPool = new List<Sprite>();

	public List<Sprite> femaleDressPool = new List<Sprite>();
	// public List<Sprite> accessoryPool = new List<Sprite>();
	public List<Sprite> femaleForeArmsPool = new List<Sprite>();
	public List<Sprite> femaleBodyPool = new List<Sprite>();
	public List<Sprite> femaleFacePool = new List<Sprite>();
	public List<string> femaleNamePool = new List<string>();

	public List<Sprite> femaleMoodPool = new List<Sprite>();

	public List<Sprite> maleEyesPool = new List<Sprite>();
	public List<Sprite> maleMouthesPool = new List<Sprite>();
	public List<Sprite> maleHairCutPool = new List<Sprite>();
	public List<Sprite> maleHairCutFrontPool = new List<Sprite>();
	public List<Sprite> maleDressPool = new List<Sprite>();	// public List<Sprit accessoryPool = new List<Sprite>()	
	public List<Sprite> maleForeArmsPool = new List<Sprite>();
	public List<Sprite> maleBodyPool = new List<Sprite>();
	public List<Sprite> maleFacePool = new List<Sprite>();
	public List<string> maleNamePool = new List<string>();

	public List<Sprite> maleMoodPool = new List<Sprite>();

	public List<Character> charaList = new List<Character>();

	public Character customCharacter;

	public void CreateRandomChar()
	{
		if(customCharacter != null)
		{
			customCharacter = null;
		}

		GameObject EmptyChar = GameObject.Instantiate(genericCharacterPrefab, charaPos.position, Quaternion.identity) as GameObject;
		EmptyChar.transform.parent = GameObject.Find("Characters").transform;
		customCharacter = EmptyChar.GetComponent<Character>();

		customCharacter.charaPos = charaPos;
		//TODO Manage Race
		
		if(GameManager.singleton.MEUF)
		{
			customCharacter.gender = Gender.Male;
		}
		if(GameManager.singleton.MEC)
		{
			customCharacter.gender = Gender.Female;
		}
		if(GameManager.singleton.MEC && GameManager.singleton.MEUF)
		{
			customCharacter.gender = (Gender)Random.Range(1,2);
		}

		customCharacter.race = (Race)Random.Range(0,2);
		if(customCharacter.gender == Gender.Female)
		{	
				
			customCharacter.eyesColor = new Color(Random.Range(.4f, 1), Random.Range(.4f, 1), Random.Range(.4f, 1));
			
			customCharacter.neutralSet.Add(femaleEyesPool[Random.Range(0, femaleEyesPool.Count-1)]); //eyes
			customCharacter.neutralSet.Add(femaleMouthesPool[Random.Range(0, femaleMouthesPool.Count-1)]);
			customCharacter.neutralSet.Add(femaleHairCutPool[Random.Range(0, femaleHairCutPool.Count-1)]);
			
			customCharacter.hairCutFront = femaleHairCutFrontPool[Random.Range(0, femaleHairCutFrontPool.Count-1)];
			customCharacter.dress = femaleDressPool[Random.Range(0, femaleDressPool.Count-1)];
			customCharacter.bodyColor = bodyColorPool[Random.Range(0, bodyColorPool.Count-1)];
			
			customCharacter.foreArms = femaleForeArmsPool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));
			customCharacter.body = femaleBodyPool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));
			customCharacter.faceShape = femaleFacePool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));


			customCharacter.name = femaleNamePool[Random.Range(0, femaleNamePool.Count-1)];

			switch(GameManager.singleton.difficulty)
			{
				case GameManager.Difficulty.Easy: customCharacter.type = (Type)Random.Range(0, 1); break;
				case GameManager.Difficulty.Normal: customCharacter.type = (Type)Random.Range(0, 3); break;
				case GameManager.Difficulty.Hard: customCharacter.type = (Type)Random.Range(0, 5); break;
				default: customCharacter.type = (Type)Random.Range(0, 3); break;
			}

			// Debug.Log("race: "+customCharacter.race+"; eyes: "+customCharacter.neutralSet[0]+"; mouth: "+customCharacter.neutralSet[1]+"; haircut: "+customCharacterHairCut+"; dress: "+customCharacterDress+"; name: "+customCharacterName+"; type: "+customCharacter.type);

			charaList.Add(customCharacter);
			
			GetAssociatedSet(customCharacter.type, customCharacter.neutralSet);

			customCharacter.DrawNeutralChar(); //TODO débrancher drawneutralchar
		}
		else
		{
			customCharacter.eyesColor = new Color(Random.Range(.4f, 1), Random.Range(.4f, 1), Random.Range(.4f, 1));
			
			customCharacter.neutralSet.Add(maleEyesPool[Random.Range(0, maleEyesPool.Count-1)]); //eyes
			customCharacter.neutralSet.Add(maleMouthesPool[Random.Range(0, maleMouthesPool.Count-1)]);
			customCharacter.neutralSet.Add(maleHairCutPool[Random.Range(0, maleHairCutPool.Count-1)]);
			
			customCharacter.hairCutFront = maleHairCutFrontPool[Random.Range(0, maleHairCutFrontPool.Count-1)];
			customCharacter.dress = maleDressPool[Random.Range(0, maleDressPool.Count-1)];
			customCharacter.bodyColor = bodyColorPool[Random.Range(0, bodyColorPool.Count-1)];
			
			customCharacter.foreArms = maleForeArmsPool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));
			customCharacter.body = maleBodyPool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));
			customCharacter.faceShape = maleFacePool.Find(item=>(item.name.Contains(customCharacter.bodyColor)));


			customCharacter.name = maleNamePool[Random.Range(0, maleNamePool.Count-1)];
			
			switch(GameManager.singleton.difficulty)
			{
				case GameManager.Difficulty.Easy: customCharacter.type = (Type)Random.Range(0, 1); break;
				case GameManager.Difficulty.Normal: customCharacter.type = (Type)Random.Range(0, 3); break;
				case GameManager.Difficulty.Hard: customCharacter.type = (Type)Random.Range(0, 5); break;
				default: customCharacter.type = (Type)Random.Range(0, 3); break;
			}
			
			// Debug.Log("race: "+customCharacter.race+"; eyes: "+customCharacter.neutralSet[0]+"; mouth: "+customCharacter.neutralSet[1]+"; haircut: "+customCharacterHairCut+"; dress: "+customCharacterDress+"; name: "+customCharacterName+"; type: "+customCharacter.type);

			charaList.Add(customCharacter);
			
			GetAssociatedSet(customCharacter.type, customCharacter.neutralSet);

			customCharacter.DrawNeutralChar();

		}

		SetLikes();
		SetDislikes();
		// customCharacter.faceShape = facePool[Random.Range(0, facePool.Count-1)];
	}

	public void CheckCharaList()
	{

	}

	public void GetAssociatedSet(Type type, List<Sprite> spriteList)
	{
		GetHappySet(type);
		GetVeryHappySet(type);
		GetAngrySet(type);
		GetVeryAngrySet(type);
		// switch(type)
		// {
		// 	case Type.Shy: 
		// 		// GetShyHappySet(spriteList);
		// 		// GetShyVeryHappySet(spriteList);
		// 		// GetShyAngrySet(spriteList);
		// 		// GetShyVeryAngrySet(spriteList);
		// 		break;
		// 	case Type.Haughty:
		// 		// GetHaughtyHappySet(spriteList);
		// 		// GetHaughtyVeryHappySet(spriteList);
		// 		// GetHaughtyAngrySet(spriteList);
		// 		// GetHaughtyVeryAngrySet(spriteList);
		// 		break;
		// 	case Type.Tomboy: break;
		// 	case Type.HungUp: break;
		// 	case Type.Seductive:break;
		// 	case Type.Bipolar:break;
		// }
	}

	public void GetHappySet(Type type)
	{
		// Debug.Log(type.ToString());
		
		customCharacter.happySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Mouth")&&item.name.Contains("Happy")&&item.name.Contains(customCharacter.gender.ToString()))));//
		customCharacter.happySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Eyes")&&item.name.Contains("Happy")&&item.name.Contains(customCharacter.gender.ToString()))));
		
	}

	public void GetVeryHappySet(Type type)
	{
		customCharacter.veryHappySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Mouth")&&item.name.Contains("Veryhappy")&&item.name.Contains(customCharacter.gender.ToString()))));//
		customCharacter.veryHappySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Eyes")&&item.name.Contains("Veryhappy")&&item.name.Contains(customCharacter.gender.ToString()))));
	}

	public void GetAngrySet(Type type)
	{
		customCharacter.angrySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Mouth")&&item.name.Contains("Angry")&&item.name.Contains(customCharacter.gender.ToString()))));//
		customCharacter.angrySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Eyes")&&item.name.Contains("Angry")&&item.name.Contains(customCharacter.gender.ToString()))));
	}

	public void GetVeryAngrySet(Type type)
	{
		customCharacter.veryAngrySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Mouth")&&item.name.Contains("Veryangry")&&item.name.Contains(customCharacter.gender.ToString()))));//
		customCharacter.veryAngrySet.Add(femaleMoodPool.Find(item=>(item.name.Contains(type.ToString())&&item.name.Contains("Eyes")&&item.name.Contains("Veryangry")&&item.name.Contains(customCharacter.gender.ToString()))));
	}

	public void SetLikes()
	{
		
		customCharacter.likeList.Add(wayOfLifePool[Random.Range(0, wayOfLifePool.Count-1)]);
		customCharacter.likeList.Add(hobbiesPool[Random.Range(0, hobbiesPool.Count-1)]);
	}

	public void SetDislikes()
	{
		// wayOfLifePool = wayOfLifePool.Except(customCharacter.likeList[0]);
		// hobbiesPool = hobbiesPool.Except(customCharacter.likeList[1]);
		do
		{
			customCharacter.dislikeList.Clear();
			customCharacter.dislikeList.Add(wayOfLifePool[Random.Range(0, wayOfLifePool.Count-1)]);
			customCharacter.dislikeList.Add(hobbiesPool[Random.Range(0, hobbiesPool.Count-1)]);
		}
		while(customCharacter.dislikeList[0] == customCharacter.likeList[0] || customCharacter.dislikeList[1] == customCharacter.likeList[1]);
	}



	// Use this for initialization
	void Start () 
	{
		int playerToCreate;
		switch(GameManager.singleton.difficulty)
		{
			case GameManager.Difficulty.Easy: playerToCreate = 5; break;
			case GameManager.Difficulty.Normal: playerToCreate = 10; break;
			case GameManager.Difficulty.Hard: playerToCreate = 15; break;
			default: playerToCreate = 10; break;
		}
		// GameManager.singleton.
		for(var i = 0; i< playerToCreate; i++)
			CreateRandomChar();

        if (charaList != null)
        {
            GameManager.singleton.charList = charaList;
            OnCreatedCharaList();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
