using UnityEngine;
using System.Collections;

public class MovementSpeed : MonoBehaviour {
	
	
	public static int levelSpeed = 1;
	int speed;
	
	void Start () {
		if (CorrectAnswer.level <= 10) {
			levelSpeed = CorrectAnswer.level;
		} else {
			levelSpeed = CorrectAnswer.level - 10;
		}
		speed = Random.Range (170 + levelSpeed * 3, 250 + levelSpeed * 4);
		
		/*
		if (CorrectAnswer.level < 10) {
			levelSpeed = CorrectAnswer.level * 3;
			speed = Random.Range (200 + levelSpeed, 500 + levelSpeed);
	
		}
		if (CorrectAnswer.level == 10) {
			levelSpeed = 1;
		}

		if (CorrectAnswer.level > 10) {
			levelSpeed = CorrectAnswer.level * 3;
			speed = Random.Range (200 + levelSpeed, 500 + levelSpeed);
			
		}
*/
		
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
		
	}
}
