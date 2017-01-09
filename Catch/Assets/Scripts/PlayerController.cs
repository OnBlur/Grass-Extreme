using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    private float maxWidth;
    private bool canControl;

	// Use this for initialization
	void Start () {
		if(cam == null){
            cam = Camera.main;
        }
        canControl = false;
        Vector2 upperCorner = new Vector2(Screen.width, Screen.height);
        Vector2 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
    }
	
	// Update is called once per physics timestamp
	void FixedUpdate () {
        //If we can control hat
        if (canControl){
            Vector2 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPosition = new Vector2(rawPosition.x, transform.position.y);

            float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
            targetPosition = new Vector2(targetWidth, targetPosition.y);
            GetComponent<Rigidbody2D>().MovePosition(targetPosition);
        } 
    }

    public void ToggleControl(bool toggle){
        canControl = toggle;
    }
}
