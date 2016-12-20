using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public bool audioToggle;
    AudioSource audioCon;
    public CanvasRenderer audioOn;
    public CanvasRenderer audioOff;

    private void Start()
    {
        audioCon = GetComponent<AudioSource>();
        Debug.Log("audioCon is: " + audioCon.isPlaying);

        if (audioCon.isPlaying && audioToggle)
        {
            audioOn.gameObject.SetActive(true);
            audioOff.gameObject.SetActive(false);
            audioCon.Play();
        }
        else
        {
            audioOn.gameObject.SetActive(false);
            audioOff.gameObject.SetActive(true);
            audioCon.Play();
        }
    }

    public void AudioToggle()
    {
        if (audioCon.isPlaying)
        {
            audioToggle = true;
            audioOn.gameObject.SetActive(false);
            audioOff.gameObject.SetActive(true);
            audioCon.Pause();
            Debug.Log("Muziek is UIT");
        }
        else
        {
            audioToggle = false;
            audioOn.gameObject.SetActive(true);
            audioOff.gameObject.SetActive(false);
            audioCon.UnPause();
            Debug.Log("Muziek is AAN");
        }
    }
}
