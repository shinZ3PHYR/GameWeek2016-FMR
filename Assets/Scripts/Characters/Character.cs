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

	public Transform charaPos;
	[SerializeField]
	private AnimationCurve scaleCurve;
	[SerializeField]
	private AnimationCurve scaleCurveBis;

	public Sprite faceShape;
	public Sprite eyes;
	public Sprite mouth;
	public Sprite nose;
	public Sprite hairCut;
	public Sprite accessory;
	public Color eyesColor;

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

	}

	public void EraseChar()
	{
		transform.GetChild(0).GetComponent<Image>().sprite = faceShape;
		transform.GetChild(1).GetComponent<Image>().sprite = null; //eyes

		transform.GetChild(3).GetComponent<Image>().sprite = nose;
		transform.GetChild(4).GetComponent<Image>().sprite = null; //hairCut
		transform.GetChild(5).GetComponent<Image>().sprite = null; //Dress
		transform.GetChild(6).GetComponent<Image>().sprite = null; //ForeArm
	}

	public void DrawNeutralChar()
	{
		transform.GetChild(0).GetComponent<Image>().sprite = faceShape;
		transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes
		transform.GetChild(1).GetComponent<Image>().color = eyesColor;
		transform.GetChild(2).GetComponent<Image>().sprite = neutralSet[1]; //mouth
		transform.GetChild(3).GetComponent<Image>().sprite = nose;
		transform.GetChild(4).GetComponent<Image>().sprite = neutralSet[2]; //hairCut
		transform.GetChild(5).GetComponent<Image>().sprite = neutralSet[3]; //Dress
		transform.GetChild(6).GetComponent<Image>().sprite = neutralSet[4]; //ForeArm

		Appear();
	}

	IEnumerator TweenTranslate(float scaleTime)
	{
		float elapsedTime = 0;
		while(elapsedTime < scaleTime)// && AllowFX
		{
			Debug.Log("dayum");
			float scaleRatio = scaleCurve.Evaluate(elapsedTime /scaleTime);
			transform.Translate(0, scaleRatio * 20f, 0);
			elapsedTime+= Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator TweenFlip(float scaleTime)
	{
		float elapsedTime = 0;
		while(elapsedTime < scaleTime)// && AllowFX
		{
			Debug.Log("dayum");
			float scaleRatio = scaleCurveBis.Evaluate(elapsedTime /scaleTime);
			transform.localScale = new Vector3(scaleRatio, transform.localScale.y, transform.localScale.z);
			elapsedTime+= Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator TweenFade(float fadeTime)
	{
		float elapsedTime = 0;
		// while(uiImage.color.a < 1)
		// {
		// 	float fadeRatio = elapsedTime / fadeTime;
		// 	color= new Color(1,1,1, fadeRatio);
		// 	elapsedTime+= Time.deltaTime;
			yield return null;
		// }
	}

	public void Appear()
	{
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		StartCoroutine(TweenTranslate(1f));
	}

	public void Flip()
	{
		StartCoroutine(TweenFlip(.5f));
	}

	public void Fade()
	{
		StartCoroutine(TweenFade(.5f));
	}

	public void Randomize()
	{	
		Mood randMood = (Mood)Random.Range(0, 5);
		ChangeMood(randMood);
		currentMood = randMood;
	}

	public void SpawnParticles()
	{
		
	}

	public void ChangeMood(Mood mood)
	{	
		EraseChar();
		switch(mood)
		{
			case Mood.Neutral:

				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes
				transform.GetChild(1).GetComponent<Image>().color = eyesColor;
				transform.GetChild(2).GetComponent<Image>().sprite = neutralSet[1]; //mouth
				transform.GetChild(6).GetComponent<Image>().sprite = neutralSet[4]; //ForeArm
				break;
			case Mood.VeryHappy:
				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes PLACEHOLDER
				transform.GetChild(1).GetComponent<Image>().color = eyesColor;
				// transform.GetChild(1).GetComponent<Image>().sprite = veryHappySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = veryHappySet[0]; //mouth
				// transform.GetChild(6).GetComponent<Image>().sprite = veryHappySet[2]; //ForeArm
				break;
			case Mood.Happy:
				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes PLACEHOLDER
				transform.GetChild(1).GetComponent<Image>().color = eyesColor;
				// transform.GetChild(1).GetComponent<Image>().sprite = happySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = happySet[0]; //mouth
				// transform.GetChild(6).GetComponent<Image>().sprite = happySet[2]; //ForeArm
				break;
			case Mood.VeryAngry:
				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes PLACEHOLDER
				transform.GetChild(1).GetComponent<Image>().color = eyesColor;
				// transform.GetChild(1).GetComponent<Image>().sprite = veryAngrySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = veryAngrySet[0]; //mouth
				// transform.GetChild(6).GetComponent<Image>().sprite = veryAngrySet[2]; //ForeArm
				break;
			case Mood.Angry:
				transform.GetChild(1).GetComponent<Image>().sprite = neutralSet[0]; //eyes PLACEHOLDER
				transform.GetChild(1).GetComponent<Image>().color = eyesColor;
				// transform.GetChild(1).GetComponent<Image>().sprite = angrySet[0]; //eyes
				transform.GetChild(2).GetComponent<Image>().sprite = angrySet[0]; //mouth
				// transform.GetChild(6).GetComponent<Image>().sprite = angrySet[2]; //ForeArm
				break;
		}
	}
	// Update is called once per frame
	void Update () {
		ChangeMood(currentMood);
	}
}
