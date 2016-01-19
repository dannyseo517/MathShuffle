using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MysterySuit : MonoBehaviour {
	//The sprites that will be looped through
	public Sprite[] CardSuits;
	//How fast does the suit change
	public float suitDelay;
	//The length of the array
	private int SuitsLength;
	//The current image component
	private Image currentObj;
	//The current image to be switched to
	private int currentPos;
	//Current position offset
	private static int posOffset;
	//Check whether the card was already clicked
	private static bool cardChecked;
	//Whether a card will contatin a life or not
	private static int LifeDeterminer;
	// Use this for initialization
	void Start () {
		LifeDeterminer = Random.Range (0, 500);
		cardChecked = false;
		SuitsLength = CardSuits.Length;
		currentPos = 0;
		posOffset = Random.Range (0,SuitsLength);
		currentObj = gameObject.GetComponent<Image> ();
		transform.parent.GetComponentInChildren<Text> ().text = "?";
		InvokeRepeating ("ChangeSuit", 0, suitDelay);
	}
	
	//Changes the suit
	void ChangeSuit () {
		if (currentPos < SuitsLength) {
			currentObj.sprite = CardSuits [currentPos];
			currentPos++;
		} else {
			currentObj.sprite = CardSuits [0];
			currentPos = 0;
		}
	}
	//stops the invoke repeating
	void ChooseSuit(){
		//Saves the current objects textfield
		GameObject curCardValue = transform.parent.transform.GetChild (0).gameObject;
		GameObject lifeSprite = transform.parent.transform.GetChild (3).gameObject;
		//Stops the loop
		CancelInvoke ("ChangeSuit");
		//Will check whether the conditions for an extra life are met
		if (LifeDeterminer < 50) {
			//Disables the mini sprites
			currentObj.enabled = false;
			//Hides text
			curCardValue.GetComponent<Text> ().enabled = false;
			//shows the +1 heart
			lifeSprite.GetComponent<Image> ().enabled = true;
			//Adds an extra life
			if (!cardChecked) {
				CorrectAnswer.Lives += 1;
			}

		} else {
			//Sets the suit to randomly
			currentObj.sprite = CardSuits [posOffset];
			if (!cardChecked) {
				switch (posOffset) {
				case 0:
					curCardValue.AddComponent <RandomEquationSpade> ();
					break;
				case 1:
					curCardValue.AddComponent <RandomEquationHeart> ();
					break;
				case 2:
					curCardValue.AddComponent <RandomEquationDiamond> ();
					break;
				case 3:
					curCardValue.AddComponent <RandomEquationClub> ();
					break;
				}
			}
		}
		transform.parent.GetComponent<Button> ().enabled = false;
		cardChecked = true;
	}
}
