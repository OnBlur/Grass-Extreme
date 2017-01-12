using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnContact : MonoBehaviour {
    public AudioSource source;

    public void awake()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D()
    {
        source.Play();
    }
}
