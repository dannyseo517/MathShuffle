using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
	}
	
	
	void Update (){
		text.text = "x " + CorrectAnswer.Lives;
		
	}
	
}
