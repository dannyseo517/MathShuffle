using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextInput : MonoBehaviour {

	public void ChangePlayerName()
	{
		Text inputText = GameObject.Find ("PlayerName").GetComponent<Text> ();
		//inputText.text.PadRight (15);
		GameOver.playerName = inputText.text;
		print (GameOver.playerName);
	}
}
