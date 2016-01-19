using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetAchievements : MonoBehaviour {
	private HSController achieveGet;
	private string allAchievements;
	private string userID;
	// Use this for initialization
	void Start () {
		achieveGet = gameObject.GetComponent<HSController> ();
		achieveGet.getAchievements ();
		userID = SystemInfo.deviceUniqueIdentifier;
	}
	void Update() {
		allAchievements = GameObject.Find ("AchievementManager").GetComponent<Text> ().text;
		if (!allAchievements.Equals("Loading Scores")) {
			print ("here");
			if (allAchievements.IndexOf (userID) != -1) {
				print ("and here");
				allAchievements = allAchievements.Substring(allAchievements.LastIndexOf(userID) + userID.Length + 1 , 19);
				print (allAchievements);
				Achievements.updateAchievements(allAchievements);
			}
		}
	}

}
