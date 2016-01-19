using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollisionScript : MonoBehaviour {
    public static int currentAnswer = 0;
	public static int destroyCount = 0;
	//Will destroy all card after reasching the object attached with this script
	void OnCollisionEnter2D(Collision2D other){
        //Add card values here
		if (QuestionManager.suitQuestion == "Heart") {
			currentAnswer = RandomEquationHeart.totalAnswerHeart;
		}
		if (QuestionManager.suitQuestion == "Club") {
			currentAnswer = RandomEquationClub.totalAnswerClub;
		}
		if (QuestionManager.suitQuestion == "Spade") {
			currentAnswer = RandomEquationSpade.totalAnswerSpade;
		}
		if (QuestionManager.suitQuestion == "Diamond") {
			currentAnswer = RandomEquationDiamond.totalAnswerDiamond;
		}
		destroyCount++;
		print ("Sum: " + currentAnswer + "- trigger detected!");
		Destroy (other.gameObject);

		if (destroyCount == SpawnRandom.maxCards) {
			Application.LoadLevel ("Answer"); 
		}
	}
}
