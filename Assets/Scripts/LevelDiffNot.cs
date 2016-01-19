using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelDiffNot : MonoBehaviour {
	
	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
	}
	
	
	void Start (){
		
		if (CorrectAnswer.level == 3)
			text.text = "Equations added";
		
		
		if (CorrectAnswer.level == 4)
			text.text = "Equations added";

		if (CorrectAnswer.level == 5)
			text.text = "Equations added";	

		if (CorrectAnswer.level == 4)
			text.text = "Equations added";	
		
	}		
}
