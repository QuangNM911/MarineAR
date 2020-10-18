using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    public GameObject[] listGameObjectNeedActive;
    public GameObject[] listGameObectNeedDisable;

    public GameObject delayCanvas;
    public PointController pointController;

    public TimeController timeController;

    public SimpleTouchController simpleTouchController;
    public GameObject turtle;
    public GameObject turtleBody;

    public Transform turtleFirstPos;
    Vector3 turtlePos,turtleEules;

    private void Start() {
        turtlePos = turtle.transform.position;
        turtleEules = turtle.transform.eulerAngles;
    }
    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void Replay(){
        Debug.Log("RePlay");
        turtle.GetComponent<Animator>().SetBool("swim", false);
        simpleTouchController.EndDrag();
        delayCanvas.SetActive(true);
        foreach(GameObject go in listGameObectNeedDisable){
            go.SetActive(false);
        }
        foreach(GameObject go in listGameObjectNeedActive){
            go.SetActive(true);
        }
        turtle.SetActive(true);
        turtleBody.SetActive(true);
        turtle.transform.position = turtleFirstPos.position;
        turtle.transform.eulerAngles = turtleEules;
        turtle.GetComponent<Rigidbody>().useGravity = true;
        pointController.ResetGame();
        timeController.ResetGame();
    }

    public void ResetAllItem(){
        Debug.Log("Reset");
        simpleTouchController.EndDrag();
        foreach(GameObject go in listGameObjectNeedActive){
            if(go == listGameObjectNeedActive[3] || go == listGameObjectNeedActive[4] || go == listGameObjectNeedActive[0]) continue;
            go.SetActive(true);
        }
        turtle.SetActive(true);
        turtleBody.SetActive(true);
        turtle.transform.position = turtleFirstPos.position;
        turtle.transform.eulerAngles = turtleEules;
        turtle.GetComponent<Rigidbody>().useGravity = true;
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
