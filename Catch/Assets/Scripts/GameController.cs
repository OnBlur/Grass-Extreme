using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour{

    public Camera cam;
    public GameObject ball;
    public float timeLeft;

    public float waitBeforeGameStarts;
    public float waitAfterSpawnMin;
    public float waitAfterSpawnMax;

    public Text timerText;
    public float showGameOverText;
    public GameObject gameOverText;
    public float showRestartButton;
    public GameObject restartButton;

    private float maxWidth;

    // Use this for initialization
    void Start(){
        if (cam == null){
            cam = Camera.main;
        }
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        StartCoroutine(Spawn());
        UpdateText();
    }

    void FixedUpdate(){
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0){
            timeLeft = 0;
        }
        UpdateText();
    }

    //Spawn random balls in the screen width
    IEnumerator Spawn() {
        yield return new WaitForSeconds(waitBeforeGameStarts);
        while(timeLeft > 0){
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
