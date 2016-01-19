using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class answerScript : MonoBehaviour {
	public int randomAnswer;
	public int answer;
	public int randomNum;
	public int minValue;
	public int maxValue;
	public Text text;
	public GameObject[] players;
	public static int[] answerChoices = new int[10];
	public int counter = 1;
	public bool repeatBoolean;
	// Use this for initialization
	void Start () {
		answer = CollisionScript.currentAnswer;
		minValue = answer - 10;
		maxValue = answer + 10;
		answerChoices [0] = answer;

		while(counter < 10){
			repeatBoolean = false;
			randomNum = Random.Range (minValue, maxValue);
			for(int i = 0; i<counter; i++){
				if(randomNum == answerChoices[i]){
					repeatBoolean = true;
				}
			}
			if(repeatBoolean == false){
				answerChoices[counter] = randomNum;
				counter++;
			}
		}
		shuffle (answerChoices);

		players = GameObject.FindGameObjectsWithTag("answer_1");
		for (int i = 0; i<10; i++) {
			randomNum = Random.Range (minValue, maxValue);
			players[i].GetComponent<Text>().text= answerChoices[i].ToString();
		}

	}

	void shuffle(int[] answerList)
	{
		// Knuth shuffle algorithm :: courtesy of Wikipedia :)
		for (int t = 0; t < answerList.Length; t++ )
		{
			int tmp = answerList[t];
			int r = Random.Range(t, answerList.Length);
			answerList[t] = answerList[r];
			answerList[r] = tmp;
		}
	}
}
