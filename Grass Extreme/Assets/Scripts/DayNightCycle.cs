using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    private Light thisLight;

    public float transition;
    public float transitionSpeed;

    private bool sunrise;

    private void Start()
    {
        thisLight = GetComponent<Light>();
    }

    void Update() {
        transition += (sunrise) ? transitionSpeed * Time.deltaTime : -transitionSpeed * Time.deltaTime;
        if (transition < 0.0f || transition > 1.5f)
            sunrise = !sunrise;
        thisLight.intensity = transition;
        thisLight.color = Color.Lerp(Color.blue, Color.white, transition);
	}
}
