using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameController : MonoBehaviour
{
    public Camera cam;
    public GameObject[] fallingObjects;

    public GameObject gameNameImage;
    public GameObject splashScreen;
    public GameObject startButton;

    public Image comboBalk;
    public Image itemOneImage;
    public Image itemTwoImage;
    public Image itemThreeImage;

    public GameObject highscore;
    public GameObject Achievements;
    public GameObject Leaderboard;
    public float waitBeforeGameStarts;

    //public float timeLeft;
    //public Text timerText;

    public float waitAfterSpawnMin;
    public float waitAfterSpawnMax;
    public Text scoreText;

    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject AudioButtonOn;
    public GameObject AudioButtonOff;

    public PlayerController playerController;

	public AudioSource SoundToPlay;
	public float Volume;
	public bool alreadyPlayed = false;

    private float maxWidth;
    private bool playing;
    private int score;


    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
		SoundToPlay = GetComponent<AudioSource> ();
        playing = false;
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = fallingObjects[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        //UpdateText();
    }

    void FixedUpdate()
    {
		if (playing)
        {
            int scoreInt = Convert.ToInt32(scoreText.text);
            if (scoreInt < 0)
            {
                scoreText.text = "0";
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        timeLeft += addTimeIfCatch;
        UpdateText();
        */
    }

    public void StartGame()
    {
        gameNameImage.SetActive(false);
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        AudioButtonOn.SetActive(false);
        AudioButtonOff.SetActive(false);
        highscore.SetActive(false);
        Achievements.SetActive(false);
        Leaderboard.SetActive(false);

        comboBalk.gameObject.SetActive(true);
        itemOneImage.gameObject.SetActive(true);
        itemTwoImage.gameObject.SetActive(true);
        itemThreeImage.gameObject.SetActive(true);

        playerController.ToggleControl(true);
        scoreText.gameObject.SetActive(true);
        StartCoroutine(Spawn());
    }

    //Spawn random balls in the screen width
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(waitBeforeGameStarts);
        playing = true;
        while (playing)
        {
            int scoreInt = Convert.ToInt32(scoreText.text);
            GameObject fallingObject = fallingObjects[UnityEngine.Random.Range(0, fallingObjects.Length)];
			if (scoreInt < 5) {
				fallingObject.GetComponent<Rigidbody2D> ().gravityScale = 0.2f;
			} 

			else if (scoreInt >= 10 && scoreInt < 20) 
			{
				if (scoreInt == 10)
                {
					if (alreadyPlayed == false)
                    {
						alreadyPlayed = true;
						SoundToPlay.Play();
                    }
                }

				fallingObject.GetComponent<Rigidbody2D> ().gravityScale = 0.4f;
				Social.ReportProgress ("CgkIqaSYpNwIEAIQAQ", 100.0f, (bool success) => {
					// handle success or failure
				});
			}
            else if (scoreInt >= 20 && scoreInt < 30)
            {
				if (scoreInt == 20)
                {
					if (alreadyPlayed == true)
                    {
						SoundToPlay.Play();
						alreadyPlayed = false;
                    }
			    }

                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 0.6f;
                Social.ReportProgress("CgkIqaSYpNwIEAIQAg", 100.0f, (bool success) => {
                    // handle success or failure
                });
				alreadyPlayed = false;
            }
            else if (scoreInt >= 30 && scoreInt < 40)
            {
				if (scoreInt == 30)
                {
					if (alreadyPlayed == false)
                    {
						SoundToPlay.Play();
						alreadyPlayed = true;
                    }
				}

                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 0.8f;
                Social.ReportProgress("CgkIqaSYpNwIEAIQAw", 100.0f, (bool success) => {
                    // handle success or failure
                });
            }
            else if (scoreInt >= 40 && scoreInt < 50)
			{
				if (scoreInt == 40)
                {
					if (alreadyPlayed == true)
                    {
						SoundToPlay.Play();
						alreadyPlayed = false;
                    }
				}

                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                Social.ReportProgress("CgkIqaSYpNwIEAIQBA", 100.0f, (bool success) => {
                    // handle success or failure
                });

				alreadyPlayed = false;
            }
            else if (scoreInt >= 50 && scoreInt < 60)
            {
				if (scoreInt == 50)
                {
					if (alreadyPlayed == false)
                    {
						SoundToPlay.Play();
						alreadyPlayed = true;
                    }
				}

                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 1.2f;
                Social.ReportProgress("CgkIqaSYpNwIEAIQBQ", 100.0f, (bool success) => {
                    // handle success or failure
                });
            }
            else if (scoreInt >= 60 && scoreInt < 70)
            {
				if (scoreInt == 60)
                {
					if (alreadyPlayed == true)
                    {
						SoundToPlay.Play();
						alreadyPlayed = false;
                    }
				}

                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 1.4f;
            }

            else if (scoreInt >= 70 && scoreInt < 80)
            {
                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 1.6f;
            }
            else if (scoreInt >= 80 && scoreInt < 90)
            {
                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 1.8f;
            }
            else if (scoreInt >= 90 && scoreInt < 100)
            {
                fallingObject.GetComponent<Rigidbody2D>().gravityScale = 2.0f;
            }
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-maxWidth, maxWidth), transform.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(fallingObject, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(waitAfterSpawnMin, waitAfterSpawnMax));
        }
        playerController.ToggleControl(false);
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
    }

    /*
    void UpdateText(){
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
    */
}


