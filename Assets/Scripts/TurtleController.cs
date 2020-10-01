﻿using System.Collections;
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
    public Animator animatorTurtle;
    Vector3 startPos, startEule;

    public AudioSource audioSource;
    public AudioClip pointSound;
    public AudioClip wrongSound;
    public AudioClip deadSound;
    public AudioClip winSound;

    private void Start()
    {
        startPos = transform.position;
        startEule = transform.eulerAngles;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger" + other.transform.tag);
        switch (other.transform.tag)
        {
            case "bottle":

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
                AddPoint();
                break;
            case "jellyFish":
                AddPoint();
                SpeedUp();
                break;
            case "whale":
                ResetGame();
                break;
            case "finish":
                EndGame();
                break;
            case "sea":
                Swim();
                break;
        }
    }

    void Swim(){
        turtleAnimator.SetBool("swim", true);
    }
    void EndGame()
    {
        audioSource.PlayOneShot(winSound);
    }
    void BackToStartPoint()
    {
        transform.position = startPos;
        transform.eulerAngles = startEule;
        audioSource.PlayOneShot(deadSound);
    }

    void ResetGame()
    {

    }

    void AddPoint()
    {
        pointController.point += 5;
        audioSource.PlayOneShot(pointSound);
    }

    void MinusPoint()
    {
        pointController.point = Mathf.Max(0, pointController.point - 5);
        audioSource.PlayOneShot(wrongSound);
    }
    void SpeedUp()
    {
        playerMoveController.speedMovements = upSpeed;
        audioSource.PlayOneShot(pointSound);
    }

    void SlowDown()
    {
        playerMoveController.speedMovements = slowSpeed;
        audioSource.PlayOneShot(wrongSound);
    }

    void NormalSpeed()
    {
        playerMoveController.speedMovements = speedNormal;
    }
}
