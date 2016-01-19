using UnityEngine;
using System.Collections;

public class GetScores : MonoBehaviour {
	private HSController scoreGet;
	// Use this for initialization
	void Start () {
		scoreGet = gameObject.GetComponent<HSController>();
		scoreGet.getScore ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
