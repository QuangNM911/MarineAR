using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurtleController : MonoBehaviour
{
    public float speedNormal;
    public float slowSpeed;
    public float upSpeed;

    public Animator turtleAnimator;
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
        startPos = transform.position;
        startEule = transform.eulerAngles;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger" + other.transform.tag);
        switch (other.transform.tag)
        {
            case "bottle":
                other.transform.gameObject.SetActive(false);
                MinusPoint();
                break;
            case "bird":
                BackToStartPoint();
                break;
            case "rock":
                other.transform.gameObject.SetActive(false);
                SlowDown();
                break;
            case "seaweed":
                other.transform.gameObject.SetActive(false);
                AddPoint();
                break;
            case "jellyFish":
                other.transform.gameObject.SetActive(false);
                AddPoint();
                SpeedUp();
                break;
            case "whale":
                BackToStartPoint();
                break;
            case "finish":
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
    void EndGame()
    {
        effectFinish.SetActive(true);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        pointController.score += (500 - timeController.timeCount);
        audioSource.PlayOneShot(winSound);
        pointController.ShowScore();
        endCanvas.SetActive(true);
        ingameCanvas.SetActive(false);
    }
    void BackToStartPoint()
    {
        animatorTurtle.SetBool("swim", false);
        notiPopup.SetActive(true);
        transform.position = startPos;
        transform.eulerAngles = startEule;
        audioSource.PlayOneShot(deadSound);
        notiPopup.SetActive(true);
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
        pointController.score = Mathf.Max(0, pointController.score - 5);
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
        }

        if(timeSlow <= Time.time && timeSpeedup <= Time.time){
            NormalSpeed();
        }
    }
}
