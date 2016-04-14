using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    float timeLeft = 3;
    private Slider _slider;
    public int multiplier = 10;
    bool stuffDone = false;
    // Use this for initialization
    void Start()
    {

        _slider = GetComponentInChildren<Slider>();

    }




    // Update is called once per frame
    void Update()
    {

        if (_slider.value >= 0) _slider.value -= Time.deltaTime / multiplier;


        if (_slider.value == 0 && stuffDone == false) DoStuff();
    }



    void DoStuff()
    {
        stuffDone = true;
        Debug.Log(_slider.value);
        
    }

}