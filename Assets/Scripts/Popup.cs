using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Popup : MonoBehaviour {
	
	private GameObject lvl, str, scr;
	
	void Start(){
		updateBadge ();
	}
	
	// updates all badges earned by player
	void updateBadge(){
		
		lvl = GameObject.Find ("level");
		str = GameObject.Find ("streak");
		scr = GameObject.Find ("score");
		
		lvl.SetActive (Achievements.lvl);
		str.SetActive (Achievements.strk);
		scr.SetActive (Achievements.score);
	}
	
	// hides the pop up notification for score
	public void hideScore(){
		scr.SetActive(false);
	}
	
	// hides the pop up notification for level
	public void hideLevel(){
		lvl.SetActive (false);
	}
	
	// hides the pop up notification for streak
	public void hideStreak(){
		str.SetActive(false);
	}
	
}