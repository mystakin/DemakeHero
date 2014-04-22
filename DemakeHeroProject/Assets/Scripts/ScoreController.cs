using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

	public ScoreData scoreData;
	public Sprite[] multiplierArray;
	public GameObject[] comboObjects;
	public Sprite[] comboSpriteArray;
	public GameObject multiplierObject;
	public GameObject[] scorePlacement;
	public Sprite[] scoreDigits;

	// Use this for initialization
	void Awake () {
		scoreData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<ScoreData>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ManageCombo();
		ManageMultiplier();
		ManageScore();
	}

	void ManageMultiplier(){
		if( scoreData.multiplier == 1 ){
			multiplierObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else if( scoreData.multiplier == 2 ){
			multiplierObject.GetComponent<SpriteRenderer>().enabled = true;
			multiplierObject.GetComponent<SpriteRenderer>().sprite = multiplierArray[0];
		}
		else if( scoreData.multiplier == 3 ){
			multiplierObject.GetComponent<SpriteRenderer>().sprite = multiplierArray[1];
		}
		else{
			multiplierObject.GetComponent<SpriteRenderer>().sprite = multiplierArray[2];
		}
	}

	void ManageCombo(){
		for( int i = 0; i < comboObjects.Length; i++ ){
			if( scoreData.combo > i ){
				comboObjects[i].GetComponent<SpriteRenderer>().enabled = true;
			}
			else{
				comboObjects[i].GetComponent<SpriteRenderer>().enabled = false;
			}

			if( scoreData.multiplier == 1 ){
				comboObjects[i].GetComponent<SpriteRenderer>().sprite = comboSpriteArray[0];
			}
			else if( scoreData.multiplier == 2 ){
				comboObjects[i].GetComponent<SpriteRenderer>().sprite = comboSpriteArray[1];
			}
			else {
				comboObjects[i].GetComponent<SpriteRenderer>().sprite = comboSpriteArray[2];
			}
		}
	}

	void ManageScore(){
		int cutScore, ones, tens, hundreds, thousands, tenThousands, hundredThousands;

		cutScore = scoreData.score;

		ones = cutScore % 10;
		cutScore -= ones;

		tens = cutScore % 100;
		cutScore -= tens;
		tens = tens / 10;

		hundreds = cutScore % 1000;
		cutScore -= hundreds;
		hundreds = hundreds / 100;

		thousands = cutScore % 10000;
		cutScore -= thousands;
		thousands = thousands / 1000;

		tenThousands = cutScore % 100000;
		cutScore -= tenThousands;
		tenThousands = tenThousands / 10000;

		hundredThousands = cutScore % 1000000;
		cutScore -= hundredThousands;
		hundredThousands = hundredThousands / 100000;

		scorePlacement[0].GetComponent<SpriteRenderer>().sprite = scoreDigits[ones];
		scorePlacement[1].GetComponent<SpriteRenderer>().sprite = scoreDigits[tens];
		scorePlacement[2].GetComponent<SpriteRenderer>().sprite = scoreDigits[hundreds];
		scorePlacement[3].GetComponent<SpriteRenderer>().sprite = scoreDigits[thousands];
		scorePlacement[4].GetComponent<SpriteRenderer>().sprite = scoreDigits[tenThousands];
		scorePlacement[5].GetComponent<SpriteRenderer>().sprite = scoreDigits[hundredThousands];

		if( hundredThousands == 0 ){
			if( tenThousands == 0 ){
				if( thousands == 0 ){
					if( hundreds == 0 ){
						if( tens == 0 ){
							if( ones == 0 ){
								scorePlacement[0].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[1].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[2].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[3].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[4].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
							}
							else{
								scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
								scorePlacement[1].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[2].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[3].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[4].GetComponent<SpriteRenderer>().enabled = false;
								scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
							}
						}
						else{
							scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
							scorePlacement[1].GetComponent<SpriteRenderer>().enabled = true;
							scorePlacement[2].GetComponent<SpriteRenderer>().enabled = false;
							scorePlacement[3].GetComponent<SpriteRenderer>().enabled = false;
							scorePlacement[4].GetComponent<SpriteRenderer>().enabled = false;
							scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
						}
					}
					else{
						scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
						scorePlacement[1].GetComponent<SpriteRenderer>().enabled = true;
						scorePlacement[2].GetComponent<SpriteRenderer>().enabled = true;
						scorePlacement[3].GetComponent<SpriteRenderer>().enabled = false;
						scorePlacement[4].GetComponent<SpriteRenderer>().enabled = false;
						scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
					}
				}
				else{
					scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
					scorePlacement[1].GetComponent<SpriteRenderer>().enabled = true;
					scorePlacement[2].GetComponent<SpriteRenderer>().enabled = true;
					scorePlacement[3].GetComponent<SpriteRenderer>().enabled = true;
					scorePlacement[4].GetComponent<SpriteRenderer>().enabled = false;
					scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
				}
			}
			else{
				scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
				scorePlacement[1].GetComponent<SpriteRenderer>().enabled = true;
				scorePlacement[2].GetComponent<SpriteRenderer>().enabled = true;
				scorePlacement[3].GetComponent<SpriteRenderer>().enabled = true;
				scorePlacement[4].GetComponent<SpriteRenderer>().enabled = true;
				scorePlacement[5].GetComponent<SpriteRenderer>().enabled = false;
			}
		}
		else{
			scorePlacement[0].GetComponent<SpriteRenderer>().enabled = true;
			scorePlacement[1].GetComponent<SpriteRenderer>().enabled = true;
			scorePlacement[2].GetComponent<SpriteRenderer>().enabled = true;
			scorePlacement[3].GetComponent<SpriteRenderer>().enabled = true;
			scorePlacement[4].GetComponent<SpriteRenderer>().enabled = true;
			scorePlacement[5].GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
