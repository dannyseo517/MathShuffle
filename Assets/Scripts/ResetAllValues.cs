using UnityEngine;
using System.Collections;

public class ResetAllValues : MonoBehaviour {

	// Use this for initialization
	public void Reset () {
		CorrectAnswer.score = 0;
		CorrectAnswer.Lives = 5;
		CollisionScript.destroyCount = 0;
		CollisionScript.currentAnswer = 0;
		RandomEquationHeart.totalAnswerHeart = 0;
		RandomEquationSpade.totalAnswerSpade = 0;
		RandomEquationClub.totalAnswerClub = 0;
		RandomEquationDiamond.totalAnswerDiamond = 0;
		CorrectAnswer.level = 1;
	}

}
