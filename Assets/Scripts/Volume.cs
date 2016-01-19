using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Volume : MonoBehaviour {
	public Text txt;
	public string temp;
	public static int count = 10;
	
	public void init(){
		temp = "";
		for(int i = 0; i < count; i++){
			temp += "|| ";
		}
		txt.text = temp;
	}
	
	public void volumeUp(){
		if (AudioListener.volume < 1.0f) {
			AudioListener.volume += 0.10f;
		}
	}
	
	public void volumeDown(){
		if (AudioListener.volume >= 0.0f) {
			AudioListener.volume -= 0.10f;
		}
	}
	
	public void add () {
		count++;
		if (withinRange()) {
			temp = "";
			for(int i = 0; i < count; i++){
				temp+= "|| ";
			}
			txt.text = temp;
		} else {
			--count;
		}
	}
	
	public void minus(){
		count--;
		if (withinRange()) {
			temp = "";
			for(int i = 0; i < count; i++){
				temp += "|| ";
			}
			txt.text = temp;
		} else {
			++count;
		}
	}
	
	public bool withinRange(){
		if (count <= 10 && count >= 0) {
			return true;
		}
		return false;
	}
	
}
