using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Text highscoreText;
    public Image starLeft;
    public Image starRight;
    public Text scoreGain;

    public int catchValue;
    //public int bombValue;

    private int score;
    private int highscore;

    // Use this for initialization
    void Start () {
        // PlayerPrefs.DeleteAll();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highscoreText.text = highscore.ToString();
        score = 0;
        UpdateScore();
    }

    private void OnTriggerEnter2D(){
        scoreGain.gameObject.SetActive(true);
        scoreGain.text = "+" + catchValue;
        scoreGain.GetComponent<CanvasRenderer>().SetAlpha(0f);
        scoreGain.CrossFadeAlpha(1f, .15f, false);
        //Fade out
        scoreGain.GetComponent<CanvasRenderer>().SetAlpha(1f);
        scoreGain.CrossFadeAlpha(0f, .95f, false);

        score += catchValue;
        SaveHighScore();
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Enemy"){
            score = -1;
            UpdateScore();
        }
    }

    void UpdateScore(){
        scoreText.text = "" + score;
    }

    void SaveHighScore()
    {
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);

            Social.ReportScore(highscore, "CgkIqaSYpNwIEAIQBg", (bool success) => {
                // handle success or failure
            });

            highscoreText.gameObject.SetActive(true);
            highscoreText.GetComponent<CanvasRenderer>().SetAlpha(0f);
            highscoreText.CrossFadeAlpha(1f, .15f, false);
            //Fade out
            highscoreText.GetComponent<CanvasRenderer>().SetAlpha(1f);
            highscoreText.CrossFadeAlpha(0f, .95f, false);

            starLeft.gameObject.SetActive(true);
            starLeft.GetComponent<CanvasRenderer>().SetAlpha(0f);
            starLeft.CrossFadeColor(Color.red, 1f, false, true);
            //Fade out
            starLeft.GetComponent<CanvasRenderer>().SetAlpha(1f);
            starLeft.CrossFadeAlpha(0f, .95f, false);

            starRight.gameObject.SetActive(true);
            starRight.GetComponent<CanvasRenderer>().SetAlpha(0f);
            starRight.CrossFadeColor(Color.red, 1f, false, true);
            //Fade out
            starRight.GetComponent<CanvasRenderer>().SetAlpha(1f);
            starRight.CrossFadeAlpha(0f, .95f, false);
        }
    }
}
