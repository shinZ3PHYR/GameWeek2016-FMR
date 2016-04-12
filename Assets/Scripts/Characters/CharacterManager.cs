using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Random;

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

	public List<Sprite> eyesPool;
	public List<Sprite> mouthesPool;
	public List<Sprite> hairCutPool;
	public List<Sprite> dressPool;
	public List<Sprite> accessoryPool;
	public List<string> namePool;

	public List<Sprite> moodPool;

	// public List<Character> charaList;

	// public Character customCharacter;

	public void CreateRandomChar()
	{
		// customCharacter = new Character();
		Sprite customCharacterEyes = eyesPool[Random.Range(0, eyesPool.Count-1)];
		Sprite customCharacterMouth = mouthesPool[Random.Range(0, mouthesPool.Count-1)];
		Sprite customCharacterHairCut = hairCutPool[Random.Range(0, hairCutPool.Count-1)];
		Sprite customCharacterDress = dressPool[Random.Range(0, dressPool.Count-1)];


	}

	public void GetAssociatedSet(){}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
