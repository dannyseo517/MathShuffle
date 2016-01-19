using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CorrectAnswer : MonoBehaviour {
	public int answer;
	public string textCard;
	public GameObject gameobj;
	public GameObject[] buttonObj;
	public Button button;
	public Text text;
	public bool changeScene = false;
	public static bool correct = false;
	public static int score = 0;
	public static int Lives = 3;
	public static int level = 1;
	public AudioSource au_answerSound;
	public bool gameOver = false;
	
	// Use this for initialization
	public void Correct1 (string name) {
		gameobj = GameObject.Find(name);
		textCard = gameobj.GetComponent<Text> ().text;
		text = gameobj.GetComponent<Text> ();
		string parentObj = gameobj.transform.parent.name;
		answer = CollisionScript.currentAnswer;
		buttonObj = GameObject.FindGameObjectsWithTag("card");
		if (textCard.ToString () == answer.ToString ()) {
			au_answerSound = (AudioSource)GameObject.Find ("CorrectAnswerSound").GetComponent(typeof (AudioSource));
			au_answerSound.Play ();
			//print ("correct answer");
			text.text = "\u2714";
			Image img =  GameObject.Find(parentObj).GetComponent<Image>();
			img.color = UnityEngine.Color.green;
			correct = true;
			score += CountdownBar.timerScore;
			level++;
			SpawnRandom.maxCards += 2;
			CountdownBar.start = false;
			Achievements.streak++;
			
		} else {
			au_answerSound = (AudioSource)GameObject.Find ("WrongAnswerSound").GetComponent(typeof (AudioSource));
			au_answerSound.Play ();
			//print ("wrong answer");
			text.text = "\u2717";
			Image img =  GameObject.Find(parentObj).GetComponent<Image>();
			img.color = UnityEngine.Color.red;
			correct = false;
			if(--Lives == 0)
				gameOver = true;
			level++;
			SpawnRandom.maxCards += 2;
			CountdownBar.start = false;
			Achievements.streak = 0;
		}
		
		for (int i = 0; i<10; i++){
			button = buttonObj[i].GetComponent<Button>();
			button.enabled = !button.enabled;
		}
		changeScene = true;
		CollisionScript.destroyCount = 0;
		CollisionScript.currentAnswer = 0;
		RandomEquationHeart.totalAnswerHeart = 0;
		RandomEquationSpade.totalAnswerSpade = 0;
		RandomEquationClub.totalAnswerClub = 0;
		RandomEquationDiamond.totalAnswerDiamond = 0;
		CountdownBar.timerScore = 100;
	}
	
	void Update(){
		if (changeScene == true) {
			StartCoroutine("WaitForQuestions");
		}
		if (gameOver == true) {
			StartCoroutine("WaitForGameOver");
		}
	}
	
	IEnumerator WaitForQuestions() {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("Questions");
	}

	IEnumerator WaitForGameOver() {
		yield return new WaitForSeconds(5);
		Application.LoadLevel("GameOver");
	}
	
}