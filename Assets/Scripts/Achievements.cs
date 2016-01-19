using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class Achievements : MonoBehaviour {
	private HSController achieveAdd;
	public static bool lvl = false;
	public static bool strk = false;
	public static bool score = false;
	public static int streak = 0;
	public static bool[] levelAchieves = new bool[3];
	private static int levelCounter = 0;
	public static bool[] streakAchieves = new bool[3];
	private static int streakCounter = 0;
	public static bool[] scoreAchieves = new bool[3];
	private static int scoreCounter = 0;
	private string status;
	public static string acquiredAchievements;
	public static string[] achievementsList;
	
	void Awake(){
		checkLevel ();
		checkStreak ();
		checkScore ();
		acquiredAchievements = getAchievements ();
		splitAchievements ();
		achieveAdd = gameObject.GetComponent<HSController>();
		print (SystemInfo.deviceUniqueIdentifier);
		print (status);
		achieveAdd.addAchievement (SystemInfo.deviceUniqueIdentifier, status);

	}
	
	// activates a level badge for every 5 levels starting from level 3
	private void checkLevel(){
		if (CorrectAnswer.level == 13 && levelCounter < 3 && check(3)){
			lvl = true;
			levelAchieves [levelCounter++] = true;
		}
		if (CorrectAnswer.level == 8 && levelCounter < 2 && check(2)){
			lvl = true;
			levelAchieves[levelCounter++] = true;
		} 
		if (CorrectAnswer.level == 3 && levelCounter < 1 && check(1)) {
			lvl = true;
			levelAchieves[levelCounter++] = true;
		} else {
				lvl = false;
		}
	}
	
	// activates a streak badge for every 3 consecutive correct answers
	private void checkStreak(){
		if(streak == 11 && streakCounter < 3 && check (6)) {
			strk = true;
			streakAchieves[streakCounter++] = true;
		}
		if (streak == 7 && streakCounter < 2 && check (5)){
			strk = true;
			streakAchieves [streakCounter++] = true;
		}
		if (streak == 3 && streakCounter < 1 && check (4)) {
			strk = true;
			streakAchieves [streakCounter++] = true;
		} else {
			strk = false;
		}
	}
	
	// activates a score badge for every 500
	private void checkScore(){
		if (CorrectAnswer.score >= 1500 && scoreCounter > 3 && check(9)) {
			score = true;
			scoreAchieves[scoreCounter++] = true;
		}
		if (CorrectAnswer.score >= 1000 && scoreCounter > 2 && check(8)){
			score = true;
			scoreAchieves[scoreCounter++] = true;
		} 
		if (CorrectAnswer.score >= 500 && scoreCounter > 1 && check(7)){
			score = true;
			scoreAchieves[scoreCounter++] = true;
		} else {
			score = false;
		}
	}

	// returns a list of badges earned in a game
	public string getAchievements(){
		status = "";
		//int totalAchievements = levelAchieves.Length + streakAchieves.Length + scoreAchieves.Length;
		for (int i = 0; i < levelAchieves.Length; i++)
			status += (levelAchieves[i]) ? " 1" : " 0";
		for (int i = 0; i < streakAchieves.Length; i++)
			status += (streakAchieves[i]) ? " 1" : " 0";
		for (int i = 0; i < scoreAchieves.Length; i++)
			status += (scoreAchieves[i]) ? " 1" : " 0";
		return status;
	}

	private static void splitAchievements() {
		if (acquiredAchievements != null) {
			achievementsList = Regex.Split (acquiredAchievements, @"\D+");
		}
	}
	public static void updateAchievements(string list) {
		acquiredAchievements = list;
		splitAchievements ();
		print (achievementsList [0]);
		print (achievementsList [1]);
		for (int i = 0; i < levelAchieves.Length; i++)
			levelAchieves [i] = (achievementsList [i+1].Equals("0")) ? false: true;
		print (levelAchieves [0] + " " + levelAchieves [1] + " " + levelAchieves [2]);
		for (int i = 0; i < streakAchieves.Length; i++)
			streakAchieves [i] = (achievementsList [i + 4].Equals("0")) ? false: true;
		for (int i = 0; i < scoreAchieves.Length; i++)
			scoreAchieves [i] = (achievementsList [i + 7].Equals("0")) ? false: true;
		print ("here"+acquiredAchievements);
	}
	private bool check(int i) {
		return achievementsList [i].Equals ("0");
	}
}
