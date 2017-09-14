using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Instruction;
using ObjectHierachy;
using System.IO;

public class makeStage : MonoBehaviour {
	public delegate void Clear ();

	public GameObject cup;
	public GameObject cupAnswer;

	public static int[] answerNum;
	public static int[] gameNum;

	public static List<GameObject> answerCup = new List<GameObject>();
	public static List<GameObject> gameCup = new List<GameObject>();

	public static Clear clearEvent;

	Vector3 answerPos;
	Vector3 gamePos = new Vector3(0, 4f, 0);

	// Use this for initialization
	void Start () {
		loadStage (Resource.stage, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void loadStage(int stage, int stageNum, int stageMod) {
		Debug.Log (Resource.stage);
		TextAsset data = Resources.Load ("StageText/text" + stage, typeof(TextAsset)) as TextAsset;
		StringReader str = new StringReader (data.text);

		string line;

		while((line = str.ReadLine()) != null) {
			if(line.Equals("cup")){
				line = str.ReadLine();
				string[] o = line.Split (new char[]{ ' ' });
				Debug.Log (o [0]);

				gameNum = new int[o.Length];

				for(int i=0; i<o.Length; i++) {
					gameNum[i] = int.Parse (o [i]);
				}

				createCup (gameNum);
			}
			else if(line.Equals("answer")) {
				line = str.ReadLine();
				string[] o = line.Split (new char[]{ ' ' });

				answerNum = new int[o.Length];
				
				for(int i=0; i<o.Length; i++) {
					answerNum[i] = int.Parse (o [i]);
				}

				createAnswer(stageNum, stageMod);
			}
		}
	}


	public void createCup(int[] a){
		for(int i=0; i <a.Length; i++){
			GameObject _cup = Instantiate(cup, gamePos, Quaternion.identity) as GameObject;
			gameCup.Add(_cup);
			gameCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/cup_" + gameNum[i]);
			gamePos.x += 2.1f;
		}
	}

		
	public void createAnswer(int b, int c){
		answerPos = new Vector3(-6.3f,8.5f,0);
		int i = b*4;

		if(c == 0) {
			for(int j=i-4; j<i; j++){
				GameObject _cupAnswer = Instantiate(cupAnswer, answerPos, Quaternion.identity) as GameObject;
				answerCup.Add(_cupAnswer);
				answerCup[j].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_" + answerNum[j]);
				answerPos.x += 1.2f;
			}
		}else{
			for(int j = 0; j<c; j++){
				GameObject _cupAnswer = Instantiate(cupAnswer, answerPos, Quaternion.identity) as GameObject;
				answerCup.Add(_cupAnswer);
				answerCup[i].GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("cup/colorCup_" + answerNum[i]);
				answerPos.x += 1.2f;
				i++;
			}
		}
	}

	
}