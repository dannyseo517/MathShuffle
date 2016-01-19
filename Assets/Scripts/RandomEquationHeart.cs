using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RandomEquationHeart : MonoBehaviour {
	
	public int x;
	public int y;
	public int answer;
	public static int totalAnswerHeart;
	public string equation; 
	public int lowLevel;
	public int medLevel;
	public int highLevel;
	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
		x = Random.Range (1,10);
		y = Random.Range (1,10);
		lowLevel = Random.Range (1,3);
		medLevel = Random.Range (1,4);
		highLevel = Random.Range (1,5);
	}
	
	void Start (){
		
		if (CorrectAnswer.level == 1 || CorrectAnswer.level == 2) {
			equation = " ";
			text.text = x + equation;
			answer = x;
			totalAnswerHeart += answer;
		} else {
			if (CorrectAnswer.level == 3) {
				switch (lowLevel) {
				case 1:
					equation = "+";
					text.text = x + equation + y;
					answer = x + y;
					totalAnswerHeart += answer;
					break;
				case 2:
					equation = " ";
					text.text = x + equation;
					answer = x;
					totalAnswerHeart += answer;
					break;
				}
			} else {
				if (CorrectAnswer.level == 4) {
					switch (medLevel) {
					case 1:
						equation = "+";
						text.text = x + equation + y;
						answer = x + y;
						totalAnswerHeart += answer;
						break;
					case 2:
						equation = "-";
						text.text = x + equation + y;
						answer = x - y;
						totalAnswerHeart += answer;
						break;
					case 3:
						equation = " ";
						text.text = x + equation;
						answer = x;
						totalAnswerHeart += answer;
						break;
					}
				} else {
					if (CorrectAnswer.level >= 5) {
						switch (highLevel) {
						case 1:
							equation = "+";
							text.text = x + equation + y;
							answer = x + y;
							totalAnswerHeart += answer;
							break;
						case 2:
							equation = "-";
							text.text = x + equation + y;
							answer = x - y;
							totalAnswerHeart += answer;
							break;
						case 3:
							equation = " ";
							text.text = x + equation;
							answer = x;
							totalAnswerHeart += answer;
							break;
						case 4:
							equation = "x";
							text.text = x + equation + y;
							answer = x * y;
							totalAnswerHeart += answer;
							break;
						}
					}	
				}
			}
		}
	}
}
