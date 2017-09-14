using UnityEngine;
using System.Collections;
using Instruction;
using ObjectHierachy;


public class btnEvent : MonoBehaviour {

	public GameObject[] btns;
	public string action1 = null;
	public string action2 = null;
	public int num1=0;
	public int num2=0;
	public int num3=0;
	public int num4=0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnMouseUp()
	{
		if (Resource.instruction == null)
			Resource.instruction = new Instructions ();

		if (this.transform.Equals (btns [0].transform)) {
			if (action1 == null)
				action1 = returns ("plus");
			else
				action2 = returns ("plus");
		} else if (this.transform.Equals (btns [1].transform)) {
			if (action1 == null)
				action1 = returns ("minus");
			else
				action2 = returns ("minus");
		} else if (this.transform.Equals (btns [2].transform)) {
			if (num1 == 0)
				num1 = returni (1);
			else if (num2 == 0)
				num2 = returni (1);
			else if (num3 == 0)
				num3 = returni (1);
			else
				num4 = returni (1);
		}
		else if (this.transform.Equals (btns [3].transform)) {
			if (num1 == 0)
				num1 = returni (2);
			else if (num2 == 0)
				num2 = returni (2);
			else if (num3 == 0)
				num3 = returni (2);
			else
				num4 = returni (2);
		}
		else if (this.transform.Equals (btns [4].transform))  {
			if (num1 == 0)
				num1 = returni (3);
			else if (num2 == 0)
				num2 = returni (3);
			else if (num3 == 0)
				num3 = returni (3);
			else
				num4 = returni (3);
		}
		else if (this.transform.Equals (btns [5].transform))  {
			if (num1 == 0)
				num1 = returni (4);
			else if (num2 == 0)
				num2 = returni (4);
			else if (num3 == 0)
				num3 = returni (4);
			else
				num4 = returni (4);
		}
		else if (this.transform.Equals (btns [6].transform))  {
			if (num1 == 0)
				num1 = returni (5);
			else if (num2 == 0)
				num2 = returni (5);
			else if (num3 == 0)
				num3 = returni (5);
			else
				num4 = returni (5);
		}
		else if (this.transform.Equals (btns [7].transform))  {
			if (num1 == 0)
				num1 = returni (6);
			else if (num2 == 0)
				num2 = returni (6);
			else if (num3 == 0)
				num3 = returni (6);
			else
				num4 = returni (6);
		}
		else if (this.transform.Equals (btns [8].transform))  {
			if (num1 == 0)
				num1 = returni (7);
			else if (num2 == 0)
				num2 = returni (7);
			else if (num3 == 0)
				num3 = returni (7);
			else
				num4 = returni (7);
		}
		else if (this.transform.Equals (btns [9].transform))  {
			if (num1 == 0)
				num1 = returni (8);
			else if (num2 == 0)
				num2 = returni (8);
			else if (num3 == 0)
				num3 = returni (8);
			else
				num4 = returni (8);
		}
		else if (this.transform.Equals (btns [10].transform)) {
			returns ("play");

			//FileHelper.FileStreamHelper.log (Resource.instruction.ToString ());
		}
	}

	public string returns(string s){
		return s;
	}

	public int returni(int i) {
		return i;
	}


	public void play(){
		
	}
}

