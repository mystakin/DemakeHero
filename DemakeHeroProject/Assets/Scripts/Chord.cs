using UnityEngine;
using System.Collections;
using System;

public class Chord {

	public int index;
	public int firstIdentity;
	public int secondIdentity;
	public int measure;
	public int beat;
	public bool triplet;
	public int subdivision;
	public float holdDuration;
	public bool active;
	
	public Chord( int newFirstIdentity, int newSecondIdentity, int newMeasure, int newBeat, bool newTriplet, int newSubdivision ){
		firstIdentity = newFirstIdentity;
		secondIdentity = newSecondIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = newTriplet;
		subdivision = newSubdivision;
		holdDuration = 0f;
	}

	public Chord( int newFirstIdentity, int newSecondIdentity, int newMeasure, int newBeat, int newSubdivision ){
		firstIdentity = newFirstIdentity;
		secondIdentity = newSecondIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = false;
		subdivision = newSubdivision;
		holdDuration = 0f;
	}

	public Chord( int newFirstIdentity, int newSecondIdentity, int newMeasure, int newBeat, int newSubdivision, float newHold ){
		firstIdentity = newFirstIdentity;
		secondIdentity = newSecondIdentity;
		measure = newMeasure;
		beat = newBeat;
		triplet = false;
		subdivision = newSubdivision;
		holdDuration = newHold;
	}
}
