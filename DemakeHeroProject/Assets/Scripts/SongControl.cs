using UnityEngine;
using System.Collections;

public class SongControl : MonoBehaviour {

	public BPMLines bpmLines;
	public AudioClip background;
	public AudioClip guitar;
	public GameObject backgroundObject;
	public GameObject guitarObject;
	public ScoreData scoreData;

	// Use this for initialization
	void Awake () {
		scoreData = GameObject.FindGameObjectWithTag(Tags.dataController).GetComponent<ScoreData>();

		bpmLines = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<BPMLines>();

		backgroundObject = new GameObject();
		guitarObject = new GameObject();

		backgroundObject.AddComponent<AudioSource>();
		guitarObject.AddComponent<AudioSource>();

		backgroundObject.GetComponent<AudioSource>().clip = background;
		guitarObject.GetComponent<AudioSource>().clip = guitar;

		backgroundObject.GetComponent<AudioSource>().volume = .75f;
		guitarObject.GetComponent<AudioSource>().volume = 1f;

		backgroundObject.GetComponent<AudioSource>().playOnAwake = false;
		guitarObject.GetComponent<AudioSource>().playOnAwake = false;

		backgroundObject.transform.parent = transform;
		guitarObject.transform.parent = transform;

		StartCoroutine(MyLoadLevel(116.0f,0));
	}
	
	IEnumerator MyLoadLevel(float delay, int level)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(level);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if( bpmLines.beatCount == 3 && !backgroundObject.GetComponent<AudioSource>().isPlaying && bpmLines.sixtyFourthCount == 5 ){
			backgroundObject.GetComponent<AudioSource>().Play();
			guitarObject.GetComponent<AudioSource>().Play();
		}

		if( scoreData.combo == 0 && scoreData.multiplier == 1 ){
			guitarObject.GetComponent<AudioSource>().volume = .25f;
		}
		else{
			guitarObject.GetComponent<AudioSource>().volume = 1f;
		}

		if( Input.GetKey(KeyCode.Escape) ){
			Application.Quit();
		}
	}
}
