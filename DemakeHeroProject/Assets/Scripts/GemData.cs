using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GemData : MonoBehaviour {

	public List<Gem> gems = new List<Gem>();
	public List<Chord> chords = new List<Chord>();
	public List<Hold> holds = new List<Hold>();
	public BPMLines bpmLines;

	void Start(){
		bpmLines = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<BPMLines>();

		/*Identities
		 * 0 = Green		
		 * 1 = Red			
		 * 2 = Yellow		
		 * 3 = Blue			
		 * 4 = Orange		
		 */
		chords.Add( new Chord(0, 1, 2, 0, 0, 16) );
		chords.Add( new Chord(1, 3, 4, 0, 0, 8) );
		chords.Add( new Chord(2, 4, 5, 0, 0, 8) );
		chords.Add( new Chord(0, 1, 6, 0, 0, 16) );
		chords.Add( new Chord(1, 3, 8, 0, 0, 8) );
		chords.Add( new Chord(2, 4, 9, 0, 0, 8) );
		chords.Add( new Chord(0, 1, 10, 0, 0) );
		gems.Add( new Gem(3, 10, 1, 0) );
		gems.Add( new Gem(3, 10, 2, 0) );
		gems.Add( new Gem(3, 10, 3, 0) );
		gems.Add( new Gem(2, 11, 0, 0, 8) );
		gems.Add( new Gem(0, 12, 1, 0) );
		gems.Add( new Gem(0, 12, 2, 0) );
		gems.Add( new Gem(0, 12, 3, 0) );
		gems.Add( new Gem(1, 13, 0, 0, 4) );
		gems.Add( new Gem(1, 13, 2, 0) );
		gems.Add( new Gem(2, 13, 3, 0) );
		gems.Add( new Gem(3, 14, 1, 0) );
		gems.Add( new Gem(3, 14, 2, 0) );
		gems.Add( new Gem(3, 14, 3, 0) );
		gems.Add( new Gem(2, 15, 0, 0, 8) );
		gems.Add( new Gem(0, 16, 1, 0) );
		gems.Add( new Gem(0, 16, 2, 0) );
		gems.Add( new Gem(0, 16, 3, 0) );
		gems.Add( new Gem(1, 17, 0, 0, 4) );
		gems.Add( new Gem(1, 17, 2, 0) );
		gems.Add( new Gem(2, 17, 3, 0) );
		gems.Add( new Gem(4, 18, 1, 0) );
		gems.Add( new Gem(3, 18, 2, 0) );
		gems.Add( new Gem(4, 18, 2, 8) );
		gems.Add( new Gem(3, 18, 3, 0) );
		gems.Add( new Gem(2, 18, 3, 8) );
		gems.Add( new Gem(3, 19, 0, 0, 8) );
		gems.Add( new Gem(1, 20, 1, 0) );
		gems.Add( new Gem(1, 20, 2, 0) );
		gems.Add( new Gem(2, 20, 2, 8) );
		gems.Add( new Gem(2, 20, 3, 0) );
		gems.Add( new Gem(2, 21, 1, 0) );
		gems.Add( new Gem(2, 21, 2, 0) );
		gems.Add( new Gem(3, 21, 2, 8) );
		gems.Add( new Gem(3, 21, 3, 0) );

		gems.Add( new Gem(4, 22, 1, 0) );
		gems.Add( new Gem(3, 22, 2, 0) );
		gems.Add( new Gem(4, 22, 2, 8) );
		gems.Add( new Gem(3, 22, 3, 0) );
		gems.Add( new Gem(2, 22, 3, 8) );

		gems.Add( new Gem(3, 23, 0, 0) );
		gems.Add( new Gem(4, 23, 0, 4) );
		gems.Add( new Gem(3, 23, 0, 8) );
		gems.Add( new Gem(4, 23, 0, 12) );
		gems.Add( new Gem(3, 23, 1, 0) );
		gems.Add( new Gem(4, 23, 1, 4) );
		gems.Add( new Gem(3, 23, 1, 8) );
		gems.Add( new Gem(4, 23, 1, 12) );
		gems.Add( new Gem(3, 23, 2, 0) );
		gems.Add( new Gem(4, 23, 2, 4) );
		gems.Add( new Gem(3, 23, 2, 8) );
		gems.Add( new Gem(4, 23, 2, 12) );
		gems.Add( new Gem(3, 23, 3, 0) );
		gems.Add( new Gem(4, 23, 3, 4) );
		gems.Add( new Gem(3, 23, 3, 8) );
		gems.Add( new Gem(4, 23, 3, 12) );

		gems.Add( new Gem(1, 24, 1, 0) );
		gems.Add( new Gem(1, 24, 2, 0) );
		gems.Add( new Gem(2, 24, 2, 8) );
		gems.Add( new Gem(2, 24, 3, 0) );

		gems.Add( new Gem(4, 25, 0, 0) );

		gems.Add( new Gem(3, 25, 1, 0) );

		gems.Add( new Gem(2, 25, 2, 0) );
		gems.Add( new Gem(3, 25, 2, 8) );
		gems.Add( new Gem(2, 25, 3, 0) );

		gems.Add( new Gem(1, 26, 0, 0, 16) );



		chords.Add( new Chord(0, 1, 30, 0, 0) );

		gems.Add( new Gem(0, 30, 1, 0) );
		gems.Add( new Gem(0, 30, 1, 8) );
		gems.Add( new Gem(0, 30, 2, 0) );
		gems.Add( new Gem(0, 30, 2, 8) );
		gems.Add( new Gem(0, 30, 3, 0) );
		gems.Add( new Gem(0, 30, 3, 8) );

		gems.Add( new Gem(0, 31, 0, 0) );
		gems.Add( new Gem(0, 31, 0, 8) );
		gems.Add( new Gem(0, 31, 1, 0) );
		gems.Add( new Gem(0, 31, 1, 8) );
		gems.Add( new Gem(0, 31, 2, 0) );
		gems.Add( new Gem(0, 31, 2, 8) );
		gems.Add( new Gem(0, 31, 3, 0) );
		gems.Add( new Gem(0, 31, 3, 8) );

		chords.Add( new Chord(1, 3, 32, 0, 0) );
		
		gems.Add( new Gem(1, 32, 1, 0) );
		gems.Add( new Gem(1, 32, 1, 8) );
		gems.Add( new Gem(1, 32, 2, 0) );
		gems.Add( new Gem(1, 32, 2, 8) );
		gems.Add( new Gem(1, 32, 3, 0) );
		gems.Add( new Gem(1, 32, 3, 8) );

		chords.Add( new Chord(2, 4, 33, 0, 0) );
		
		gems.Add( new Gem(2, 33, 1, 0) );
		gems.Add( new Gem(2, 33, 1, 8) );
		gems.Add( new Gem(2, 33, 2, 0) );
		chords.Add( new Chord(2, 4, 33, 2, 8) );
		gems.Add( new Gem(2, 33, 3, 0) );
		chords.Add( new Chord(2, 4, 33, 3, 8) );

		chords.Add( new Chord(0, 1, 34, 0, 0) );
		
		gems.Add( new Gem(0, 34, 1, 0) );
		gems.Add( new Gem(0, 34, 1, 8) );
		gems.Add( new Gem(0, 34, 2, 0) );
		gems.Add( new Gem(0, 34, 2, 8) );
		gems.Add( new Gem(0, 34, 3, 0) );
		gems.Add( new Gem(0, 34, 3, 8) );
		
		gems.Add( new Gem(0, 35, 0, 0) );
		gems.Add( new Gem(0, 35, 0, 8) );
		gems.Add( new Gem(0, 35, 1, 0) );
		gems.Add( new Gem(0, 35, 1, 8) );
		gems.Add( new Gem(0, 35, 2, 0) );
		gems.Add( new Gem(0, 35, 2, 8) );
		gems.Add( new Gem(0, 35, 3, 0) );
		gems.Add( new Gem(0, 35, 3, 8) );
		
		chords.Add( new Chord(1, 3, 36, 0, 0) );
		
		gems.Add( new Gem(1, 36, 1, 0) );
		gems.Add( new Gem(1, 36, 1, 8) );
		gems.Add( new Gem(1, 36, 2, 0) );
		gems.Add( new Gem(1, 36, 2, 8) );
		gems.Add( new Gem(1, 36, 3, 0) );
		gems.Add( new Gem(1, 36, 3, 8) );

		gems.Add( new Gem(0, 37, 0, 0) );
		gems.Add( new Gem(1, 37, 0, 8) );
		gems.Add( new Gem(2, 37, 1, 0) );
		gems.Add( new Gem(1, 37, 1, 8) );
		gems.Add( new Gem(2, 37, 2, 0) );
		gems.Add( new Gem(3, 37, 2, 8) );
		gems.Add( new Gem(2, 37, 3, 0) );
		gems.Add( new Gem(3, 37, 3, 8) );
		gems.Add( new Gem(2, 38, 0, 0) );

		gems.Add( new Gem(2, 38, 1, 0) );
		gems.Add( new Gem(2, 38, 1, 8) );
		gems.Add( new Gem(1, 38, 2, 0) );

		gems.Add( new Gem(1, 38, 3, 0) );
		gems.Add( new Gem(1, 38, 3, 8) );
		gems.Add( new Gem(4, 39, 0, 0) );
		gems.Add( new Gem(4, 39, 0, 8) );
		gems.Add( new Gem(4, 39, 1, 0) );
		gems.Add( new Gem(3, 39, 1, 8) );

		gems.Add( new Gem(3, 39, 2, 8) );
		gems.Add( new Gem(3, 39, 3, 0) );
		gems.Add( new Gem(3, 39, 3, 8) );

		gems.Add( new Gem(0, 40, 0, true, 0) );
		gems.Add( new Gem(1, 40, 0, true, 4) );
		gems.Add( new Gem(2, 40, 0, true, 8) );
		gems.Add( new Gem(3, 40, 1, true, 0) );
		gems.Add( new Gem(1, 40, 1, true, 4) );
		gems.Add( new Gem(2, 40, 1, true, 8) );
		gems.Add( new Gem(3, 40, 2, true, 0) );
		gems.Add( new Gem(2, 40, 2, true, 4) );
		gems.Add( new Gem(3, 40, 2, true, 8) );
		gems.Add( new Gem(4, 40, 3, true, 0) );
		gems.Add( new Gem(3, 40, 3, true, 4) );
		gems.Add( new Gem(2, 40, 3, true, 8) );

		gems.Add( new Gem(3, 41, 0, true, 0) );
		gems.Add( new Gem(2, 41, 0, true, 4) );
		gems.Add( new Gem(2, 41, 0, true, 8) );
		gems.Add( new Gem(4, 41, 1, true, 0) );
		gems.Add( new Gem(2, 41, 1, true, 4) );
		gems.Add( new Gem(2, 41, 1, true, 8) );
		gems.Add( new Gem(3, 41, 2, true, 0) );
		gems.Add( new Gem(2, 41, 2, true, 4) );
		gems.Add( new Gem(3, 41, 2, true, 8) );
		gems.Add( new Gem(2, 41, 3, true, 0) );
		gems.Add( new Gem(1, 41, 3, true, 4) );
		gems.Add( new Gem(2, 41, 3, true, 8) );
		gems.Add( new Gem(0, 42, 0, 0, 16) );

		gems.Add( new Gem(1, 44, 0, 0, 6) );

		gems.Add( new Gem(4, 44, 3, 0) );
		gems.Add( new Gem(3, 45, 0, 0, 3) );

		gems.Add( new Gem(2, 45, 1, 8, 3) );

		gems.Add( new Gem(0, 45, 3, 0) );

		gems.Add( new Gem(1, 46, 0, 0) );
		gems.Add( new Gem(2, 46, 0, 8, 4) );

		gems.Add( new Gem(2, 46, 2, 0) );
		gems.Add( new Gem(2, 46, 2, 8) );
		gems.Add( new Gem(2, 46, 3, 0) );
		gems.Add( new Gem(2, 46, 3, 8) );
		gems.Add( new Gem(1, 47, 0, 0) );
		gems.Add( new Gem(3, 47, 0, 8, 4) );

		gems.Add( new Gem(3, 47, 2, 0) );
		gems.Add( new Gem(3, 47, 2, 8) );
		gems.Add( new Gem(3, 47, 3, 0) );
		gems.Add( new Gem(3, 47, 3, 8) );
		gems.Add( new Gem(2, 48, 0, 0) );
		gems.Add( new Gem(4, 48, 0, 8, 4) );

		gems.Add( new Gem(4, 48, 2, 0) );
		gems.Add( new Gem(4, 48, 2, 8) );
		gems.Add( new Gem(3, 48, 3, 0) );
		gems.Add( new Gem(2, 48, 3, 8) );
		gems.Add( new Gem(3, 49, 0, 0, 3) );

		gems.Add( new Gem(1, 49, 1, 8, 3) );

		gems.Add( new Gem(2, 49, 3, 0) );

		gems.Add( new Gem(0, 50, 0, 0, 8) );



		chords.Add( new Chord(1, 3, 57, 0, 0) );

		gems.Add( new Gem(0, 57, 3, 0) );
		gems.Add( new Gem(0, 57, 3, 8) );

		chords.Add( new Chord(1, 3, 58, 0, 0) );

		gems.Add( new Gem(0, 58, 3, 0) );
		gems.Add( new Gem(0, 58, 3, 8) );

		chords.Add( new Chord(1, 3, 59, 0, 0) );
		
		gems.Add( new Gem(0, 59, 3, 0) );
		gems.Add( new Gem(0, 59, 3, 8) );


		chords.Add( new Chord(3, 4, 60, 0, 0, 4) );

		chords.Add( new Chord(2, 4, 60, 2, 0) );

		chords.Add( new Chord(1, 2, 60, 3, 0) );
		chords.Add( new Chord(1, 3, 60, 3, 8) );

		chords.Add( new Chord(1, 3, 61, 0, 0) );

		gems.Add( new Gem(0, 61, 3, 0) );
		gems.Add( new Gem(0, 61, 3, 4) );
		gems.Add( new Gem(0, 61, 3, 8) );
		gems.Add( new Gem(0, 61, 3, 12) );

		chords.Add( new Chord(1, 3, 62, 0, 0) );

		gems.Add( new Gem(0, 62, 2, 0) );
		gems.Add( new Gem(0, 62, 2, 4) );

		gems.Add( new Gem(0, 62, 2, 12) );
		gems.Add( new Gem(0, 62, 3, 0) );

		gems.Add( new Gem(0, 62, 3, 8) );
		gems.Add( new Gem(0, 62, 3, 12) );

		chords.Add( new Chord(1, 3, 63, 0, 0) );

		gems.Add( new Gem(0, 63, 3, 0) );
		gems.Add( new Gem(0, 63, 3, 8) );

		chords.Add( new Chord(3, 4, 64, 0, 0, 4) );
		
		chords.Add( new Chord(2, 4, 64, 2, 0) );
		
		chords.Add( new Chord(1, 2, 64, 3, 0) );
		chords.Add( new Chord(1, 3, 64, 3, 8) );
		
		gems.Add( new Gem(2, 65, 0, 0) );
		gems.Add( new Gem(0, 65, 0, 4) );
		gems.Add( new Gem(0, 65, 0, 8) );
		gems.Add( new Gem(1, 65, 0, 12) );
		gems.Add( new Gem(0, 65, 1, 0) );
		gems.Add( new Gem(0, 65, 1, 4) );
		gems.Add( new Gem(2, 65, 1, 8) );
		gems.Add( new Gem(0, 65, 1, 12) );
		gems.Add( new Gem(0, 65, 2, 0) );
		gems.Add( new Gem(1, 65, 2, 4) );
		gems.Add( new Gem(0, 65, 2, 8) );
		gems.Add( new Gem(0, 65, 2, 12) );
		gems.Add( new Gem(2, 65, 3, 0) );
		gems.Add( new Gem(0, 65, 3, 4) );
		gems.Add( new Gem(3, 65, 3, 8) );
		gems.Add( new Gem(0, 65, 3, 12) );

		gems.Add( new Gem(2, 66, 0, 0) );
		gems.Add( new Gem(0, 66, 0, 4) );
		gems.Add( new Gem(0, 66, 0, 8) );
		gems.Add( new Gem(1, 66, 0, 12) );
		gems.Add( new Gem(0, 66, 1, 0) );
		gems.Add( new Gem(0, 66, 1, 4) );
		gems.Add( new Gem(2, 66, 1, 8) );
		gems.Add( new Gem(0, 66, 1, 12) );
		gems.Add( new Gem(0, 66, 2, 0) );
		gems.Add( new Gem(1, 66, 2, 4) );
		gems.Add( new Gem(0, 66, 2, 8) );
		gems.Add( new Gem(0, 66, 2, 12) );
		gems.Add( new Gem(2, 66, 3, 0) );
		gems.Add( new Gem(0, 66, 3, 4) );
		gems.Add( new Gem(3, 66, 3, 8) );
		gems.Add( new Gem(0, 66, 3, 12) );

		gems.Add( new Gem(2, 67, 0, 0) );
		gems.Add( new Gem(0, 67, 0, 4) );
		gems.Add( new Gem(0, 67, 0, 8) );
		gems.Add( new Gem(1, 67, 0, 12) );
		gems.Add( new Gem(0, 67, 1, 0) );
		gems.Add( new Gem(0, 67, 1, 4) );
		gems.Add( new Gem(2, 67, 1, 8) );
		gems.Add( new Gem(0, 67, 1, 12) );
		gems.Add( new Gem(0, 67, 2, 0) );
		gems.Add( new Gem(1, 67, 2, 4) );
		gems.Add( new Gem(0, 67, 2, 8) );
		gems.Add( new Gem(0, 67, 2, 12) );
		gems.Add( new Gem(2, 67, 3, 0) );
		gems.Add( new Gem(0, 67, 3, 4) );
		gems.Add( new Gem(3, 67, 3, 8) );
		gems.Add( new Gem(0, 67, 3, 12) );

		gems.Add( new Gem(4, 68, 0, 0) );
		gems.Add( new Gem(4, 68, 0, 4) );
		gems.Add( new Gem(4, 68, 0, 8) );
		gems.Add( new Gem(4, 68, 0, 12) );
		gems.Add( new Gem(4, 68, 1, 0) );
		gems.Add( new Gem(4, 68, 1, 4) );
		gems.Add( new Gem(4, 68, 1, 8) );
		gems.Add( new Gem(4, 68, 1, 12) );
		gems.Add( new Gem(3, 68, 2, 0) );
		gems.Add( new Gem(3, 68, 2, 4) );
		gems.Add( new Gem(3, 68, 2, 8) );
		gems.Add( new Gem(3, 68, 2, 12) );
		gems.Add( new Gem(1, 68, 3, 0) );
		gems.Add( new Gem(1, 68, 3, 4) );
		gems.Add( new Gem(2, 68, 3, 8) );
		gems.Add( new Gem(2, 68, 3, 12) );

		gems.Add( new Gem(2, 69, 0, 0) );
		gems.Add( new Gem(0, 69, 0, 4) );
		gems.Add( new Gem(0, 69, 0, 8) );
		gems.Add( new Gem(1, 69, 0, 12) );
		gems.Add( new Gem(0, 69, 1, 0) );
		gems.Add( new Gem(0, 69, 1, 4) );
		gems.Add( new Gem(2, 69, 1, 8) );
		gems.Add( new Gem(0, 69, 1, 12) );
		gems.Add( new Gem(0, 69, 2, 0) );
		gems.Add( new Gem(1, 69, 2, 4) );
		gems.Add( new Gem(0, 69, 2, 8) );
		gems.Add( new Gem(0, 69, 2, 12) );
		gems.Add( new Gem(2, 69, 3, 0) );
		gems.Add( new Gem(0, 69, 3, 4) );
		gems.Add( new Gem(3, 69, 3, 8) );
		gems.Add( new Gem(0, 69, 3, 12) );
		
		gems.Add( new Gem(2, 70, 0, 0) );
		gems.Add( new Gem(0, 70, 0, 4) );
		gems.Add( new Gem(0, 70, 0, 8) );
		gems.Add( new Gem(1, 70, 0, 12) );
		gems.Add( new Gem(0, 70, 1, 0) );
		gems.Add( new Gem(0, 70, 1, 4) );
		gems.Add( new Gem(2, 70, 1, 8) );
		gems.Add( new Gem(0, 70, 1, 12) );
		gems.Add( new Gem(0, 70, 2, 0) );
		gems.Add( new Gem(1, 70, 2, 4) );
		gems.Add( new Gem(0, 70, 2, 8) );
		gems.Add( new Gem(0, 70, 2, 12) );
		gems.Add( new Gem(2, 70, 3, 0) );
		gems.Add( new Gem(0, 70, 3, 4) );
		gems.Add( new Gem(3, 70, 3, 8) );
		gems.Add( new Gem(0, 70, 3, 12) );
	
		gems.Add( new Gem(2, 71, 0, 0) );
		gems.Add( new Gem(0, 71, 0, 4) );
		gems.Add( new Gem(0, 71, 0, 8) );
		gems.Add( new Gem(1, 71, 0, 12) );
		gems.Add( new Gem(0, 71, 1, 0) );
		gems.Add( new Gem(0, 71, 1, 4) );
		gems.Add( new Gem(2, 71, 1, 8) );
		gems.Add( new Gem(0, 71, 1, 12) );
		gems.Add( new Gem(0, 71, 2, 0) );
		gems.Add( new Gem(1, 71, 2, 4) );
		gems.Add( new Gem(0, 71, 2, 8) );
		gems.Add( new Gem(0, 71, 2, 12) );
		gems.Add( new Gem(2, 71, 3, 0) );
		gems.Add( new Gem(0, 71, 3, 4) );
		gems.Add( new Gem(3, 71, 3, 8) );
		gems.Add( new Gem(0, 71, 3, 12) );
		
		gems.Add( new Gem(4, 72, 0, 0) );
		gems.Add( new Gem(4, 72, 0, 4) );
		gems.Add( new Gem(4, 72, 0, 8) );
		gems.Add( new Gem(4, 72, 0, 12) );
		gems.Add( new Gem(4, 72, 1, 0) );
		gems.Add( new Gem(4, 72, 1, 4) );
		gems.Add( new Gem(4, 72, 1, 8) );
		gems.Add( new Gem(4, 72, 1, 12) );
		gems.Add( new Gem(3, 72, 2, 0) );
		gems.Add( new Gem(3, 72, 2, 4) );
		gems.Add( new Gem(3, 72, 2, 8) );
		gems.Add( new Gem(3, 72, 2, 12) );
		gems.Add( new Gem(1, 72, 3, 0) );
		gems.Add( new Gem(1, 72, 3, 4) );
		gems.Add( new Gem(2, 72, 3, 8) );
		gems.Add( new Gem(2, 72, 3, 12) );

		chords.Add( new Chord(0, 1, 73, 0, 0, 16) );

		for( int i = 1; i < gems.Count; i++ ){
			//gems[i].measure + gems[i].beat + gems[i].subdivision
			float gemTime = 0;
			float prevGemTime = 0;

			gems[i].index = i;

			gemTime = mbtToTime(gemTime, gems[i]);
			prevGemTime = mbtToTime(prevGemTime, gems[i-1]);

			if( Mathf.Abs(prevGemTime - gemTime) < 0.20f && gems[i].identity != gems[i-1].identity ){
				gems[i].hopo = true;
			}
			else{
				gems[i].hopo = false;
			}
		}

		for( int i = 1; i < chords.Count; i++ ){
			chords[i].index = i;
		}

	}

	float mbtToTime(float time, Gem timeGem){
		float floatBeat = timeGem.beat;
		float floatSub = timeGem.subdivision;

		time += timeGem.measure;
		time += floatBeat / 4;

		if( !timeGem.triplet ){
			time += floatSub / bpmLines.sixtyFourthsPerSecond;
		}
		else{
			time += floatSub / bpmLines.thirtySecondTripletsPerSecond;
		}

		return time;
	}


}
