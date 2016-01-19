using UnityEngine;
using System.Collections;

public class ScreenManager : MonoBehaviour {

	public void LoadGame(string name){
		/*AudioSource au_button;
		if (au_button = (AudioSource)GameObject.Find ("ButtonSound").GetComponent("AudioSource")) {
			au_button.Play ();
		} else {
			print ("No audio");
		}
		 All I want to do is play the button noise on scene changes. Nothing works though =/*/
		if (name == "Main") {
			print("dfsdfsdfsfdsfsdfsf");
			CorrectAnswer.score = 0;
			CorrectAnswer.Lives = 3;
			CollisionScript.destroyCount = 0;
			CollisionScript.currentAnswer = 0;
			RandomEquationHeart.totalAnswerHeart = 0;
			RandomEquationSpade.totalAnswerSpade = 0;
			RandomEquationClub.totalAnswerClub = 0;
			RandomEquationDiamond.totalAnswerDiamond = 0;
			CorrectAnswer.level = 1;

		}
		Debug.Log ("Screen load requested for: " + name);
		Application.LoadLevel(name);


	}

	
}
