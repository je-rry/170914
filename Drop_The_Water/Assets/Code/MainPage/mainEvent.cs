using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;

public class mainEvent : MonoBehaviour {

	public makeStage mkStage;

	public Vector3 waterPos = new Vector3(0,8f,0);
	public Vector3 red_waterPos = new Vector3(0,3.5f,0);
	public GameObject Water, RedWater;
	public static int redWaterNum = 0;
	public static bool keepDrop = false;
	public static bool Drop = true;
	public static bool finalDrop = false;

	bool execute, correct;
	int puzzleLines;
	string[] action = new string[2];
	int[] number1 = new int[2];
	int[] number2 = new int[2];
	GameObject w_ater, red_water;

	int num;


	//Singleton
	public static mainEvent instance = null;

	void Awake() {
    	instance = this;
	}

	// Use this for initialization
	void Start () {
		execute = false;
		correct = false;
		num = 0;
	}

	// Update is called once per frame
	void Update () {
		execute = UseDLL.instance.data.execute;
		puzzleLines = UseDLL.instance.data.puzzleLines;

		if(execute == true && puzzleLines == 2) {
			
			for(int i=0; i<2; i++){
				action[i] = UseDLL.instance.data.puzzle[i].action;
				number1[i] = UseDLL.instance.data.puzzle[i].number1;
				number2[i] = UseDLL.instance.data.puzzle[i].number2;
			}

			Debug.Log("excute : " + execute);
			Debug.Log("puzzleLines : " + puzzleLines);
			Debug.Log("action[0] : " + action[0]);
			Debug.Log("action[1] : " + action[1]);
			Debug.Log("number1[0] : " + number1[0]);
			Debug.Log("number1[1] : " + number1[1]);
			Debug.Log("number2[0] : " + number2[0]);
			Debug.Log("number2[1] : " + number2[1]);

			Debug.Log("Resouce.stage_add" + Resource.stage_add);

			MainAction(Resource.stage_add-1);

			enabled = false;
		}

	}



	void MainAction (int a) {
		num = 4*a - 4;
		int corretAnswer;

		for(int i=0; i<2; i++){

			if(action[i] == "add") {
				if((makeStage.gameNum[num] + number1[i]) == makeStage.answerNum[num]){
					correct = true;
					corretAnswer = makeStage.gameNum[num] + number1[i];
					num += 1;
					Debug.Log("correct answer : " + corretAnswer);
					Debug.Log("correct : " + correct);
				}
				else {
					correct = false;
					break;
				}

				if(num < makeStage.gameNum.Length) {
					if((makeStage.gameNum[num] + number2[i]) == makeStage.answerNum[num]){
						correct = true;
						corretAnswer = makeStage.gameNum[num] + number2[i];
					num += 1;
					Debug.Log("correct answer : " + corretAnswer);
					Debug.Log("correct : " + correct);
					}
					else {
						correct = false;
						break;
					}
				}
			}

			if(action[i] == "sub"){
				if((makeStage.gameNum[num] - number1[i]) == makeStage.answerNum[num]){
					correct = true;
					corretAnswer = makeStage.gameNum[num] - number1[i];
					num += 1;
					Debug.Log("correct answer : " + corretAnswer);
					Debug.Log("correct : " + correct);
				}
				else {
					correct = false;
					break;
				}

				if(num < makeStage.gameNum.Length) {
					if((makeStage.gameNum[num] - number2[i]) == makeStage.answerNum[num]){
						correct = true;
						corretAnswer = makeStage.gameNum[num] - number2[i];
					num += 1;
					Debug.Log("correct answer : " + corretAnswer);
					Debug.Log("correct : " + correct);
					}
					else {
						correct = false;
						break;
					}
				}
			}
		}

		num = 4*a - 4;
		redWaterNum = 4*a - 4;

		w_ater = (GameObject)Instantiate(Water, waterPos, Quaternion.identity);

		
		/*if(correct) {
			for(int k=0; k<2; k++) {
				if(action[k] == "add")
					redWaterNum = AddAction(num);
				
				if(action[k] == "sub")
					redWaterNum = SubAction(num);
			}
		}*/
	}

	int AddAction (int i) {
		for(int j=i; j < i+2; j++){

			if(j < makeStage.gameNum.Length) {

				w_ater = (GameObject)Instantiate(Water, waterPos, Quaternion.identity);

				if(finalDrop) {
					//MoveCup(j);
					//finalDrop = false;
				}
				//MoveCup(j);
			}
		}

		i += 2;

		return i;
	}


	int SubAction (int i) {
		for(int j=i; j < i+2; j++){

			//redWaterNum = j;
			
			if(j < makeStage.gameNum.Length) {
				
				red_water = (GameObject)Instantiate(RedWater, red_waterPos, Quaternion.identity);

				//MoveCup(j);
				if(finalDrop) {
					MoveCup(j);
					finalDrop = false;
				}
			}
		}

		i += 2;

		return i;
	}


	void MoveCup(int a) {
		float cupPos;
		for(int i=a; i<a+4; i++) {
			cupPos = makeStage.gameCup[i].transform.position.x;
			cupPos -= 2.1f;
			makeStage.gameCup[i].transform.position = new Vector3 (cupPos, 4, 0);
		}
	}

	//IEnumerator WaterIsDrop(int a, GameObject b, bool c) {
	//	do {
	//		b = (GameObject)Instantiate(Water, waterPos, Quaternion.identity);
	//		c = makeStage.gameCup[a].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+makeStage.answerNum[a]);
	//		yield return null;
	//	}while(!c);
	//}

	//IEnumerator RedWaterIsDrop(int a, GameObject b, bool c) {
	//	do {
	//		b = (GameObject)Instantiate(RedWater, red_waterPos, Quaternion.identity);
	//		c = makeStage.gameCup[a].GetComponent<SpriteRenderer>().sprite.name.Equals ("cup_"+makeStage.answerNum[a]);
	//		yield return null;
	//	}while(!c);
	//}
}















	/*// Use this for initialization
	void Start () {

		for(int i=0; i)
		mk.gameCup
		excute = true;
		Debug.Log("json"+UseDLL.instance.data.execute);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log("json"+UseDLL.instance.data.execute);
		GameObject water = GameObject.Find ("water");
		GameObject cupObj;
		GameObject allCup = GameObject.Find ("cup");
		GameObject answer1 = GameObject.Find ("answer1");
		GameObject answer2 = GameObject.Find ("answer2");
		bool correct = true;
		float newPos;
		Vector3 beforePos = allCup.transform.position;

		if (excute == true) {
			for (int i = 0; i < 4; i++) {
				if (answer [i] != gameCup [i]) {
					correct = false;
					break;
				}
			}

			if (correct) {
				for (int i = 0; i < 4; i++) {
					cupObj = GameObject.Find ("cup_" + i);

					while(!cupObj.gameObject.GetComponent<SpriteRenderer> ().sprite.name.Equals ("cup_" + answer [i]))
						water.GetComponent<Rigidbody2D> ().gravityScale = 0.5f;

					cupObj.gameObject.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_" + answer [i]);
					newPos = beforePos.y - 2.1f;
					allCup.transform.position = new Vector3 (beforePos.x, newPos, beforePos.z);
				}
			}
			Destroy (answer1);
			answer2.transform.position = new Vector3 (-5.9f, 8.5f, 0.0f);
		}
	}
}*/