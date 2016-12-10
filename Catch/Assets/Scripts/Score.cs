using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int ballValue;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
    }

    private void OnTriggerEnter2D(){
        score += ballValue;
        UpdateScore();
    }

    void UpdateScore(){
        scoreText.text = "Score:\n" + score;
    }
}
