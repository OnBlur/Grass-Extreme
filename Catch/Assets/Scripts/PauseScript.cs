using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public bool paused;
    public Text pauseText;

    // Use this for initialization
    void Start()
    {
        paused = false;
    }

    public void Pause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            pauseText.gameObject.SetActive(true);
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
        }
    }
}