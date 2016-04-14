using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{

    
    private Slider _slider;
    public int multiplier = 10;
    bool stuffDone = false;
    // Use this for initialization
    void Start()
    {

        _slider = GetComponentInChildren<Slider>();

    }


    void OnEnable()
    {
        _slider.value = 1;
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