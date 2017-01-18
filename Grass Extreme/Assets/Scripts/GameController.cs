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
    public string[] AchievementsScore;

    public GameObject gameNameImage;
    public GameObject splashScreen;
    public GameObject startButton;

    public Image howToPlayImage;
    public Image comboBalk;
    public Image itemOneImage;
    public Image itemTwoImage;
    public Image itemThreeImage;

    public GameObject highscore;
    public GameObject Achievements;
    public GameObject Leaderboard;
    public float waitBeforeGameStarts;
    
    public float waitAfterSpawnMin;
    public float waitAfterSpawnMax;
    public Text scoreText;

    public GameObject gameOverImage;
    public Text finalScore;
    public GameObject restartButton;
    public GameObject AudioButtonOn;
    public GameObject AudioButtonOff;

    public PlayerController playerController;

	public AudioSource SoundToPlay;
	public float Volume;
	public bool alreadyPlayed = false;

    private float maxWidth;
    private bool playing;
    private int scoreInt;
    private int score;
    private float gravityScaling = 0.2f;
    private int minScore = 10;
    private int maxScore = 20;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        for(int i = 0; i < fallingObjects.Length; i++)
        {
            fallingObjects[i].GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
		SoundToPlay = GetComponent<AudioSource> ();
        playing = false;
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float insectWidth = fallingObjects[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - insectWidth;
    }

    void FixedUpdate()
    {
		if (playing)
        {
            scoreInt = Convert.ToInt32(scoreText.text);
            if (scoreInt < 0)
            {
                scoreText.text = "0";
                playing = false;
            }
            else if(scoreInt > score)
            {
                score = scoreInt;
            }
        }
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

        howToPlayImage.gameObject.SetActive(true);
        comboBalk.gameObject.SetActive(true);
        itemOneImage.gameObject.SetActive(true);
        itemTwoImage.gameObject.SetActive(true);
        itemThreeImage.gameObject.SetActive(true);

        playerController.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    //Spawn random insects in the screen width
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(waitBeforeGameStarts);
        howToPlayImage.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        playing = true;
        
        while (playing)
        {
            int i = 0;
            int scoreInt = Convert.ToInt32(scoreText.text);
            GameObject fallingObject = fallingObjects[UnityEngine.Random.Range(0, fallingObjects.Length)];

            if (scoreInt >= minScore && scoreInt < maxScore)
            {
                // Play sound if scoreInt is the same as minScore
                if (scoreInt == minScore)
                {
                    if (alreadyPlayed == false)
                    {
                        alreadyPlayed = true;
                        SoundToPlay.Play();
                    }
                }
                // Give new gravity to the fallingObject
                for(int x = 0; x < fallingObjects.Length; x++)
                {
                    fallingObjects[x].GetComponent<Rigidbody2D>().gravityScale = gravityScaling;
                }
                
                gravityScaling += 0.2f;
                minScore += 10;
                maxScore += 10;

                Social.ReportProgress(AchievementsScore[i], 100.0f, (bool success) => {
                    i++;
                });
            }
            Vector2 spawnPosition = new Vector2(UnityEngine.Random.Range(-maxWidth, maxWidth), transform.position.y);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(fallingObject, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(UnityEngine.Random.Range(waitAfterSpawnMin, waitAfterSpawnMax));
        }
        playerController.ToggleControl(false);
        gameOverImage.SetActive(true);
        finalScore.text = Convert.ToString(score);
        finalScore.gameObject.SetActive(true);
        restartButton.SetActive(true);
    }
}


