using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
	}
	
	
	void Update (){

			text.text = "" + CorrectAnswer.score;

	}
	
}
