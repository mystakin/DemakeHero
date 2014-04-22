using UnityEngine;
using System.Collections;

public class ScoreData : MonoBehaviour {

	public int combo;
	public int multiplier;
	public int score;

	void Update(){
		if( combo >= 10 && multiplier != 4 ){
			multiplier++;

			combo = 0;
		}
		else if( multiplier == 4 ) {
			combo = 10;
		}
	}
}
