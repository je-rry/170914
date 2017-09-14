﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	private bool tap, swipeLeft, swipeRight;
	private bool isDraging = false;
	private Vector2 startTouch, swipeDelta;

	void Update () {
		tap = swipeLeft = swipeRight = false;

		// Standalone Inputs
		if (Input.GetMouseButtonDown(0)) {
			tap = true;
			isDraging = true;
			startTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0)){
			Reset();
		}

		// Mobile Inputs
		if (Input.touches.Length > 0) {
			// first touch
			if (Input.touches[0].phase == TouchPhase.Began){
				tap = true;
				isDraging = true;
				startTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
				Reset();
			}
		}

		// Calculate the distance
		swipeDelta = Vector2.zero;

		if(isDraging) {
			if (Input.touches.Length > 0)
				swipeDelta = Input.touches[0].position - startTouch;
			else if (Input.GetMouseButton(0))
				swipeDelta = (Vector2)Input.mousePosition - startTouch;

		}

		// cross the deadzone
		if (swipeDelta.magnitude > 125) {

			// direction
			float x = swipeDelta.x;
			float y = swipeDelta.y;

			// left or right
			if (Mathf.Abs(x) > Mathf.Abs(y)) {
				if (x < 0)
					swipeLeft = true;
				else
					swipeRight = true;
			}

			Reset();
		}
	}

	void Reset () {
		startTouch = swipeDelta = Vector2.zero;
		isDraging = false;
	}

	public Vector2 SwipeDelta { get { return swipeDelta; } }
	public bool SwipeLeft { get { return swipeLeft; } }
	public bool SwipeRight { get { return swipeRight; } }
}
