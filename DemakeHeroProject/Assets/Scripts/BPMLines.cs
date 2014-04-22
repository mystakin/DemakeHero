using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BPMLines : MonoBehaviour {

	public float beatsPerMinute;
	public int measureCount;
	public int beatCount;
	public int previousBeat;
	public int sixtyFourthCount;
	public int thirtySecondTripletCount;
	public float sixtyFourthsPerSecond;
	public float thirtySecondTripletsPerSecond;
	public float defaultTime;
	public float tripletTime;
	public Object bpmLine;
	public Object[] gems;
	public Vector3[] gemStartPositions;
	public Object[] holds;
	public Vector3 lineStartPosition;
	public GemData gemData;
	public float scrollSpeed;
	public int gemCounter;
	public int chordCounter;
	public int holdCounter;

	// Use this for initialization
	void Awake () {
		sixtyFourthsPerSecond = beatsPerMinute / 60f / 4f * 64f;
		thirtySecondTripletsPerSecond = beatsPerMinute / 60f / 4f * 48f;

		gemData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<GemData>();
		Global.gemDepth = -10;
		scrollSpeed = beatsPerMinute / 30;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Counters();
		BPMLineGeneration();
		GemGenerator();
		ChordGenerator();
		HoldGenerator();

		if( Global.gemDepth < -90 ){
			Global.gemDepth = -10;
		}
	}

	void Counters(){
		defaultTime += Time.deltaTime;
		tripletTime += Time.deltaTime;

		if( defaultTime > (1f / sixtyFourthsPerSecond) ){
			if( defaultTime > (1f / sixtyFourthsPerSecond) * 2 ){
				sixtyFourthCount++;
				defaultTime -= (1f / sixtyFourthsPerSecond);
			}
			sixtyFourthCount++;

			defaultTime -= (1f / sixtyFourthsPerSecond);
		}

		if( tripletTime > (1f / thirtySecondTripletsPerSecond) ){
			if( tripletTime > (1f / thirtySecondTripletsPerSecond) * 2 ){
				thirtySecondTripletCount++;
				tripletTime -= (1f / thirtySecondTripletsPerSecond);
			}

			thirtySecondTripletCount++;
			tripletTime -= (1f / thirtySecondTripletsPerSecond);
		}

		if( sixtyFourthCount >= (64 / 4) ){
			beatCount++;
			sixtyFourthCount = 0;
			thirtySecondTripletCount = 0;
		}

		if( beatCount >= 4 ){
			measureCount++;
			beatCount = 0;
		}
	}

	void BPMLineGeneration(){
		if( previousBeat != beatCount ){
			GameObject beatLine = (GameObject)Instantiate(bpmLine, lineStartPosition, Quaternion.identity);
			beatLine.GetComponent<LineMovement>().speed = scrollSpeed;
			beatLine.transform.parent = GameObject.Find("BPMLines").transform;

			if( beatCount == 0 ){
				GameObject beatLine2 = (GameObject)Instantiate(bpmLine, new Vector3(lineStartPosition.x, lineStartPosition.y - .04f, lineStartPosition.z), Quaternion.identity);
				GameObject beatLine3 = (GameObject)Instantiate(bpmLine, new Vector3(lineStartPosition.x, lineStartPosition.y + .04f, lineStartPosition.z), Quaternion.identity);
				beatLine2.GetComponent<LineMovement>().speed = scrollSpeed;
				beatLine3.GetComponent<LineMovement>().speed = scrollSpeed;

				beatLine2.transform.parent = GameObject.Find ("BPMLines").transform;
				beatLine3.transform.parent = GameObject.Find ("BPMLines").transform;
			}
		}

		previousBeat = beatCount;
	}

	void GemGenerator(){
		if( gemData.gems.Count != gemCounter ){
			if( gemData.gems[gemCounter].measure == measureCount ){
				if( gemData.gems[gemCounter].beat == beatCount ){
					if( gemData.gems[gemCounter].triplet == false ){
						if( gemData.gems[gemCounter].subdivision == sixtyFourthCount ){
							gemData.gems[gemCounter].active = true;

							GameObject newGem = (GameObject)Instantiate( gems[gemData.gems[gemCounter].identity], gemStartPositions[gemData.gems[gemCounter].identity], Quaternion.identity );
							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							
							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem.GetComponent<HopoDetection>().gemIdentity = gemData.gems[gemCounter];
							gemCounter++;

							Global.gemDepth--;
						}
					}
					else{
						if( gemData.gems[gemCounter].subdivision == thirtySecondTripletCount ){
							gemData.gems[gemCounter].active = true;

							GameObject newGem = (GameObject)Instantiate( gems[gemData.gems[gemCounter].identity], gemStartPositions[gemData.gems[gemCounter].identity], Quaternion.identity );
							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							
							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem.GetComponent<HopoDetection>().gemIdentity = gemData.gems[gemCounter];

							gemCounter++;
							Global.gemDepth--;
						}
					}
				}
			}
		}
	}

	void ChordGenerator(){
		if( gemData.chords.Count != chordCounter ){
			if( gemData.chords[chordCounter].measure == measureCount ){
				if( gemData.chords[chordCounter].beat == beatCount ){
					if( gemData.chords[chordCounter].triplet == false ){
						if( gemData.chords[chordCounter].subdivision == sixtyFourthCount ){
							gemData.chords[chordCounter].active = true;

							GameObject newGem = (GameObject)Instantiate( gems[gemData.chords[chordCounter].firstIdentity], gemStartPositions[gemData.chords[chordCounter].firstIdentity], Quaternion.identity );
							GameObject newGem2 = (GameObject)Instantiate( gems[gemData.chords[chordCounter].secondIdentity], gemStartPositions[gemData.chords[chordCounter].secondIdentity], Quaternion.identity );

							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							newGem2.GetComponent<LineMovement>().speed = scrollSpeed;

							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem2.transform.parent = GameObject.Find("Gems").transform;

							newGem.GetComponent<HopoDetection>().chordIdentity = gemData.chords[chordCounter];
							newGem2.GetComponent<HopoDetection>().chordIdentity = gemData.chords[chordCounter];

							chordCounter++;
							Global.gemDepth--;
						}
					}
					else{
						if( gemData.gems[chordCounter].subdivision == thirtySecondTripletCount ){
							gemData.chords[chordCounter].active = true;

							GameObject newGem = (GameObject)Instantiate( gems[gemData.chords[chordCounter].firstIdentity], gemStartPositions[gemData.chords[chordCounter].firstIdentity], Quaternion.identity );
							GameObject newGem2 = (GameObject)Instantiate( gems[gemData.chords[chordCounter].secondIdentity], gemStartPositions[gemData.chords[chordCounter].secondIdentity], Quaternion.identity );
							
							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							newGem2.GetComponent<LineMovement>().speed = scrollSpeed;
							
							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem2.transform.parent = GameObject.Find("Gems").transform;

							newGem.GetComponent<HopoDetection>().chordIdentity = gemData.chords[chordCounter];
							newGem2.GetComponent<HopoDetection>().chordIdentity = gemData.chords[chordCounter];

							chordCounter++;
							Global.gemDepth--;
						}
					}
				}
			}
		}
	}

	void HoldGenerator(){
		if( gemData.gems.Count != gemCounter ){
			if( gemData.gems[gemCounter].measure == measureCount ){
				if( gemData.gems[gemCounter].beat == beatCount ){
					if( gemData.gems[gemCounter].triplet == false ){
						if( gemData.gems[gemCounter].subdivision == sixtyFourthCount ){

							GameObject newGem = (GameObject)Instantiate( gems[gemData.gems[gemCounter].identity], gemStartPositions[gemData.gems[gemCounter].identity], Quaternion.identity );
							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							
							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem.GetComponent<HopoDetection>().gemIdentity = gemData.gems[gemCounter];
							gemCounter++;
							
							Global.gemDepth--;
						}
					}
					else{
						if( gemData.gems[gemCounter].subdivision == thirtySecondTripletCount ){;

							GameObject newGem = (GameObject)Instantiate( gems[gemData.gems[gemCounter].identity], gemStartPositions[gemData.gems[gemCounter].identity], Quaternion.identity );
							newGem.GetComponent<LineMovement>().speed = scrollSpeed;
							
							newGem.transform.parent = GameObject.Find("Gems").transform;
							newGem.GetComponent<HopoDetection>().gemIdentity = gemData.gems[gemCounter];
							
							gemCounter++;
							Global.gemDepth--;
						}
					}
				}
			}
		}
	}
}
