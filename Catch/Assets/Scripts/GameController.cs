﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public Camera cam;
    public GameObject[] balls;
    public float forceAmount;

    public GameObject splashScreen;
    public GameObject startButton;
    public float waitBeforeGameStarts;

    //public float timeLeft;
    //public Text timerText;

    public float waitAfterSpawnMin;
    public float waitAfterSpawnMax;
    public Text scoreText;
    public Text scoreGain;

    public float showGameOverText;
    public GameObject gameOverText;
    public float showRestartButton;
    public GameObject restartButton;
    
    public HatController hatController;
    public float addPointsIfCatch;

    private float maxWidth;
    private bool playing;
    private int score;

    // Use this for initialization
    void Start(){
        if (cam == null){
            cam = Camera.main;
        }
        playing = false;
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        //UpdateText();
    }
    
    void FixedUpdate(){
        if (playing){
            int scoreInt = Convert.ToInt32(scoreText.text);
            if (scoreInt == 0)
            {
                playing = false;
            }
            /*
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0){
                timeLeft = 0;
            }
            UpdateText();
            */
        }
    }

    private void OnTriggerEnter2D()
    {
        /*
        timeLeft += addTimeIfCatch;
        UpdateText();
        */
        //Fade in and activate text
        scoreGain.gameObject.SetActive(true);
        scoreGain.text = "+" + addPointsIfCatch;
        scoreGain.GetComponent<CanvasRenderer>().SetAlpha(0f);
        scoreGain.CrossFadeAlpha(1f, .15f, false);
        //Fade out
        scoreGain.GetComponent<CanvasRenderer>().SetAlpha(1f);
        scoreGain.CrossFadeAlpha(0f, .95f, false);
    }

    public void StartGame(){
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        hatController.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    //Spawn random balls in the screen width
    IEnumerator Spawn() {
        yield return new WaitForSeconds(waitBeforeGameStarts);
        playing = true;
        while (playing){
            int scoreInt = Convert.ToInt32(scoreText.text);
            GameObject ball = balls[UnityEngine.Random.Range(0, balls.Length)];
            if(scoreInt >= 10)
            {
                ball.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            }
            if (scoreInt >= 20)
            {
                ball.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
            }
            if (scoreInt >= 30)
            {
                ball.GetComponent<Rigidbody2D>().gravityScale = 3.0f;
            }
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-maxWidth, maxWidth), transform.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(waitAfterSpawnMin, waitAfterSpawnMax));
        }
        yield return new WaitForSeconds(showGameOverText);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(showRestartButton);
        restartButton.SetActive(true);
    }

    /*
    void UpdateText(){
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
    */
}