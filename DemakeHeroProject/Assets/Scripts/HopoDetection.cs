using UnityEngine;
using System.Collections;

public class HopoDetection : MonoBehaviour {

	public GemData gemData;
	public Gem gemIdentity;
	public Chord chordIdentity;
	public Sprite hopoSprite;
	public Sprite holdSprite;

	// Use this for initialization
	void Awake () {
		gemData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<GemData>();
		gemIdentity = new Gem(0, 0, 0, 0);
		chordIdentity = new Chord(0,0,0,0,0);
	}

	// Update is called once per frame
	void Start () {
		if( gemIdentity.hopo == true ){
			gameObject.GetComponent<SpriteRenderer>().sprite = hopoSprite;
		}

		if( gemIdentity.holdDuration != 0 ){
			ManageHold( gemIdentity.holdDuration );
		}
		else if( chordIdentity.holdDuration != 0 ){
			ManageHold( chordIdentity.holdDuration );
		}

	}

	void ManageHold( float holdDuration ){
		for( int i = 1; i < holdDuration; i++ ){
			GameObject hold = new GameObject();
			hold.AddComponent<SpriteRenderer>();
			hold.GetComponent<SpriteRenderer>().sprite = holdSprite;

			hold.AddComponent<LineMovement>();
			hold.GetComponent<LineMovement>().speed = gameObject.GetComponent<LineMovement>().speed;

			hold.AddComponent<BoxCollider>();
	
			hold.transform.position = new Vector3(transform.position.x, transform.position.y + i, transform.position.z);
			hold.transform.parent = GameObject.Find ("Holds").transform;
		}


	}
}
