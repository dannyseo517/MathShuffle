using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelDebug : MonoBehaviour {
	
	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
	}
	
	
	void Start (){
		text.text = "Level " + CorrectAnswer.level;
		
	}
	
}
