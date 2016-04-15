using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{

    public delegate void TimerAction();
    public static event TimerAction OnTimerEnd;

    private Slider _slider;
    public int multiplier = 10;
    bool stuffDone = false;
    private bool launch;
    // Use this for initialization
    void Start()
    {

        _slider = GetComponentInChildren<Slider>();
        DialogueManager.OnReturnArguments += LaunchTimer;
    }


    void OnEnable()
    {
        _slider.value = 1;
        stuffDone = false;
        launch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(launch)
        {
            if (_slider.value >= 0) _slider.value -= Time.deltaTime / multiplier;

            if (_slider.value == 0 && stuffDone == false) DoStuff();
        }
        
    }

    void LaunchTimer(List<string> uselessListOfString)
    {
        launch = true;
    }

    void DoStuff()
    {
        stuffDone = true;
        OnTimerEnd();
        Debug.Log(_slider.value);
        
    }

}