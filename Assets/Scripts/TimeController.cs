using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    //public int totalTime;
    public PointController pointController;
    public Text minText, secondText;
    int min,second;

    public int timeCount = 0;
    float timeNow = 0;
    // Start is called before the first frame update
    void Start()
    { 
        min = second = 0;
        minText.text = "00";
        secondText.text = "00";
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
        pointController.score--;
        if(second == 60){
            second = 0;
            min++;
        }
        second++;
        secondText.text = second > 9 ? "" + second : "0" + second;
        minText.text = min > 9 ? "" + min : "0" + min;
    }
}
