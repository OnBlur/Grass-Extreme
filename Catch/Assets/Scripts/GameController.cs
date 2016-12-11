﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public Camera cam;
    public GameObject[] balls;

    public GameObject splashScreen;
    public GameObject startButton;
    public float waitBeforeGameStarts;

    public float timeLeft;
    public Text timerText;

    public float waitAfterSpawnMin;
    public float waitAfterSpawnMax;
    public Text scoreGain;

    public float showGameOverText;
    public GameObject gameOverText;
    public float showRestartButton;
    public GameObject restartButton;
    
    public HatController hatController;
    public float addTimeIfCatch;

    private float maxWidth;
    private bool playing;

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
        UpdateText();
    }

    void FixedUpdate(){
        if (playing){
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0){
                timeLeft = 0;
            }
            UpdateText();
        }
    }

    private void OnTriggerEnter2D()
    {
        timeLeft += addTimeIfCatch;
        UpdateText();
        //Fade in and activate text
        scoreGain.gameObject.SetActive(true);
        scoreGain.text = "+" +addTimeIfCatch + " Sec";
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
        while(timeLeft > 0){
            GameObject ball = balls[Random.Range(0, balls.Length)];
            Vector2 spawnPosition = new Vector2(Random.Range(-maxWidth, maxWidth), transform.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(waitAfterSpawnMin, waitAfterSpawnMax));
        }
        yield return new WaitForSeconds(showGameOverText);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(showRestartButton);
        restartButton.SetActive(true);
    }

    void UpdateText(){
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
}
