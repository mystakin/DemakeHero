using UnityEngine;
using System.Collections;
using System;

public class Gem {

	public int index;
	public int identity;
	public int measure;
	public int beat;
	public bool triplet;
	public int subdivision;
	public bool hopo;
	public float holdDuration;
	public bool active;

	public Gem( int newIdentity, int newMeasure, int newBeat, bool newTriplet, int newSubdivision ){
		identity = newIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = newTriplet;
		subdivision = newSubdivision;
		holdDuration = 0f;
	}

	public Gem( int newIdentity, int newMeasure, int newBeat, int newSubdivision ){
		identity = newIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = false;
		subdivision = newSubdivision;
		holdDuration = 0f;
	}

	public Gem( int newIdentity, int newMeasure, int newBeat, int newSubdivision, float newHold ){
		identity = newIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = false;
		subdivision = newSubdivision;
		holdDuration = newHold;
	}
}
