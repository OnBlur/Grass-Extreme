using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    public bool audioToggle;
    public CanvasRenderer audioOn;
    public CanvasRenderer audioOff;


    private void Start()
    {
        if (audioToggle = GetComponent<AudioSource>().gameObject.activeSelf)
        {
            Debug.Log("Audio is: " + audioToggle);
            audioOn.gameObject.SetActive(true);
        }
    }

    public void AudioToggle()
    {
        if (audioToggle)
        {
            audioOn.gameObject.SetActive(false);
            audioOff.gameObject.SetActive(true);
            AudioListener.pause = true;
            audioToggle = false;
            Debug.Log("Muziek is UIT");
        }
        else
        {
            audioOff.gameObject.SetActive(false);
            audioOn.gameObject.SetActive(true);
            AudioListener.pause = false;
            audioToggle = true;
            Debug.Log("Muziek is AAN");
        }
    }
}
