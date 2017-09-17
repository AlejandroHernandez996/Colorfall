using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore_Menu_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Set the highscore text
		GetComponent<Text> ().text = "Highscore: " + PlayerPrefs.GetInt ("highscore");
	}

}
