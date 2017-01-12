using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ClickAudio : MonoBehaviour {
	public AudioSource mySource;

	// Update is called once per frame
	public void playAudio (AudioClip x) {
		mySource = GetComponent<AudioSource> ();
		mySource.PlayOneShot (x);
	}
}
