using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	private Text text;
	private HSController scorePoster;
	public static string playerName;
	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		text.text = CorrectAnswer.score.ToString ();
	}
	
	// Update is called once per frame
	public void SubmitScore () {
		scorePoster = gameObject.GetComponent<HSController>();
		scorePoster.postScore (playerName, CorrectAnswer.score);
	}
}
