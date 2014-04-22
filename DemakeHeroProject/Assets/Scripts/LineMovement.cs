using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineMovement : MonoBehaviour {


	public float speed;
	public float depth;
	public ScoreData scoreData;

	void Start(){
		scoreData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<ScoreData>();


		if( gameObject.tag == Tags.gem ){
			depth = Global.gemDepth;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		if( gameObject.tag == Tags.gem ){
			transform.position = new Vector3( transform.position.x, transform.position.y + (-speed * Time.fixedDeltaTime), depth );
		}
		else{
			transform.position = new Vector3( transform.position.x, transform.position.y + (-speed * Time.fixedDeltaTime), transform.position.z );
		}

		if( Camera.main.WorldToViewportPoint( transform.position ).y < 0f ){
			Destroy(gameObject);
		}
	}
}
