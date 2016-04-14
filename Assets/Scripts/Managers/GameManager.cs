using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager singleton;
    public GameObject currentChar;

    public bool MEC = false;
    public bool MEUF;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    public Difficulty difficulty = Difficulty.Normal;

    void Awake()
    {
        if (singleton != null)
            Destroy(singleton.gameObject);

        singleton = this as GameManager;
    }

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
