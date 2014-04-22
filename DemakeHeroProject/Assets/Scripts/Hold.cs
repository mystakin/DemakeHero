using UnityEngine;
using System.Collections;
using System;

public class Hold {
	
	public int measure;
	public int beat;
	public bool triplet;
	public int subdivision;
	
	public Hold( int endMeasure, int endBeat, bool newTriplet, int endSubdivision ){
		measure = endMeasure;
		beat = endBeat;
		triplet = newTriplet;
		subdivision = endSubdivision;
	}

}
