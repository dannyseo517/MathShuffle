using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestionManager : MonoBehaviour {

	public static int LEVEL = 1;
	public static string suitQuestion;
	private string[] suits = new string[] {"Club", "Spade", "Diamond", "Heart"};
	public int randomNum;
	public int min = 0;
	public int max = 4;
	public Text text;
	// Use this for initialization
	void Start () {
		randomNum = Random.Range (min, max);
		suitQuestion = suits [randomNum];
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Add all " + suitQuestion + "\nsuited cards";
	}
}
