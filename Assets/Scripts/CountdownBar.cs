using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownBar : MonoBehaviour {



	private float myTimer = 10;
	public RectTransform countdownBar;
	public static int timerScore;
	public float barLength;
	public static bool start = true;
	public GameObject[] buttonObj;
	public Button button;
	public bool changeScene = false;
	private bool gameOver = false;

	public AudioSource au_answerSound;

	// Use this for initialization
	void Start () {
		start = true;
		countdownBar = gameObject.GetComponent<RectTransform> ();
		barLength = countdownBar.rect.width;
		//print (barLength);
		buttonObj = GameObject.FindGameObjectsWithTag("card");
	}
	
	// Update is called once per frame
	void Update () {
		if (start == true) {
			if (myTimer > 0) {
				myTimer -= Time.deltaTime;
				
			}
			if (myTimer <= 0) {
				--CorrectAnswer.Lives;
				au_answerSound = (AudioSource)GameObject.Find ("WrongAnswerSound").GetComponent(typeof (AudioSource));
				au_answerSound.Play ();
				Debug.Log ("Game Over");
				start = false;
				for (int i = 0; i<10; i++){
					button = buttonObj[i].GetComponent<Button>();
					button.enabled = !button.enabled;
				}
				if(CorrectAnswer.Lives == 0){
					gameOver = true;
				}
				if(CorrectAnswer.Lives > 0){
					changeScene = true;
				}
			}

			transform.Translate (Vector3.left * (barLength/1190) * (1.8f));
		}
		timerScore = ((int)myTimer + 1) * 10;
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
