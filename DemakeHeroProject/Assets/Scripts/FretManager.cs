using UnityEngine;
using System.Collections;

public class FretManager : MonoBehaviour {

	public Sprite[] fretDefault = new Sprite[5];
	public Sprite[] fretActive = new Sprite[5];
	public Sprite[] fretStrike = new Sprite[5];
	public InputManager inputManager;

	public SpriteRenderer[] bridgeSprites = new SpriteRenderer[5];
	public float strikeCooldown;

	// Use this for initialization
	void Awake () {
		strikeCooldown = 0;
		inputManager = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<InputManager>();

		bridgeSprites[0] = GameObject.FindGameObjectWithTag(Tags.green).GetComponent<SpriteRenderer>();
		bridgeSprites[1] = GameObject.FindGameObjectWithTag(Tags.red).GetComponent<SpriteRenderer>();
		bridgeSprites[2] = GameObject.FindGameObjectWithTag(Tags.yellow).GetComponent<SpriteRenderer>();
		bridgeSprites[3] = GameObject.FindGameObjectWithTag(Tags.blue).GetComponent<SpriteRenderer>();
		bridgeSprites[4] = GameObject.FindGameObjectWithTag(Tags.orange).GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		ManageFrets();

		if( strikeCooldown > 0 )
			strikeCooldown -= Time.fixedDeltaTime;
	}

	void ManageFrets(){
		for( int i = 0; i < 5; i++ ){
			if( inputManager.bridge[i] == true ){
				if( strikeCooldown > 0 ){
					bridgeSprites[i].sprite = fretStrike[i];
				}
				else{
					bridgeSprites[i].sprite = fretActive[i];
				}
			}
			else{
				bridgeSprites[i].sprite = fretDefault[i];
			}
		}

		if( inputManager.strum == true ){
			strikeCooldown = 0.2f;
		}
	}
}
