using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedWaterDropping : MonoBehaviour {

	//Vector3 direction;
	Vector3 direction_redwater = new Vector3(0,3.5f,0);
	int i, j;

	void Start () {
		i = mainEvent.redWaterNum;
		j = makeStage.answerNum[i];
		mainEvent.Drop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		DropRedWater(mainEvent.redWaterNum);
	}

	void Update () {

		if (!mainEvent.Drop) {
			mainEvent.Drop = true;
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;
		}

		if(mainEvent.finalDrop) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_"+makeStage.answerNum[i]);
			Destroy(this.gameObject);
		}
	}

	//Vector3 direction;
	//Vector3 direction_water = new Vector3(0,8f,0);

	void DropRedWater(int i){

		
		//direction = other.transform.position;

		if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_8")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_7");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_7")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_6");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_6")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_5");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_5")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_4");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_4")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_3");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_3")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_2");
		}else if (makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_2")) {
			makeStage.gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_1");
		}

		Destroy(this.gameObject, 0.05f);

		//this.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		//this.transform.position = direction_water;

		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0.0f;
		this.gameObject.transform.position = direction_redwater;

		mainEvent.finalDrop = makeStage.gameCup[i].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+ j);

	}
}
