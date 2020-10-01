﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    public int totalTime;
    public Text minText, secondText;
    int min,second;

    int timeCount = 0;
    float timeNow = 0;
    // Start is called before the first frame update
    void Start()
    { 
        min = totalTime/60;
        second = totalTime%60;
        minText.text = "" + min;
        secondText.text = "" + second;
        IncreaseClock();
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        if(timeNow >= timeCount +1){
            timeCount++;
            IncreaseClock();
        }
    }

    void ResetGame(){
        Debug.Log("EndGame");
        min = second = timeCount = 0;
        timeNow = 0f;
    }

    void IncreaseClock(){
        if(second == 0){
            second = 60;
            min--;
        }
        second--;
        secondText.text = second > 9 ? "" + second : "0" + second;
        minText.text = min > 9 ? "" + min : "0" + min;
    }
}
