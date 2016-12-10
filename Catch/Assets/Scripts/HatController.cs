using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {

    public Camera cam;

    private float maxWidth;

	// Use this for initialization
	void Start () {
		if(cam == null)
        {
            cam = Camera.main;
        }
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
    }
	
	// Update is called once per physics timestamp
	void FixedUpdate () {
        Vector2 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = new Vector2(rawPosition.x, 0.0f);

        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector2(targetWidth, targetPosition.y);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }
}
