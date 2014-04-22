using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemInteraction : MonoBehaviour {

	public GemData gemData;
	public InputManager inputManager;
	public Vector3[] bridgeCenters;
	public Vector3[] missCenters;
	public bool[] interactedBridge;
	public ScoreData scoreData;
	public bool holdActive;
	public int[] holdFret;

	// Use this for initialization
	void Awake () {
		gemData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<GemData>();
		scoreData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<ScoreData>();
		inputManager = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<InputManager>();

		for ( int i = 0; i < bridgeCenters.Length; i++ ){
			bridgeCenters[i] = GetComponentsInChildren<Transform>()[i+1].position;

			bridgeCenters[i] = new Vector3(bridgeCenters[i].x + .5f, bridgeCenters[i].y - .5f, bridgeCenters[i].z);
		}

		for ( int i = 0; i < missCenters.Length; i++ ){
			missCenters[i] = bridgeCenters[i];
			
			missCenters[i] = new Vector3(missCenters[i].x, missCenters[i].y - 1f, missCenters[i].z);
		}

	}
	
	// Update is called once per frame
	void Update() {
		for( int i = 0; i < inputManager.bridge.Length; i++ ){
			if( inputManager.bridge[i] ){
				Ray strikeRay = new Ray(bridgeCenters[i], -Vector3.forward);
				RaycastHit hitInfo;

				Debug.DrawRay(bridgeCenters[i], -Vector3.forward);
				Debug.DrawRay(missCenters[i], -Vector3.forward);

				if( Physics.Raycast(strikeRay, out hitInfo) ){
					interactedBridge[i] = true;

					HandleGemDestruction( i, hitInfo.collider.gameObject );
				}
				else{
					interactedBridge[i] = false;
				}
			}
			else{
				interactedBridge[i] = false;
			}

			Ray missRay = new Ray(missCenters[i], -Vector3.forward);
			RaycastHit hitInfo2;

			if( Physics.Raycast(missRay, out hitInfo2 ) ){
				if( hitInfo2.collider.gameObject.tag == Tags.gem ){
					scoreData.multiplier = 1;
					scoreData.combo = 0;

					if( hitInfo2.collider.gameObject.GetComponent<HopoDetection>().chordIdentity.secondIdentity == 0 ){
						gemData.gems[hitInfo2.collider.gameObject.GetComponent<HopoDetection>().gemIdentity.index].active = false;
					}
					else{
						gemData.chords[hitInfo2.collider.gameObject.GetComponent<HopoDetection>().chordIdentity.index].active = false;
					}

					Destroy(hitInfo2.collider);
				}
			}
		}

		//Overstrums();

		ManageHolds();
	}

	void HandleGemDestruction( int gemColor, GameObject gemObject ){
		if( gemObject.tag == Tags.gem ){
			if( gemObject.GetComponent<HopoDetection>().chordIdentity.secondIdentity != 0 ){
				int pressTest = 0;
				
				for( int i = 0; i < inputManager.bridge.Length; i++ ){
					if( inputManager.bridge[i] ){
						pressTest++;
					}
				}

				if( pressTest == 2 ){
					if( inputManager.bridge[gemObject.GetComponent<HopoDetection>().chordIdentity.firstIdentity] && inputManager.bridge[gemObject.GetComponent<HopoDetection>().chordIdentity.secondIdentity] ){
						if( inputManager.strum ){
							if( gemObject.GetComponent<HopoDetection>().chordIdentity.holdDuration != 0 ){
								holdActive = true;
								holdFret[0] = gemObject.GetComponent<HopoDetection>().chordIdentity.firstIdentity;
								holdFret[1] = gemObject.GetComponent<HopoDetection>().chordIdentity.secondIdentity;
							}

							gemData.chords[gemObject.GetComponent<HopoDetection>().chordIdentity.index].active = false;

							Destroy(gemObject);
							scoreData.score += 50 * scoreData.multiplier;
							scoreData.combo++;
						}
					}
				}
			}
			else{
				List<int> activeFrets = new List<int>();
				int topFret = -1;

				for( int i = 0; i < inputManager.bridge.Length; i++ ){
					if( inputManager.bridge[i] ){
						activeFrets.Add( i );
					}
				}

				foreach( int fret in activeFrets ){
					if( topFret < fret ){
						topFret = fret;
					}
				}

				activeFrets.Clear();

				if( topFret == gemObject.GetComponent<HopoDetection>().gemIdentity.identity ){
					if( inputManager.strum || ( gemObject.GetComponent<HopoDetection>().gemIdentity.hopo && ( scoreData.combo != 0 || scoreData.multiplier != 1 ) ) ){
						if( gemObject.GetComponent<HopoDetection>().gemIdentity.index > 0 ){
							if ( !gemData.gems[gemObject.GetComponent<HopoDetection>().gemIdentity.index - 1].active ){
								if( gemObject.GetComponent<HopoDetection>().gemIdentity.holdDuration != 0 ){
									holdActive = true;
									holdFret[0] = gemObject.GetComponent<HopoDetection>().gemIdentity.identity;
									holdFret[1] = 0;
								}
								
								gemData.gems[gemObject.GetComponent<HopoDetection>().gemIdentity.index].active = false;
								
								Destroy(gemObject);
								scoreData.score += 25 * scoreData.multiplier;
								scoreData.combo++;
							}
						}
						else{
							if( gemObject.GetComponent<HopoDetection>().gemIdentity.holdDuration != 0 ){
								holdActive = true;
								holdFret[0] = gemObject.GetComponent<HopoDetection>().gemIdentity.identity;
								holdFret[1] = 0;
							}
							
							gemData.gems[gemObject.GetComponent<HopoDetection>().gemIdentity.index].active = false;
							
							Destroy(gemObject);
							scoreData.score += 25 * scoreData.multiplier;
							scoreData.combo++;
						}
					}
				}
			}
		}
		else{
			if( holdActive ){
				Destroy(gemObject);
				scoreData.score += 1 * scoreData.multiplier;
			}
		}

	}

	void ManageHolds(){
		if( !inputManager.bridge[holdFret[0]] ){
			holdActive = false;
		}
		
		if( holdFret[1] != 0 && !inputManager.bridge[holdFret[1]] ){
			holdActive = false;
		}

		//Debug.Log (holdActive);

		if( holdActive && holdFret[1] == 0 ){
			List<int> activeFrets = new List<int>();
			int topFret = -1;
			
			for( int i = 0; i < inputManager.bridge.Length; i++ ){
				if( inputManager.bridge[i] ){
					activeFrets.Add( i );
				}
			}
			
			foreach( int fret in activeFrets ){
				if( topFret < fret ){
					topFret = fret;
				}
			}
			
			if( topFret == holdFret[0] ){
				holdActive = true;
			}
			else{
				holdActive = false;
			}
			
			activeFrets.Clear();
		}
		else if( holdActive ){
			int pressTest = 0;
			
			for( int i = 0; i < inputManager.bridge.Length; i++ ){
				if( inputManager.bridge[i] ){
					pressTest++;
				}
			}
			
			if( pressTest == 2 ){
				holdActive = true;
			}
			else{
				holdActive = false;
			}
		}
	}

	void Overstrums(){
		if( inputManager.strum ){
			for( int i = 0; i < inputManager.bridge.Length; i++ ){
				if( inputManager.bridge[i] ){
					Ray strikeRay = new Ray(bridgeCenters[i], -Vector3.forward);
					RaycastHit hitInfo;

					if( !Physics.Raycast(strikeRay, out hitInfo) ){
						scoreData.multiplier = 1;
						scoreData.combo = 0;
					}
				}
			}
		}
	}
}
