using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointIndicator : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CountdownBar.start == false) {
			if(CorrectAnswer.correct == true){
				text.text = "+ " + CountdownBar.timerScore.ToString();
			}
			else{
				text.text = "- " + "life";
			}
		}
	}
}
