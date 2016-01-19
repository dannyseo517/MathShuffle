using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public void PauseGame() {
		Time.timeScale = 0;
	}
	public void UnPauseGame() {
		Time.timeScale = 1;
	}
}
