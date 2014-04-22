using UnityEngine;
using System.Collections;

public class HitGemDetection : MonoBehaviour {

	public GemInteraction gemInt;

	// Use this for initialization
	void Awake () {
		gemInt = GameObject.FindGameObjectWithTag(Tags.bridge).GetComponent<GemInteraction>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
