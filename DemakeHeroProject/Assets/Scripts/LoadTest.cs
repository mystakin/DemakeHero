using UnityEngine;
using System.Collections;

public class LoadTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(MyLoadLevel(2.0f,1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MyLoadLevel(float delay, int level)
	{
		yield return new WaitForSeconds(delay);
		Application.LoadLevel(level);
	}
	
	

}
