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

    public Transform turtleFirstTrans;

    public GameObject effectFinish;
    Vector3 startPos, startEule;

    AudioSource audioSource;
    public AudioClip pointSound;
    public AudioClip wrongSound;
    public AudioClip deadSound;
    public AudioClip winSound;

    float timeSlow = 0f, timeSpeedup = 0f, timeSlowTriggerRock = 0f;
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
                StartCoroutine(ShowCanvasAboveTurtle("-20% 速度"));
                SlowDown();
                break;
            case "seaweed":
                other.transform.gameObject.SetActive(false);
                StartCoroutine(ShowCanvasAboveTurtle("+5 分"));
                AddPoint();
                break;
            case "jellyFish":
                StartCoroutine(RebornJellyFish(other.gameObject));
                AddPoint();
                SpeedUp();
                StartCoroutine(ShowCanvasAboveTurtle("+5 分, +30% 速度"));
                break;
            case "whale":
                BackToStartPoint();
                turtleAnimator.SetBool("swim", false);
                break;
            case "finish":
                other.transform.gameObject.SetActive(false);
                turtleAnimator.SetBool("swim", false);
                EndGame();
                break;
        }
    }

    IEnumerator RebornJellyFish(GameObject jellyFish){
        jellyFish.gameObject.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1.5f,2f));
        jellyFish.gameObject.SetActive(true);
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
        GetComponent<Rigidbody>().useGravity = false;
        audioSource.PlayOneShot(winSound);
        pointController.ShowScore();
        endCanvas.SetActive(true);
        ingameCanvas.SetActive(false);
    }
    void BackToStartPoint()
    {
        Debug.Log("BackToStart");
        GetComponent<Rigidbody>().useGravity = false;
        inGameMenu.ResetAllItem();
        animatorTurtle.SetBool("swim", false);
        notiPopup.SetActive(true);
        transform.position = turtleFirstTrans.position;
        audioSource.PlayOneShot(deadSound);
        playerMoveController.speedMovements = 0;
        StartCoroutine(HideTurtle());
    }

    IEnumerator HideTurtle(){
        turtleBody.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        turtleBody.SetActive(true);
        transform.eulerAngles = startEule;
        NormalSpeed();
        GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator ShowCanvasAboveTurtle(string mess){
        canvasAboveTurtle.SetActive(true);
        textAboveTurtle.text = mess;
        yield return new WaitForSeconds(1.5f);
        canvasAboveTurtle.SetActive(false);
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
        timeSlow = Time.time + 3f;
        audioSource.PlayOneShot(wrongSound);
    }
    void NormalSpeed()
    {
        Debug.Log("Normal Speed");
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

        if(timeSlow <= Time.time && timeSpeedup <= Time.time && playerMoveController.speedMovements != 0){
            NormalSpeed();
        }
    }
}
