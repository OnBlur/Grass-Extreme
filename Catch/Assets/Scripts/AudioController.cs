using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    public bool audioToggle;

    private void Start()
    {
        if (audioToggle = GetComponent<AudioSource>().gameObject.activeSelf)
        {
            Debug.Log(audioToggle);
        }
    }

    public void AudioToggle()
    {
        if (audioToggle)
        {
            AudioListener.pause = true;
            audioToggle = false;
            Debug.Log("Muziek is UIT");
        }
        else
        {
            AudioListener.pause = false;
            audioToggle = true;
            Debug.Log("Muziek is AAN");
        }
    }
}
