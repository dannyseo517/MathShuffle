using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpawnRandom : MonoBehaviour {
	public GameObject[] randomObject;
	private float spawnDelay = 0.7f;
	public float spawnTime = 0.3f;
	public float minY = -1.0f;
	public float maxY = 3.0f;
	public float xPosition = -495f;
	public int minNum = 0;
	public int maxNum = 10;
	public static int level = 0;
	public static int maxCards = 5;
	private int cardCount = 0;
	private int suitRange;
	private bool mysteryBool = false;
	void Start(){
		InvokeRepeating ("Spawn", spawnTime, spawnDelay);
		//print (cardCount);
	}
	
	void Update(){
		if (cardCount == maxCards) {
			CancelInvoke ("Spawn");
		}
	}
	Vector3 GenerateYPosition(float minY, float maxY, float xPos){
		float y = Random.Range (minY, maxY);
		float x = xPos, z = 0.0f;
		
		return new Vector3 (x, y, z);
	}
	void Spawn () {
		if (mysteryBool == false) {
			suitRange = Random.Range (0, randomObject.Length);
			//Debug.Log("mystery will show");
		} else {
			suitRange = Random.Range (0, 3);
			//Debug.Log ("Mystery will NOT show");
		}
		GameObject tempCard = (GameObject) Instantiate (randomObject [suitRange], GenerateYPosition(minY, maxY, xPosition), transform.rotation);
		Text cardValue = tempCard.gameObject.GetComponentInChildren<Text> ();

		if (tempCard.GetComponentInChildren<Text> ().text == "?") {
			mysteryBool = true;
		}

		int randomNumber = Random.Range (minNum, maxNum);
	
		tempCard.transform.SetParent(GameObject.Find ("Main_Canvas").transform, false);
		cardCount++;
	}
}
