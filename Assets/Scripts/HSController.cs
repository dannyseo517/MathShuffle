using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HSController : MonoBehaviour
{
	private string secretKey = "mathshuffle"; // Edit this value and make sure it's the same as the one stored on the server
	public string addScoreURL = "http://mathshuffle.tk/addscore.php?"; //be sure to add a ? to your url
	public string highscoreURL = "http://mathshuffle.tk/display.php";
	public string addAchievementURL = "http://mathshuffle.tk/addachievement.php?";
	public string achievementsURL = "http://mathshuffle.tk/achievements.php";
	
	void Start()
	{
		//StartCoroutine(GetScores());
	}
	public void postScore(string userName, int highestScore){
		StartCoroutine (PostScores (userName, highestScore));
	}
	public void getScore(){
		StartCoroutine (GetScores ());
	}
	public void addAchievement(string uniqueID, string achievements){
		StartCoroutine (AddAchievements(uniqueID, achievements));
	}
	public void getAchievements(){
		StartCoroutine (GetAchievements ());
	}
	// remember to use StartCoroutine when calling this function!
	IEnumerator PostScores(string name, int score)
	{
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(name + score + secretKey);
		
		string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	
	// Get the scores from the MySQL DB to display in a GUIText.
	// remember to use StartCoroutine when calling this function!
	IEnumerator GetScores()
	{
		gameObject.GetComponent<Text>().text = "Loading Scores";
		WWW hs_get = new WWW(highscoreURL);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
			gameObject.GetComponent<Text>().text = "Leaderboards is currently offline \n Please try again later!";
		}
		else
		{
			gameObject.GetComponent<Text>().text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}
	IEnumerator AddAchievements(string uniqueID, string achievements){
		//This connects to a server side php script that will add the name and score to a MySQL DB.
		// Supply it with a string representing the players name and the players score.
		string hash = Md5Sum(uniqueID + achievements + secretKey);
		
		string post_url = addAchievementURL + "UDID=" + uniqueID + "&achievements=" + WWW.EscapeURL(achievements) + "&hash=" + hash;
		
		// Post the URL to the site and create a download object to get the result.
		WWW hs_post = new WWW(post_url);
		yield return hs_post; // Wait until the download is done
		
		if (hs_post.error != null)
		{
			print("There was an error posting the high score: " + hs_post.error);
		}
	}
	IEnumerator GetAchievements(){
		gameObject.GetComponent<Text>().text = "Loading Scores";
		WWW hs_get = new WWW(achievementsURL);
		yield return hs_get;
		
		if (hs_get.error != null)
		{
			print("There was an error getting the high score: " + hs_get.error);
			gameObject.GetComponent<Text>().text = "Leaderboards is currently offline \n Please try again later!";
		}
		else
		{
			gameObject.GetComponent<Text>().text = hs_get.text; // this is a GUIText that will display the scores in game.
		}
	}
	public  string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);
		
		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);
		
		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";
		
		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}
		
		return hashString.PadLeft(32, '0');
	}
	
}
