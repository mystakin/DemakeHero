using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
	
	public bool[] bridge = new bool[5];
	public bool strum;

	// Use this for initialization
	void Awake () {
		for( int i = 0; i < 5; i++ ){
			bridge[i] = false;
		}
	}

	void Update(){
		FretInputs();
		StrumInput();
	}

	void FretInputs(){
		if( Input.GetButton("Green") ){
			bridge[0] = true;
		}
		else{
			bridge[0] = false;
		}

		if( Input.GetButton("Red") ){
			bridge[1] = true;
		}
		else{
			bridge[1] = false;
		}

		if( Input.GetButton("Yellow") ){
			bridge[2] = true;
		}
		else{
			bridge[2] = false;
		}

		if( Input.GetButton("Blue") ){
			bridge[3] = true;
		}
		else{
			bridge[3] = false;
		}

		if( Input.GetButton("Orange") ){
			bridge[4] = true;
		}
		else{
			bridge[4] = false;
		}
	}

	void StrumInput(){
		if( Input.GetButtonDown("Strum") ){
			strum = true;
		}
		else if( Input.GetButtonDown("StrumAlt") ){
			strum = true;
		}
		else{
			strum = false;
		}
	}
}
