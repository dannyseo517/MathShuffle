using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CheckAchievements : MonoBehaviour {
	// Use this for initialization
	void Start () {
		if (Achievements.acquiredAchievements != null) {
			for (int i = 1; i < Achievements.achievementsList.Length; i++) {
				if (GameObject.Find("LockOverlay" + (i - 1)) != null) {
					GameObject.Find ("LockOverlay" + (i - 1)).SetActive ((Achievements.achievementsList [i].Equals ("0")) ? true : false);
				}
			}
		}
	}

}
