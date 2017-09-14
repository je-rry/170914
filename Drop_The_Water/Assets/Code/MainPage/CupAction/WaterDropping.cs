﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropping : MonoBehaviour {

	//Vector3 direction;
	Vector3 direction_water = new Vector3(0,8f,0);
	int i, j;

	void Start () {
		i = mainEvent.redWaterNum;
		j = makeStage.answerNum[i];
		mainEvent.Drop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		Debug.Log("waterstart");
	}

	void Update () {

		if (!mainEvent.Drop) {
			mainEvent.Drop = true;
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
			Debug.Log("start");
		}

		if(mainEvent.finalDrop) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_"+makeStage.answerNum[i]);
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.tag.Equals("cup"))
		{
			//direction = other.transform.position;
			//Debug.Log ("other gameobject is cup");

			if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_0")) {
				Debug.Log ("image is cup_0");
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_1");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_1")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_2");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_2")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_3");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_3")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_4");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_4")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_5");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_5")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_6");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_6")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_7");
			}else if (other.gameObject.GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_7")) {
				other.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_8");
			}

			//Destroy(this.gameObject);

			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
			this.gameObject.transform.position = direction_water;

			mainEvent.finalDrop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);
			Debug.Log("finalDrop" + mainEvent.finalDrop);
		}
	}
}