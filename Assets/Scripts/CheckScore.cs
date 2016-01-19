using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class CheckScore : MonoBehaviour {
	private bool compared = false;
	private Text highscores;
	private GameObject overlay;
	// Use this for initialization
	void Awake () {
		highscores = GameObject.Find ("CheckScore").GetComponent<Text> ();
		overlay = GameObject.Find ("Highscore Overlay");
		overlay.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (!compared && !string.Equals (highscores.text, "Loading Scores")) {

			// Puts each integer into a returned array.
			string[] allScores = Regex.Split (highscores.text, @"\D+");
			
			foreach (string score in allScores) {
				if (!string.IsNullOrEmpty (score)) {
					int value = int.Parse (score);
					if (CorrectAnswer.score >= value) {
						overlay.SetActive(true);
						compared = true;
						return;
					}
				}
			}
			compared = true; 
		}
	}
}
