using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButtonPress : MonoBehaviour {
    
    public bool audioEnabler;

    private void Start()
    {
        if (audioEnabler = GetComponent<AudioSource>().gameObject.activeSelf)
        {
            Debug.Log(audioEnabler);
        }
    }

    public void OnMouseDown()
    {
        if (audioEnabler)
        {
            AudioListener.pause = true;
            Debug.Log("UIT");
        }
        else
        {
            AudioListener.pause = false;
            Debug.Log("AAN");
        }
    }
}
