using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    public GameObject[] listGameObjectNeedActive;
    public GameObject[] listGameObectNeedDisable;

    public PointController pointController;

    public TimeController timeController;

    public SimpleTouchController simpleTouchController;
    public GameObject turtle;
    public GameObject turtleBody;
    Vector3 turtlePos,turtleEules;

    private void Start() {
        turtlePos = turtle.transform.position;
        turtleEules = turtle.transform.eulerAngles;
    }
    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void Replay(){
        simpleTouchController.EndDrag();
        foreach(GameObject go in listGameObectNeedDisable){
            go.SetActive(false);
        }
        foreach(GameObject go in listGameObjectNeedActive){
            go.SetActive(true);
        }
        turtle.SetActive(true);
        turtleBody.SetActive(true);
        turtle.transform.position = turtlePos;
        turtle.transform.eulerAngles = turtleEules;
        pointController.ResetGame();
        timeController.ResetGame();
        Debug.Log("RePlay");
        //SceneManager.LoadScene(1);
    }

    public void QuitApp(){
        Application.Quit();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Replay();
        }
    }
}
