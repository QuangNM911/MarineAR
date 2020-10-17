using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeController : MonoBehaviour
{
    public int totalTime;
    public Text minText, secondText;

    public TurtleController turtleController;
    int min,second;

    public int timeCount;
    float timeNow = 0;
    // Start is called before the first frame update
    void OnEnable()
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

    public void ResetGame(){
        Debug.Log("EndGame");
        timeCount = 0;
        min = totalTime/60;
        second = totalTime%60;
        timeNow = 0f;
        minText.text = "00";
        secondText.text = "00";
    }

    void IncreaseClock(){
        if(second == 0){
            second = 60;
            min--;
        }
        second--;
        if(second==0 && min == 0){
            Debug.Log("End game");
            turtleController.EndGame();
        }
        secondText.text = second > 9 ? "" + second : "0" + second;
        minText.text = min > 9 ? "" + min : "0" + min;
    }
}
