using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurtleController : MonoBehaviour
{
    public float speedNormal;
    public float slowSpeed;
    public float upSpeed;

    public GameObject canvasAboveTurtle;
    public Text textAboveTurtle;
    public GameObject turtleBody;
    public Animator turtleAnimator;

    public InGameMenu inGameMenu;
    public PlayerMoveController playerMoveController;
    public PointController pointController;
    public TimeController timeController;
    public Animator animatorTurtle;

    public GameObject notiPopup;

    public GameObject ingameCanvas;
    public GameObject endCanvas;

    public GameObject effectFinish;
    Vector3 startPos, startEule;

    AudioSource audioSource;
    public AudioClip pointSound;
    public AudioClip wrongSound;
    public AudioClip deadSound;
    public AudioClip winSound;

    float timeSlow = 0f, timeSpeedup = 0f;
    private void Start()
    {
        audioSource = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        //audioSource.PlayOneShot(winSound);
        turtleAnimator.SetBool("swim", false);
        startPos = transform.position;
        startEule = transform.eulerAngles;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger" + other.transform.tag);
        switch (other.transform.tag)
        {
            case "bottle":
                other.transform.gameObject.SetActive(false);
                StartCoroutine(ShowCanvasAboveTurtle("-5 分"));
                MinusPoint();
                break;
            case "bird":
                BackToStartPoint();
                break;
            case "rock":
                other.transform.gameObject.SetActive(false);
                StartCoroutine(ShowCanvasAboveTurtle("-50% 速度"));
                SlowDown();
                break;
            case "seaweed":
                other.transform.gameObject.SetActive(false);
                StartCoroutine(ShowCanvasAboveTurtle("+5 分"));
                AddPoint();
                break;
            case "jellyFish":
                other.transform.gameObject.SetActive(false);
                AddPoint();
                SpeedUp();
                StartCoroutine(ShowCanvasAboveTurtle("+5 分, +50% 速度"));
                break;
            case "whale":
                BackToStartPoint();
                break;
            case "finish":
                other.transform.gameObject.SetActive(false);
                turtleAnimator.SetBool("swim", false);
                EndGame();
                break;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "sea") Swim();
    }
    void Swim(){
        turtleAnimator.SetBool("swim", true);
    }
    public void EndGame()
    {
        turtleBody.SetActive(false);
        effectFinish.SetActive(true);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        //pointController.score += (500 - timeController.timeCount);
        audioSource.PlayOneShot(winSound);
        pointController.ShowScore();
        endCanvas.SetActive(true);
        ingameCanvas.SetActive(false);
    }
    void BackToStartPoint()
    {
        inGameMenu.ResetAllItem();
        animatorTurtle.SetBool("swim", false);
        notiPopup.SetActive(true);
        transform.position = startPos;
        audioSource.PlayOneShot(deadSound);
        StartCoroutine(HideTurtle());
    }

    IEnumerator HideTurtle(){
        turtleBody.SetActive(false);
        playerMoveController.speedMovements = 0;
        yield return new WaitForSeconds(2.5f);
        turtleBody.SetActive(true);
        transform.eulerAngles = startEule;
        NormalSpeed();
    }

    IEnumerator ShowCanvasAboveTurtle(string mess){
        canvasAboveTurtle.SetActive(true);
        textAboveTurtle.text = mess;
        yield return new WaitForSeconds(1.5f);
        canvasAboveTurtle.SetActive(false);
    }
    void ResetGame()
    {

    }

    void AddPoint()
    {
        pointController.score += 5;
        audioSource.PlayOneShot(pointSound);
    }

    void MinusPoint()
    {
        pointController.score -= 5;
        audioSource.PlayOneShot(wrongSound);
    }
    void SpeedUp()
    {
        timeSpeedup = Time.time + 5f;
        audioSource.PlayOneShot(pointSound);
    }

    void SlowDown()
    {
        timeSlow = Time.time + 5f;
        audioSource.PlayOneShot(wrongSound);
    }

    void NormalSpeed()
    {
        playerMoveController.speedMovements = speedNormal;
    }

    private void Update() {
        if(timeSlow >= Time.time){
            playerMoveController.speedMovements = slowSpeed;
        }

        if(timeSpeedup >= Time.time){
            playerMoveController.speedMovements = upSpeed;
            Debug.Log("Speed up");
        }

        if(timeSlow <= Time.time && timeSpeedup <= Time.time){
            NormalSpeed();
        }
    }
}
