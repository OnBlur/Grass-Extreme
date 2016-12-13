﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int ballValue;
    public int bombValue;

    private int score;

    // Use this for initialization
    void Start () {
        score = 1;
        UpdateScore();
    }

    private void OnTriggerEnter2D(){
        score += ballValue;
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Bomb"){
            score -= score;
            UpdateScore();
        }
    }

    void UpdateScore(){
        scoreText.text = "" + score;
    }
}
